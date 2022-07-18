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
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    DashboardComponent,
    ErrorpageComponent,
    ProductsComponent,
    CompaniesComponent,
    SearchpageComponent,
    AddcompanyComponent
  ],
  imports: [
    BrowserModule,
    appRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }
