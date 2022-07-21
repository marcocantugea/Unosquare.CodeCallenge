import { Component, OnInit, OnDestroy, OnChanges } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BehaviorSubject } from 'rxjs';
import { ICompany } from '../../interfaces/ICompany';
import { Company } from '../../models/company.model';
import { CompaniesService } from '../../services/companies.service';
import { AddcompanyComponent } from '../parts/addcompany/addcompany.component';
import { CompanydeletemodalComponent } from '../parts/companydeletemodal/companydeletemodal.component'

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {

  constructor(public dialog: MatDialog, public serviceCompanies: CompaniesService) { }
  public isLoadedGrid = false;
  public listOfCompanies: ICompany[] | null = [];
  public listOfCOmpaniesBehavior = new BehaviorSubject<ICompany[]>([]);
  listOfCOmpaniesBehavior$ = this.serviceCompanies.getAllCompanies();

  ngOnInit(): void {

    this.getAllCompanies();

  }

  ngOnDestroy(): void {
    this.listOfCOmpaniesBehavior.unsubscribe();
  }


  openAddCompany() {
    const dialogRef = this.dialog.open(AddcompanyComponent, { disableClose:true,height: "300", width: "300" });
    dialogRef.afterClosed().subscribe(
      next => {
        console.log(next);
      },
      error => {
        console.log(error);
      },
      () => {
        this.updateList()
      }
    );
  }

  getAllCompanies() {
    this.listOfCOmpaniesBehavior$
      .subscribe(
        next => {
          next.map(item => {
            this.listOfCompanies?.push(new Company(item.Id, item.Name))
          })
        },
        error => console.log(error),
        () => { this.isLoadedGrid = true });
  }

  filterByName(name:string ) {
    this.listOfCompanies = [];
    this.isLoadedGrid = false;

    if (name == "!all") {
      this.getAllCompanies();
      return;
    }

    this.serviceCompanies.getCompanyByName(name).subscribe(
      next => {
        this.listOfCompanies?.push(next)
      },
      error => {
        console.log(error);
        this.isLoadedGrid = true
      },
      () => {
        this.isLoadedGrid = true
      }
    );
  }

  updateList() {
    this.isLoadedGrid = false;
    this.listOfCompanies = [];
    this.getAllCompanies();
  }


}
