import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-photoviewer',
  templateUrl: './photoviewer.component.html',
  styleUrls: ['./photoviewer.component.css']
})
export class PhotoviewerComponent implements OnInit {

 
  constructor(
    public dialogRef: MatDialogRef<PhotoviewerComponent>,
    @Inject(MAT_DIALOG_DATA) public imageUrl: string 
  ) { }

  ngOnInit(): void {
    console.log(this.imageUrl);
  }

}
