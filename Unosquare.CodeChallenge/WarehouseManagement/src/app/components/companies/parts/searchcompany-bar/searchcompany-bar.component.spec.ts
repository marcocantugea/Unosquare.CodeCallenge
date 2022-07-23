import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchcompanyBarComponent } from './searchcompany-bar.component';

describe('SearchcompanyBarComponent', () => {
  let component: SearchcompanyBarComponent;
  let fixture: ComponentFixture<SearchcompanyBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchcompanyBarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchcompanyBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
