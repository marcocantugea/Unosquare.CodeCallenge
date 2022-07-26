import { Component, OnInit,OnDestroy, Input, EventEmitter, Output } from '@angular/core';
import { Observable,interval, BehaviorSubject, map, Subscription } from 'rxjs';
import { ICompany } from '../../../../interfaces/ICompany';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { ThemePalette } from '@angular/material/core';
import { CompaniesService } from '../../../../services/companies.service';
import { Company } from '../../../../models/company.model';
import { MatDialog } from '@angular/material/dialog';
import { CompanydeletemodalComponent } from '../companydeletemodal/companydeletemodal.component';
import { AddcompanyComponent } from "../addcompany/AddcompanyComponent";

@Component({
  selector: 'app-companiesdatagrid',
  templateUrl: './companiesdatagrid.component.html',
  styleUrls: ['./companiesdatagrid.component.css']
})
export class CompaniesdatagridComponent implements OnInit, OnDestroy {

  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'indeterminate';
  subscribers: Subscription[] = [];
  @Input() Isloaded = false;
  @Input() listOfCompanies: ICompany[] | null = [];

  @Output() updateListEmiter = new EventEmitter<boolean>();

  constructor(public dialog: MatDialog) {
    
  }

  ngOnDestroy(): void {
    this.subscribers.forEach(item => item.unsubscribe());
  }

  ngOnInit(): void {
    
  }

  showDeleteDialog(company: ICompany) {
    let idToString = btoa(company.Id.toString());
    const dialogRef = this.dialog.open(CompanydeletemodalComponent, { disableClose: true, height: "300", width: "300", data: { id: idToString } });
    this.subscribers.push(dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        this.updateListEmiter.emit(true);
      }
    ));
  }

  showEditDialog(company: ICompany) {
    const dialogRef = this.dialog.open(AddcompanyComponent, { disableClose: true, height: "300", width: "300", data: { selectedCompany:company,isUpdate:true } });
    this.subscribers.push(dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        this.updateListEmiter.emit(true);
      }
    ));
  }

}
