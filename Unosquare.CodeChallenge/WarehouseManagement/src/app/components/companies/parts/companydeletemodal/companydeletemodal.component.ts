import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { CompaniesService } from '../../../../services/companies.service';


export interface DataModal {
  id: string;
}

@Component({
  selector: 'app-companydeletemodal',
  templateUrl: './companydeletemodal.component.html',
  styleUrls: ['./companydeletemodal.component.css']
})


export class CompanydeletemodalComponent implements OnInit {

  public valueSelected: string = '';
  subscriptions: Subscription[] = [];

  constructor(
    public dialogRef: MatDialogRef<CompanydeletemodalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DataModal,
    private _snackBar: MatSnackBar,
    public serviceCompany: CompaniesService
  ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(item => item.unsubscribe());
  }

  closeDialog() {
    this.dialogRef.close();
  }

  openSnackBar(message: string, action: string = '', config?: MatSnackBarConfig) {
    this._snackBar.open(message, action, config);
  }

  deleteItem() {
    console.log(this.data.id);
    this.subscriptions.push(this.serviceCompany.deleteCompany(this.data.id).subscribe(
      next => { },
      error => {
        this.openSnackBar('ERROR | error trying to delete the item, please try again later.', '', { duration: 3000 });
      },
      () => {
        this.closeDialog();
        this.openSnackBar('SUCCESS, company deleted.', '', { duration: 3000 });
      }
    ));
  }

 
}
