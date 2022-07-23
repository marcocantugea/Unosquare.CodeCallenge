import { ProductBasicInfo } from './product-basic-info.model';

describe('ProductBasicInfo', () => {
  it('should create an instance', () => {
    expect(new ProductBasicInfo("",0,0,0,"")).toBeTruthy();
  });
});
