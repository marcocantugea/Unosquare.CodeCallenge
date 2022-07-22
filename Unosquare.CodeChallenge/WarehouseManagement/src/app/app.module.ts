import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { appRoutingModule } from './app-routing.module';
import { ErrorpageComponent } from './components/errorpage/errorpage.component';
import { ProductsComponent } from './components/products/products.component';
import { CompaniesComponent } from './components/companies/companies.component';
import { SearchpageComponent } from './components/searchpage/searchpage.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddcompanyComponent } from './components/parts/addcompany/addcompany.component';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { SearchcompanyBarComponent } from './components/parts/searchcompany-bar/searchcompany-bar.component';
import { CompaniesdatagridComponent } from './components/parts/companiesdatagrid/companiesdatagrid.component';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { CompanydeletemodalComponent } from './components/parts/companydeletemodal/companydeletemodal.component';
import { AddproductComponent } from './components/products/parts/addproduct/addproduct.component';
import { SearchbarComponent } from './components/products/parts/searchbar/searchbar.component';
import { ProductdatagridComponent } from './components/products/parts/productdatagrid/productdatagrid.component';
import { StoreinfoComponent } from './components/products/parts/storeinfo/storeinfo.component';
import { PhotoviewerComponent } from './components/products/parts/photoviewer/photoviewer.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    DashboardComponent,
    ErrorpageComponent,
    ProductsComponent,
    CompaniesComponent,
    SearchpageComponent,
    AddcompanyComponent,
    SearchcompanyBarComponent,
    CompaniesdatagridComponent,
    CompanydeletemodalComponent,
    AddproductComponent,
    SearchbarComponent,
    ProductdatagridComponent,
    StoreinfoComponent,
    PhotoviewerComponent
  ],
  imports: [
    BrowserModule,
    appRoutingModule,
    BrowserAnimationsModule,
    MatSnackBarModule,
    MatDialogModule,
    HttpClientModule,
    MatProgressSpinnerModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }
