import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Subscriber, Subscription } from 'rxjs';
import { IProduct } from '../../../../interfaces/iproduct';
import { ProductsService } from '../../../../services/products.service';

@Component({
  selector: 'app-deletedialog',
  templateUrl: './deletedialog.component.html',
  styleUrls: ['./deletedialog.component.css']
})
export class DeletedialogComponent implements OnInit {

  protected subscribers: Subscription[] = [];

  constructor(
    public dialogRef: MatDialogRef<DeletedialogComponent>,
    @Inject(MAT_DIALOG_DATA) public dataDialog: IProduct,
    private _snackBar: MatSnackBar,
    public serviceProduct: ProductsService
  ) { }

  ngOnInit(): void {
  }

  deleteItem() {
    const idstring = btoa(this.dataDialog.id.toString());
    this.subscribers.push(this.serviceProduct.deleteProduct(idstring).subscribe(
      next => { },
      error => {
        this.openSnackBar("ERROR | cannot delete the item selected, plear try again later.", '', {duration:3000});
        console.log(error);
      },
      () => {
        this.openSnackBar("SUCCESS, item deleted", '', { duration: 3000 });
        this.closeDialog();
      }
    ));
    this.closeDialog();
  }

  closeDialog(refreshPage: boolean = true) {
    this.dialogRef.close(refreshPage);
  }

  openSnackBar(message: string, action: string = '', config?: MatSnackBarConfig) {
    this._snackBar.open(message, action, config);
  }

}
