import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { ICompany } from '../../interfaces/ICompany';
import { Company } from '../../models/company.model';
import { CompaniesService } from '../../services/companies.service';
import { AddcompanyComponent } from "./parts/addcompany/AddcompanyComponent";

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit, OnDestroy {

  constructor(public dialog: MatDialog, public serviceCompanies: CompaniesService) { }
  public isLoadedGrid = false;
  public listOfCompanies: ICompany[] | null = [];
  public subscriptions: Subscription[] = [];

  ngOnInit(): void {

    this.getAllCompanies();

  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(item => item.unsubscribe());
  }

  openAddCompany() {
    const dialogRef = this.dialog.open(AddcompanyComponent, { disableClose:true,height: "300", width: "300" });
    dialogRef.afterClosed().subscribe(
      next => {},
      error => {
        console.log(error);
      },
      () => {
        this.updateList()
      }
    );
  }

  getAllCompanies() {

    this.subscriptions.push(this.serviceCompanies.getAllCompanies()
      .subscribe(
        next => {
          next.map(item => {
            this.listOfCompanies?.push(new Company(item.id, item.name))
          })
        },
        error => console.log(error),
        () => {
          this.isLoadedGrid = true
        }
      ));
  }

  filterByName(name:string ) {
    this.listOfCompanies = [];
    this.isLoadedGrid = false;

    if (name == "!all") {
      this.getAllCompanies();
      return;
    }

    this.subscriptions.push(this.serviceCompanies.getCompanyByName(name).subscribe(
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
    ));
  }

  updateList() {
    this.isLoadedGrid = false;
    this.listOfCompanies = [];
    this.getAllCompanies();
  }


}
