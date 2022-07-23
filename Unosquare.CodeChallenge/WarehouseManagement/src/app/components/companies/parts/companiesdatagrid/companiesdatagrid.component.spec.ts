import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompaniesdatagridComponent } from './companiesdatagrid.component';

describe('CompaniesdatagridComponent', () => {
  let component: CompaniesdatagridComponent;
  let fixture: ComponentFixture<CompaniesdatagridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompaniesdatagridComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompaniesdatagridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
