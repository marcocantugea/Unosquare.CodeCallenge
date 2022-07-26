import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { AddproductComponent } from './parts/addproduct/addproduct.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, OnDestroy {

  public updateList = false;
  public nameToSearch: string = "";
  subscribers: Subscription[] = [];

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnDestroy(): void {
    this.subscribers.forEach(item => item.unsubscribe());
  }

  ngOnInit(): void {
  }

  showAddProductsModal() {
    let updateList = false;
    const dialogRef = this.dialog.open(AddproductComponent, { disableClose: true });
    this.subscribers.push(dialogRef.afterClosed().subscribe(
      next => {
        if (next) updateList = true;
      },
      error => {
        console.log(error);
      },
      () => {
        if (updateList) this.updateList=true;
      }
    ));
  }

  searchByName(productName: string) {
    this.nameToSearch = productName;
  }

}
