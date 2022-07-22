import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductdatagridComponent } from './productdatagrid.component';

describe('ProductdatagridComponent', () => {
  let component: ProductdatagridComponent;
  let fixture: ComponentFixture<ProductdatagridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductdatagridComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductdatagridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
