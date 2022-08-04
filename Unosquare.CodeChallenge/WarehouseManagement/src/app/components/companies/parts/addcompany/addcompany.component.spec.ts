import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { CompaniesService } from '../../../../services/companies.service';
import { AddcompanyComponent } from "./AddcompanyComponent";
;

describe('AddcompanyComponent', () => {
  let component: AddcompanyComponent;
  let fixture: ComponentFixture<AddcompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddcompanyComponent],
      imports: [MatDialogModule],
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddcompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
