import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-orders-dialog',
  templateUrl: './orders-dialog.component.html',
  styleUrls: ['./orders-dialog.component.css']
})
export class OrdersDialogComponent implements OnInit {
  companyId: number;

  constructor(public dialogRef: MatDialogRef<OrdersDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
      this.companyId = data.cId;
    }

  ngOnInit() {
    console.log('Company: ' + this.companyId);
  }

}
