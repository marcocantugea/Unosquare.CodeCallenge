import { Component, OnInit,OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { CompaniesService } from '../../services/companies.service';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, OnDestroy {

  updateList = false;
  nameToSearch = "";
  subscriptions: Subscription[] = [];
  totalOfProducts = 0;
  totalOfCompanies = 0;

  constructor(
    public productService: ProductsService,
    public companiesService: CompaniesService
  ) { }

  ngOnInit(): void {
    this.getTotalOfProducts();
    this.getTotalOfCompanies();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(item => item.unsubscribe());
  }

  getTotalOfProducts() : void{
    this.subscriptions.push(this.productService.getProducts().subscribe(
      next => {
        this.totalOfProducts = next.length;
      },
      error => {
        console.log(error);
      },
      () => { }
    ));
  }

  getTotalOfCompanies(): void {
    this.subscriptions.push(this.companiesService.getAllCompanies().subscribe(
      next => {
        this.totalOfCompanies = next.length;
      },
      error => {
        console.log(error);
      },
      () => { }
    ));
  }

  


}
