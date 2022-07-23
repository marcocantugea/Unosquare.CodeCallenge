import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.css']
})
export class SearchbarComponent implements OnInit {

  @Output() filterEmit = new EventEmitter<string>();


  constructor() { }

  ngOnInit(): void {
  }

  searchProductName(productName: string) {
    if (productName == "!All") (<HTMLInputElement>document.getElementById("productName")).value="";
    this.filterEmit.emit(productName);
  }

}
