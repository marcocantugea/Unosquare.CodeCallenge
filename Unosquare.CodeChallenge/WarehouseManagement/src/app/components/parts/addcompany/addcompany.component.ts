import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';


@Component({
  selector: 'app-addcompany',
  templateUrl: './addcompany.component.html',
  styleUrls: ['./addcompany.component.css']
})
export class AddcompanyComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AddcompanyComponent>,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
  }

  saveNewCompany() {
    console.log('company saved');
    this.openSnackBar('Saved Success!', '', { duration: 3000 });
    this.openSnackBar('ERROR | information cannot be save, please try again later.', '', { duration: 3000 });
    this.closeDialog();
  }

  closeDialog() {
    this.dialogRef.close();
  }

  openSnackBar(message: string, action: string = '', config?: MatSnackBarConfig) {
    this._snackBar.open(message, action, config);
  }
}
