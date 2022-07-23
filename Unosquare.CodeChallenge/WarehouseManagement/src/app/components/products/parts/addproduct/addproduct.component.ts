import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { ICompany } from '../../../../interfaces/ICompany';
import { IProduct } from '../../../../interfaces/iproduct';
import { IProductBasicInfo } from '../../../../interfaces/iproduct-basic-info';
import { ProductBasicInfo } from '../../../../models/product-basic-info.model';
import { Product } from '../../../../models/product.model';
import { CompaniesService } from '../../../../services/companies.service';
import { ProductsService } from '../../../../services/products.service';

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
    public serviceCompany: CompaniesService,
    public serviceProduct: ProductsService
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

  closeDialog(refresh: boolean = true) {
    this.dialogRef.close(refresh);
  }

  openSnackBar(message: string, action: string = '', config?: MatSnackBarConfig) {
    this._snackBar.open(message, action, config);
  }

  saveCompanyAndCloseDialog() {
    
    let product: IProductBasicInfo = this.getNewProduct();

    if (this.dataDialog != null) {
      if (!this.dataDialog.isUpdate) return;
      let idstring = btoa(this.dataDialog.product.id.toString());
      this.subscriptions.push(this.serviceProduct.updateProduct(idstring, product).subscribe(
        next => { },
        error => {
          this.openSnackBar("ERROR | fail to add the new product, please try again later.", '', { duration: 3000 });
          console.log(error);
        },
        () => {
          this.openSnackBar("SUCCESS!, the product successfully updated.", '', { duration: 3000 });
          this.closeDialog();
        }
      ));
      return;
    }

    this.subscriptions.push(this.serviceProduct.addProduct(product).subscribe(
      next => { },
      error => {
        this.openSnackBar("ERROR | fail to add the new product, please try again later.", '', {duration:3000});
        console.log(error);
      },
      () => {
        this.openSnackBar("SUCCESS!, the product was added successfully.", '', { duration: 3000 });
        this.closeDialog();
      }
    ));

  }

  saveCompanyAndContinue() {

    let product: IProductBasicInfo = this.getNewProduct();

    this.subscriptions.push(this.serviceProduct.addProduct(product).subscribe(
      next => { },
      error => {
        this.openSnackBar("ERROR | fail to add the new product, please try again later.", '', { duration: 3000 });
        console.log(error);
      },
      () => {
        this.openSnackBar("SUCCESS!, the product was added successfully.", '', { duration: 3000 });
        this.cleanFields();
      }
    ));

  }

  private getNewProduct(): IProductBasicInfo {
    let productName = (<HTMLInputElement>document.getElementById("productNametxt")).value;
    let price = (<HTMLInputElement>document.getElementById("pricetxt")).value;
    let companyId = (<HTMLInputElement>document.getElementById("companySel")).value;
    let ageRestriction = (<HTMLInputElement>document.getElementById("ageRestrictionText")).value;
    let description = (<HTMLInputElement>document.getElementById("descriptionTxt")).value;
    let imageUrl = (<HTMLInputElement>document.getElementById("imageURLtxt")).value;
    console.log(price);
    let newProduct: IProductBasicInfo = new ProductBasicInfo(productName,Number(price), Number.parseInt(companyId), Number.parseInt(ageRestriction), description, imageUrl);
    console.log(newProduct);
    return newProduct;
  }

  private cleanFields(): void {
    (<HTMLInputElement>document.getElementById("productNametxt")).value="";
    (<HTMLInputElement>document.getElementById("pricetxt")).value="";
    (<HTMLInputElement>document.getElementById("companySel")).value="-1";
    (<HTMLInputElement>document.getElementById("ageRestrictionText")).value="";
    (<HTMLInputElement>document.getElementById("descriptionTxt")).value="";
    (<HTMLInputElement>document.getElementById("imageURLtxt")).value="";
  }

}
