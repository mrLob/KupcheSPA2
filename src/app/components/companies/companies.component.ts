import { Component, OnInit, HostListener } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';

import { CompaniesService } from '../../services/companies.service';
import { Company } from '../../shared/models';
import { OrdersDialogComponent } from '../orders-dialog/orders-dialog.component';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css', '../../shared/global.css'],
  providers: [CompaniesService]
})

export class CompaniesComponent implements OnInit {

  public companies: Company[];
  public columns= 3;

  constructor(private sevice: CompaniesService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.sevice.getAll()
    .subscribe((data: Company[]) => this.companies = data);
  }
  @HostListener('window:resize', ['$event'])
  onResize(event) {
    const element = event.target.innerWidth;
    console.log(element);

    if ( element > 980 ) {
      this.columns = 3;
    }
    if (element <= 980) {
      this.columns = 2;
    }

    if (element <= 750) {
      this.columns = 1;
    }
  }

  onOrder(id: any) {
    const dialog = this.dialog.open(OrdersDialogComponent, {
      data: {cId: id}
    });
  }
}
