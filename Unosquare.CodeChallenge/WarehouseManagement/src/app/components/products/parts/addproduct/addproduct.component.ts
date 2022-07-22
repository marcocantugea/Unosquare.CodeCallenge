import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { ICompany } from '../../../../interfaces/ICompany';
import { IProduct } from '../../../../interfaces/iproduct';
import { Company } from '../../../../models/company.model';
import { Product } from '../../../../models/product.model';
import { CompaniesService } from '../../../../services/companies.service';

export interface productBasicInfo{
  name: string;
  price: number;
  companyId: number,
  ageRestriction: number,
  description: string 
}

export interface updateDataInfo {
  product: Product;
  isUpdate: boolean;
}

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent implements OnInit {

  public listOfCompanies: ICompany[] = []
  public subscriptions: Subscription[] = [];
  

  constructor(
    public dialogRef: MatDialogRef<AddproductComponent>,
    @Inject(MAT_DIALOG_DATA) public dataDialog: updateDataInfo,
    private _snackBar: MatSnackBar,
    public serviceCompany: CompaniesService
  ) { }

  ngOnInit(): void {
   
    this.getListCompanies();
  }

  getListCompanies() {
    const serviceGetAllCompanies = this.serviceCompany.getAllCompanies();
    this.subscriptions.push(serviceGetAllCompanies.subscribe(
      next => {
        next.forEach(item => {
          this.listOfCompanies.push(item);
        });
      },
      error => {
        console.log(error);
      },
      () => { }
    ));
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(item => item.unsubscribe);
  }

  closeDialog() {
    this.dialogRef.close();
  }

  openSnackBar(message: string, action: string = '', config?: MatSnackBarConfig) {
    this._snackBar.open(message, action, config);
  }

}
