import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { CompanydeletemodalComponent } from './companydeletemodal.component';

describe('CompanydeletemodalComponent', () => {
  let component: CompanydeletemodalComponent;
  let fixture: ComponentFixture<CompanydeletemodalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CompanydeletemodalComponent],
      imports: [MatDialogModule],
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanydeletemodalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
