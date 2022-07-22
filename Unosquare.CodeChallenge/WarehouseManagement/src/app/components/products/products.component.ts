import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddproductComponent } from './parts/addproduct/addproduct.component';
import { PhotoviewerComponent } from './parts/photoviewer/photoviewer.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }

  showAddProductsModal() {
    const dialogRef = this.dialog.open(AddproductComponent, { disableClose: true });
    dialogRef.afterClosed().subscribe(
      next => {
        console.log(next);
      },
      error => {
        console.log(error);
      },
      () => {
        //this.updateList()
      }
    );
  }

}
