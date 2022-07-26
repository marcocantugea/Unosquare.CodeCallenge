import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { ICompany } from '../../../../interfaces/ICompany';
import { IProductBasicInfo } from '../../../../interfaces/iproduct-basic-info';
import { ProductBasicInfo } from '../../../../models/product-basic-info.model';
import { Product } from '../../../../models/product.model';
import { CompaniesService } from '../../../../services/companies.service';
import { ProductsService } from '../../../../services/products.service';
import { ProductFormValidators } from '../../../../validators/products/product-form-validators';

export interface updateDataInfo {
  product: Product;
  isUpdate: boolean;
}

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent implements OnInit, OnDestroy {

  public listOfCompanies: ICompany[] = []
  public subscriptions: Subscription[] = [];
  public formProduct: FormGroup = new FormGroup({
    productNametxt: new FormControl("", [Validators.required, ProductFormValidators.validateNotEmptyString]),
    pricetxt: new FormControl(0.00, [Validators.required, ProductFormValidators.validateCurrency, ProductFormValidators.validatePriceZero]),
    companySel: new FormControl(-1, [Validators.required, ProductFormValidators.validateSelector]),
    ageRestrictionText: new FormControl(15, [ProductFormValidators.validateBettwenNumbers1and100, ProductFormValidators.validateNumbersOnly]),
    imageURLtxt: new FormControl('', [ProductFormValidators.validateHttpLink]),
    descriptionTxt: new FormControl('')
  });

  constructor(
    public dialogRef: MatDialogRef<AddproductComponent>,
    @Inject(MAT_DIALOG_DATA) public dataDialog: updateDataInfo,
    private _snackBar: MatSnackBar,
    public serviceCompany: CompaniesService,
    public serviceProduct: ProductsService
  ) { }

  ngOnInit(): void {
    this.getListCompanies();
    if (this.dataDialog) {
      if (this.dataDialog.product) this.FillFormForEdition();
    }
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

  saveProduct() {
    console.log(this.formProduct);
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
          this.formProduct.reset();
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
        this.formProduct.reset();
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
      }
    ));
    this.formProduct.reset();
  }

  private getNewProduct(): IProductBasicInfo {
    let productName = this.formProduct.get('productNametxt')?.value; 
    let price = this.formProduct.get('pricetxt')?.value; 
    let companyId = this.formProduct.get('companySel')?.value; 
    let ageRestriction = this.formProduct.get('ageRestrictionText')?.value;  
    let description = this.formProduct.get('descriptionTxt')?.value 
    let imageUrl = this.formProduct.get('imageURLtxt')?.value; 

    if (productName.length > 50) productName = productName.substring(0, 50);
    if (description.length > 100) description = description.substring(0, 100);

    let newProduct: IProductBasicInfo = new ProductBasicInfo(productName,Number(price), Number.parseInt(companyId), Number.parseInt(ageRestriction), description, imageUrl);
    return newProduct;
  }


  FillFormForEdition() {
    this.formProduct.get('productNametxt')?.setValue(this.dataDialog.product.name);
    this.formProduct.get('pricetxt')?.setValue(this.dataDialog.product.price);
    this.formProduct.get('companySel')?.setValue(this.dataDialog.product.companyId);
    this.formProduct.get('ageRestrictionText')?.setValue(this.dataDialog.product.ageRestriction);
    this.formProduct.get('descriptionTxt')?.setValue(this.dataDialog.product.description);
    this.formProduct.get('imageURLtxt')?.setValue(this.dataDialog.product.imageIurl);
    this.formProduct.get('imageURLtxt')?.setValue(this.dataDialog.product.imageIurl); 
  }

  //form validations

  isRequiredField(controlName: string) {
    return (this.formProduct.get(controlName)?.hasError('required') && this.formProduct.get(controlName)?.touched)
  }

  validateMinMax(controlName: string) {
    return ((this.formProduct.get(controlName)?.hasError('min') || this.formProduct.get(controlName)?.hasError('max')) && this.formProduct.get(controlName)?.touched);
  }


}
