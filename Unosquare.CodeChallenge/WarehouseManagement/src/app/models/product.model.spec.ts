import { Company } from './company.model';
import { Product } from './product.model';
import { Store } from './store.model';

describe('Product', () => {
  it('should create an instance', () => {
    expect(new Product(0,"","",0,new Company(0,""),0,"",0,0,new Store(0,"","",""))).toBeTruthy();
  });
});
