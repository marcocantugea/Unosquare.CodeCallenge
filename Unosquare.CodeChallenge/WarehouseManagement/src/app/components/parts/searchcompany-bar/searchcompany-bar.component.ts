import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ICompany } from '../../../interfaces/ICompany';
import { Company } from '../../../models/company.model';
import { CompaniesService } from '../../../services/companies.service';

@Component({
  selector: 'app-searchcompany-bar',
  templateUrl: './searchcompany-bar.component.html',
  styleUrls: ['./searchcompany-bar.component.css']
})
export class SearchcompanyBarComponent implements OnInit {


  listOfCompanies: ICompany[] | null = [];
  //@Output() filterEmit = new EventEmitter<ICompany[]>();
  @Output() filterEmit = new EventEmitter<string>();

  constructor(public serviceCompany: CompaniesService) { }

  ngOnInit(): void {
  }

  searchCompany(name: string) {
    //this.listOfCompanies = [];
    //let itemsfiltered = this.listOfCompanies?.filter(value => value.Name === name);
    //let itemsfiltered = this.serviceCompany.getCompanyByName(name).subscribe(
    //  response => {
    //    this.listOfCompanies?.push(response)
    //  }
    //);

    //console.log(itemsfiltered);
    //this.filterEmit.emit(this.listOfCompanies ? this.listOfCompanies : []);
    this.filterEmit.emit(name);
    //let companiesFound: ICompany[] = [];
    //const service = this.serviceCompany.getCompanyByName(name).subscribe(
    //  next => {
    //    console.log(next);
    //    companiesFound.push(new Company(next.Id, next.Name));
    //  }
    //);

    ////service.unsubscribe();
    //this.listOfCompanies = companiesFound;
  }

}
