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
    const dialogRef = this.dialog.open(AddcompanyComponent, { height: '400px', width: '600px' });
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
