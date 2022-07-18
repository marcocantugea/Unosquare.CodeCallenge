import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CompaniesComponent } from "./components/companies/companies.component";
import { DashboardComponent } from "./components/dashboard/dashboard.component";
import { ErrorpageComponent } from "./components/errorpage/errorpage.component";
import { ProductsComponent } from "./components/products/products.component";
import { SearchpageComponent } from "./components/searchpage/searchpage.component";


//definition of the routs
const appRoute: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch:'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'companies', component: CompaniesComponent },
  { path: 'search', component: SearchpageComponent },
  { path: '**', component: ErrorpageComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoute)
  ],
  exports: [
    RouterModule
  ]
})
export class appRoutingModule {

}
