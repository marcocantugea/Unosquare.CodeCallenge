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

  @Output() filterEmit = new EventEmitter<string>();

  constructor(public serviceCompany: CompaniesService) { }

  ngOnInit(): void {
  }

  searchCompany(name: string) {

    this.filterEmit.emit(name);
    
  }

}
