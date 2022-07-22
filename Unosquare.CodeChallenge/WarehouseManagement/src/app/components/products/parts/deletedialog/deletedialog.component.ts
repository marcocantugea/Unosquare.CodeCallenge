import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IProduct } from '../../../../interfaces/iproduct';

@Component({
  selector: 'app-deletedialog',
  templateUrl: './deletedialog.component.html',
  styleUrls: ['./deletedialog.component.css']
})
export class DeletedialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DeletedialogComponent>,
    @Inject(MAT_DIALOG_DATA) public dataDialog: IProduct
  ) { }

  ngOnInit(): void {
  }

  deleteItem() {
    console.log("delete item");
    this.closeDialog();
  }

  closeDialog() {
    this.dialogRef.close();
  }

}
