import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { IProduct } from '../interfaces/iproduct';
import { IProductBasicInfo } from '../interfaces/iproduct-basic-info';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductsService implements OnInit, OnDestroy {

  protected host: string = (environment.APIhost) ? environment.APIhost : 'https://localhost:7032/';
  protected apiResouce = 'api/product';
  protected apiResoucePlural = 'api/products';

  constructor(public HttpClient: HttpClient) { }

  ngOnDestroy(): void {
    
  }
  ngOnInit(): void {
    
  }

  getProducts(): Observable<IProduct[]> {
    return this.HttpClient.get<IProduct[]>(this.host + this.apiResoucePlural);
  }

  getProduct(id: string): Observable<IProduct> {
    return this.HttpClient.get<IProduct>(this.host + this.apiResouce + "/" + id);
  }

  addProduct(productBasicInfo: IProductBasicInfo) {
    return this.HttpClient.post(this.host + this.apiResouce, productBasicInfo);
  }

  deleteProduct(id: string) {
    return this.HttpClient.delete(this.host + this.apiResouce + "/" + id);
  }

  updateProduct(id: string, productBasicInfo: IProductBasicInfo) {
    return this.HttpClient.put(this.host + this.apiResouce + "/" + id, productBasicInfo);
  }

}
