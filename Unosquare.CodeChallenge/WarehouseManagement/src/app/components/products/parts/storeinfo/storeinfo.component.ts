import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IProduct } from '../../../../interfaces/iproduct';


@Component({
  selector: 'app-storeinfo',
  templateUrl: './storeinfo.component.html',
  styleUrls: ['./storeinfo.component.css']
})
export class StoreinfoComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<StoreinfoComponent>,
    @Inject(MAT_DIALOG_DATA) public product: IProduct,
  ) { }

  ngOnInit(): void {
  }

  closeDialog() {
    this.dialogRef.close();
  }

}
