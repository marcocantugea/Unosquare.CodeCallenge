import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddcompanyComponent } from '../parts/addcompany/addcompany.component';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {

  constructor(public dialog: MatDialog ) { }

  ngOnInit(): void {
  }


  openAddCompany() {
    const dialogRef = this.dialog.open(AddcompanyComponent, { disableClose:true,height: "300", width: "300" });
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
