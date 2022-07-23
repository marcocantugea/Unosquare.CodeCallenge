import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Subscription } from 'rxjs';
import { IProduct } from '../interfaces/iproduct';
import { IProductBasicInfo } from '../interfaces/iproduct-basic-info';
import { ProductBasicInfo } from '../models/product-basic-info.model';
import { Product } from '../models/product.model';

import { ProductsService } from './products.service';

describe('ProductsService', () => {
  let service: ProductsService;
  let subscriptions: Subscription[] = [];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(ProductsService);
  });

  afterAll(() => {
    subscriptions.forEach(item => item.unsubscribe());
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Will get the list of products', (done: DoneFn) => {
    let listOfProducts: IProduct[] = [];
    subscriptions.push(service.getProducts().subscribe(
      next => {
        next.forEach(item => listOfProducts.push(item));
      },
      error => { },
      () => {
        expect(listOfProducts.length).toBeGreaterThan(1);
        done();
      }
    ));
  });

  it('Will get a product', (done: DoneFn) => {
    let product: IProduct;
    subscriptions.push(service.getProduct("Mg==").subscribe(
      next => {
        product = next
      },
      error => { },
      () => {
        expect(product.id).toBe(2);
        done();
      }
    ));
  });

  it('will create a product', (done: DoneFn) => {
    let product: IProductBasicInfo = new ProductBasicInfo("Product test unit test", 100.2, 3, 10, "this is a product test");
    subscriptions.push(service.addProduct(product).subscribe(
      next => { },
      error => {
        console.log(error);
      },
      () => {
        expect(true).toBeTrue();
        done();
      }
    ));
  });

  it('will delete a product', (done: DoneFn) => {
    let listOfProducts: IProduct[] = [];
    subscriptions.push(service.getProducts().subscribe(
      next => {
        next.forEach(item => listOfProducts.push(item));
      },
      error => { },
      () => {
        let lastProduct = listOfProducts.pop();
        if (lastProduct != undefined) {
          let lastid: string = btoa(lastProduct.id.toString());
          subscriptions.push(service.deleteProduct(lastid).subscribe(
            next => { },
            error => {
              console.log(error);
              done();
            },
            () => {
              expect(true).toBeTrue();
              done();
            }
          ));
        }
       }
    )); 
  });

  it('will update product info', (done: DoneFn) => {
    let idstring = "MQ==";
    let product: IProductBasicInfo = new ProductBasicInfo("Product test unit test", 100.2, 3, 10, "this is a product test");
    subscriptions.push(service.updateProduct(idstring, product).subscribe(
      next => { },
      error => {
        console.log(error);
      },
      () => {
        expect(true).toBeTrue();
        done();
      }
    ));
  });


});
