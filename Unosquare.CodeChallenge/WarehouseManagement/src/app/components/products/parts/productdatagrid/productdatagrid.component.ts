import { Component, Input, OnInit, SimpleChanges,OnChanges } from '@angular/core';
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

@Component({
  selector: 'app-productdatagrid',
  templateUrl: './productdatagrid.component.html',
  styleUrls: ['./productdatagrid.component.css']
})
export class ProductdatagridComponent implements OnInit {

  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'indeterminate';
  public testProduct: IProduct = new Product(0, "Toy Story Buzz Vuelo Espacial", "Toy Story Buzz Vuelo Espacial", 2, new Company(0, "Mattel"), 459.35, "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRqYWqWbYTWEuI-d5Y4RB8UrFldHMpdkCfoqmv7CJYijolQfcy-Vbo1af2-a8KAK-jkf6PRDICytGtQ3TSjjxLpMw3i-aje0NfwqiW69WaG4R2hzaMGkvx1JA", 4, 5, new Store(1, "Plaza Cristal", "Avenida Lázaro Cárdenas Sn", "Xalapa, Veracruz"));
  public isLoaded:boolean = false;
  public listProducts: IProduct[] = [];
  subscriptions: Subscription[] = [];

  @Input() refreshList: boolean = false;
  @Input() searchByName: string = "";

  constructor(
    public dialog: MatDialog,
    public productServices: ProductsService
  ) { }

  ngOnInit(): void {
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

  showStoreInfo(product: IProduct) {
    const dialogRef = this.dialog.open(StoreinfoComponent, { data: product });
    dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        //this.updateList()
      }
    );
  }

  showEditProduct(product: IProduct) {
    const dialogRef = this.dialog.open(AddproductComponent, { disableClose: true, data: { product:product, isUpdate:true } });
    dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        this.updateList()
      }
    );
  }

  photoViewer(imageUrl: string) {
    const dialogRef = this.dialog.open(PhotoviewerComponent, { data: imageUrl });
    dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        //this.updateList()
      }
    );
  }

  showDeleteConfirmationItem(product: IProduct) {
    const dialogRef = this.dialog.open(DeletedialogComponent, { data: product });
    let refreshPage = false;
    dialogRef.afterClosed().subscribe(
      next => {
        if (next === true) refreshPage = true;
      },
      error => {
        console.log(error);
      },
      () => {
        if (refreshPage) this.updateList();
      }
    );
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

}
