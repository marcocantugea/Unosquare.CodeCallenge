import { Component, EventEmitter, Inject, OnInit, Output, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Company } from '../../../../models/company.model';
import { CompaniesService } from '../../../../services/companies.service';
import { dataDialog } from './addcompany.component';


@Component({
    selector: 'app-addcompany',
    templateUrl: './addcompany.component.html',
    styleUrls: ['./addcompany.component.css']
})
export class AddcompanyComponent implements OnInit, OnDestroy, OnChanges {

    @Output() updateListEmiter = new EventEmitter<boolean>();
    public valueSelected: string = '';
    public isUpdate: boolean = false;
    subscriptions: Subscription[] = [];


    constructor(
        public dialogRef: MatDialogRef<AddcompanyComponent>,
        @Inject(MAT_DIALOG_DATA) public dataDialog: dataDialog,
        private _snackBar: MatSnackBar,
        public serviceCompany: CompaniesService
  ) { }

    ngOnChanges(changes: SimpleChanges): void {
        throw new Error('Method not implemented.');
    }

    ngOnInit(): void {
        this.valueSelected = (this.dataDialog.selectedCompany) ? this.dataDialog.selectedCompany.name : '';
        this.isUpdate = (this.dataDialog.isUpdate) ? true : false;
    }


    ngOnDestroy(): void {
        this.subscriptions.forEach(item => item.unsubscribe());
    }

    saveNewCompany(newCompanyName: string) {

        if (this.isUpdate) {
            let company: Company = new Company(this.dataDialog.selectedCompany.id, newCompanyName);
            this.subscriptions.push(this.serviceCompany.updateCompanyInfo(company).subscribe(
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
            ));
            return;
        }

        this.subscriptions.push(this.serviceCompany.addCompany(newCompanyName).subscribe(
            response => { },
            error => {
                this.openSnackBar('ERROR | information cannot be save, please try again later.', '', { duration: 3000 });
            },
            () => {
                this.closeDialog();
                this.openSnackBar('Saved Success!', '', { duration: 3000 });
                this.updateListEmiter.emit(true);
            }
        ));

    }

    closeDialog() {
        this.dialogRef.close();
    }

    openSnackBar(message: string, action: string = '', config?: MatSnackBarConfig) {
        this._snackBar.open(message, action, config);
    }
}
