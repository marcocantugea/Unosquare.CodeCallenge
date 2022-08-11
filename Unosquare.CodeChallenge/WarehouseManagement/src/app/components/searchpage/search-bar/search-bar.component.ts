import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { MatChipInputEvent } from '@angular/material/chips';
import { from, Observable, Subscription } from 'rxjs';
import { ICompany } from '../../../interfaces/ICompany';
import { IFilter } from '../../../interfaces/ifilter';
import { IFilterOperator } from '../../../interfaces/ifilter-operator';
import { CompaniesService } from '../../../services/companies.service';

const stringOperators: IFilterOperator[] = [
  { filterOperator: "contians", filterOperatorDescription: "contains" },
  { filterOperator: "==", filterOperatorDescription: "equals" }
];
const numericOperators: IFilterOperator[] = [
  { filterOperator: "==", filterOperatorDescription: "equals" },
  { filterOperator: "!=", filterOperatorDescription: "diferent" },
  { filterOperator: ">", filterOperatorDescription: "greater than" },
  { filterOperator: "<", filterOperatorDescription: "less than" },
  { filterOperator: ">", filterOperatorDescription: "greater than" },
  { filterOperator: ">=", filterOperatorDescription: "equal and greater than" },
  { filterOperator: "<=", filterOperatorDescription: "equal and less than" },
  ];

const fieldsProperties: { field: string, type: number }[] = [
  { field: "Name", type: 0 },
  { field: "Description", type: 0 },
  { field: "AgeRestriction", type: 1 },
  { field: "Price", type: 3 },
  { field: "CompanyId", type: 10 },
];

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})

export class SearchBarComponent implements OnInit, OnDestroy {

  public listOperators: IFilterOperator[] = [];
  public listOfFilters: { filterOperator: IFilterOperator, filter: IFilter }[] = [];
  public showCompaniesControl = false;
  public listOfCompanies: ICompany[] = [];
  subscriptions: Subscription[] = [];

  @Output() filterEmit = new EventEmitter <{ filterOperator: IFilterOperator, filter: IFilter }[]> ();

  constructor(
    public companyService: CompaniesService
  ) { }

  ngOnDestroy(): void {
    this.subscriptions.forEach(item => item.unsubscribe());
  }

  ngOnInit(): void {
    this.selectFilterOperators("Name");
    this.loadCompanies();
  }

  loadCompanies() {
    this.subscriptions.push(this.companyService.getAllCompanies().subscribe(
      next => {
        next.forEach(item => {
          this.listOfCompanies.push(item)
        })
      },
      error => {
        console.log(error)
      },
      () => { }
    ));
  }

  getCompany(id: string): ICompany {
    return this.listOfCompanies.filter(item => item.id == Number.parseInt(id))[0];
  }

  onFieldSelected(value: string) {
    this.selectFilterOperators(value);
  }

  selectFilterOperators(fieldName:string ) {
    this.showCompaniesControl = false;
    let itemSelected: { field: string, type: number } = fieldsProperties.filter(item => item.field == fieldName)[0];

    if (itemSelected.type == 0) this.listOperators = stringOperators;
    if (itemSelected.type == 1 || itemSelected.type == 3) this.listOperators = numericOperators;
    if (itemSelected.type == 10 || itemSelected.type == 2) this.listOperators = [{ filterOperator: "==", filterOperatorDescription: "equals" }];
    if (itemSelected.type == 10) this.showCompaniesControl = true;

  }

  addFilter(field: string, operator: string, value: string = "") {

    //let filters: { filterOperator: IFilterOperator, filter: IFilter }[] = this.listOfFilters;

    value=(<HTMLInputElement>document.getElementById("valueText")).value;

    if (value == "") return;

    let fieldProp = fieldsProperties.filter(item => item.field == field)[0];
    let operatorItem = this.listOperators.filter(item => item.filterOperator == operator)[0];
    let filter: IFilter = { field: field, value: value, typeField: fieldProp.type, whereOperator: operatorItem.filterOperator }

    let item = {
      filterOperator: operatorItem,
      filter: filter
    }

    this.listOfFilters = [...this.listOfFilters,item];
    (<HTMLInputElement>document.getElementById("valueText")).value = "";
    if (item.filter.field == "companyId") (<HTMLInputElement>document.getElementById("valueText")).value = "1";
    this.filterEmit.emit(this.listOfFilters);
  }

  removeFilter(field: string) {
    this.listOfFilters = this.listOfFilters.filter(item => item.filter.field != field);
    this.filterEmit.emit(this.listOfFilters);
  }
}
