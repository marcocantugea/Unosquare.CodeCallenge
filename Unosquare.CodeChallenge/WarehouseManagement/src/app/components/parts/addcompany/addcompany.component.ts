import { Component, EventEmitter, Inject, OnInit, Output,OnChanges } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { ICompany } from '../../../interfaces/ICompany';
import { Company } from '../../../models/company.model';
import { CompaniesService } from '../../../services/companies.service';

export interface dataDialog {
  selectedCompany: ICompany,
  isUpdate: boolean;
}

@Component({
  selector: 'app-addcompany',
  templateUrl: './addcompany.component.html',
  styleUrls: ['./addcompany.component.css']
})
export class AddcompanyComponent implements OnInit {

  @Output() updateListEmiter = new EventEmitter<boolean>();
  public valueSelected: string = '';
  public isUpdate: boolean = false;
 

  constructor(
    public dialogRef: MatDialogRef<AddcompanyComponent>,
    @Inject(MAT_DIALOG_DATA) public dataDialog: dataDialog,
    private _snackBar: MatSnackBar,
    public serviceCompany: CompaniesService
  ) { }

  ngOnInit(): void {
    this.valueSelected = (this.dataDialog.selectedCompany) ? this.dataDialog.selectedCompany.Name : '';
    this.isUpdate = (this.dataDialog.isUpdate) ? true : false;
  }

  saveNewCompany(newCompanyName: string) {

    if (this.isUpdate) {
      let company: Company = new Company(this.dataDialog.selectedCompany.Id, newCompanyName);
      this.serviceCompany.updateCompanyInfo(company).subscribe(
        next => { },
        error => {
          this.openSnackBar('ERROR | information cannot be save, please try again later.', '', { duration: 3000 });
        },
        () => {
          this.closeDialog();
          this.openSnackBar('Saved Success!', '', { duration: 3000 });
          this.updateListEmiter.emit(true);
          return;
        }
      );
      return;
    }

    this.serviceCompany.addCompany(newCompanyName).subscribe(
      response => { },
      error => {
        this.openSnackBar('ERROR | information cannot be save, please try again later.', '', { duration: 3000 });
      },
      () => {
        this.closeDialog();
        this.openSnackBar('Saved Success!', '', { duration: 3000 });
        this.updateListEmiter.emit(true);
      }
    );
    
  }

  closeDialog() {
    this.dialogRef.close();
  }

  openSnackBar(message: string, action: string = '', config?: MatSnackBarConfig) {
    this._snackBar.open(message, action, config);
  }
}
