import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Observable } from 'rxjs';
import { IFilter } from '../../interfaces/ifilter';
import { IFilterOperator } from '../../interfaces/ifilter-operator';

@Component({
  selector: 'app-searchpage',
  templateUrl: './searchpage.component.html',
  styleUrls: ['./searchpage.component.css']
})
export class SearchpageComponent implements OnInit, OnChanges {

  public listOfFilters: { filterOperator: IFilterOperator, filter: IFilter }[] = [];

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    
  }

  ngOnInit(): void {
  }

  setFilters(filters: { filterOperator: IFilterOperator, filter: IFilter }[]) {
    this.listOfFilters = filters;
  }

}
