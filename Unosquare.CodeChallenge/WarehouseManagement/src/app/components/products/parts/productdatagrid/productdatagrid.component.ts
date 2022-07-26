import { Component, Input, OnInit, SimpleChanges,OnChanges, OnDestroy } from '@angular/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { ThemePalette } from '@angular/material/core';
import { StoreinfoComponent } from '../storeinfo/storeinfo.component';
import { MatDialog } from '@angular/material/dialog';
import { IProduct } from '../../../../interfaces/iproduct';
import { Product } from '../../../../models/product.model';
import { Company } from '../../../../models/company.model';
import { Store } from '../../../../models/store.model';
import { PhotoviewerComponent } from '../photoviewer/photoviewer.component';
import { AddproductComponent } from '../addproduct/addproduct.component';
import { DeletedialogComponent } from '../deletedialog/deletedialog.component';
import { filter, Subscription } from 'rxjs';
import { ProductsService } from '../../../../services/products.service';
import { IFilterOperator } from '../../../../interfaces/ifilter-operator';
import { IFilter } from '../../../../interfaces/ifilter';

@Component({
  selector: 'app-productdatagrid',
  templateUrl: './productdatagrid.component.html',
  styleUrls: ['./productdatagrid.component.css']
})
export class ProductdatagridComponent implements OnInit, OnChanges, OnDestroy {

  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'indeterminate';
  public isLoaded:boolean = false;
  public listProducts: IProduct[] = [];
  subscriptions: Subscription[] = [];

  @Input() refreshList: boolean = false;
  @Input() searchByName: string = "";
  @Input() showOptions = true;
  @Input() showLastAdded = false;
  @Input() listOfFilters: { filterOperator: IFilterOperator, filter: IFilter }[] = [];

  constructor(
    public dialog: MatDialog,
    public productServices: ProductsService
  ) { }


  ngOnDestroy(): void {
    this.subscriptions.forEach(item => item.unsubscribe());
  }

  ngOnInit(): void {
    if (this.showLastAdded) {
      this.getLastAdded(5);
      return;
    }
    this.getProducts();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes["refreshList"]) {
      if (changes["refreshList"].currentValue==true) {
        this.refreshList = false;
        this.updateList();
      }
    }
    
    if (changes['searchByName']) {
      this.searchByNameProduct(changes['searchByName'].currentValue);
      return;
    }

    if (changes["showLast10Added"]) {
      if (changes["showLast10Added"].currentValue == true) {
        this.getLastAdded(5);
      }
    }

    if (changes['listOfFilters']) {
      this.searchProducts();
    }
  }

  getProducts() {
    this.subscriptions.push(this.productServices.getProducts().subscribe(
      next => {
        this.listProducts = next;
      },
      error => {
        console.log(error)
      },
      () => {
        this.isLoaded = true;
      }
    ));
  }

  searchProducts() {
    if (this.listOfFilters.length == 0) {
      this.getLastAdded(5);
      return;
    }
    this.isLoaded = false;
    this.listProducts = [];
    let filters: IFilter[] = [];
    this.listOfFilters.forEach(item => filters.push(item.filter));

    this.subscriptions.push(this.productServices.searchProducts(filters).subscribe(
      next => {
        this.listProducts = next;
      },
      error => {
        console.log(error)
      },
      () => {
        this.isLoaded = true;
        this.listOfFilters = [];
      }
    ));
  }

  showStoreInfo(product: IProduct) {
    const dialogRef = this.dialog.open(StoreinfoComponent, { data: product });
    this.subscriptions.push(dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        //this.updateList()
      }
    ));
  }

  showEditProduct(product: IProduct) {
    const dialogRef = this.dialog.open(AddproductComponent, { disableClose: true, data: { product:product, isUpdate:true } });
    this.subscriptions.push(dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        this.updateList()
      }
    ));
  }

  photoViewer(imageUrl: string) {
    const dialogRef = this.dialog.open(PhotoviewerComponent, { data: imageUrl });
    this.subscriptions.push(dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        //this.updateList()
      }
    ));
  }

  showDeleteConfirmationItem(product: IProduct) {
    const dialogRef = this.dialog.open(DeletedialogComponent, { data: product });
    let refreshPage = false;
    this.subscriptions.push(dialogRef.afterClosed().subscribe(
      next => {
        if (next === true) refreshPage = true;
      },
      error => {
        console.log(error);
      },
      () => {
        if (refreshPage) this.updateList();
      }
    ));
  }

  updateList() {
    this.isLoaded = false;
    this.listProducts = [];
    this.getProducts();
  }

  searchByNameProduct(nameProduct: string) {
    if (nameProduct == "") return;
    this.isLoaded = false

    if (nameProduct == "!All") {
      this.updateList();
      return;
    }

    this.listProducts = [];
    this.subscriptions.push(this.productServices.getProducts().subscribe(
      next => {
        this.listProducts = next.filter(item => item.name.toLowerCase().match(nameProduct));
      },
      error => {
        console.log(error)
      },
      () => {
        this.isLoaded = true;
      }
    ));
  }

  getLastAdded(size: number) {
    this.isLoaded = false;
    this.listProducts = [];
    this.subscriptions.push(this.productServices.getProducts().subscribe(
      next => {
        this.listProducts = next.reverse().slice(0, size);
      },
      error => {
        console.log(error)
      },
      () => {
        this.isLoaded = true;
      }
    ));
  }

}
