import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IProduct } from '../../interfaces/iproduct';
import { AddproductComponent } from './parts/addproduct/addproduct.component';
import { PhotoviewerComponent } from './parts/photoviewer/photoviewer.component';
import { ProductdatagridComponent } from './parts/productdatagrid/productdatagrid.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public updateList = false;
  public nameToSearch:string="";
 

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }

  showAddProductsModal() {
    let updateList = false;
    const dialogRef = this.dialog.open(AddproductComponent, { disableClose: true });
    dialogRef.afterClosed().subscribe(
      next => {
        console.log(next);
        if (next) updateList = true;
      },
      error => {
        console.log(error);
      },
      () => {
        if (updateList) this.updateList=true;
      }
    );
  }

  searchByName(productName: string) {
    this.nameToSearch = productName;
  }

}
