import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatTableDataSource, PageEvent} from '@angular/material';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';


import { OrdersService } from '../../services/orders.service';
import { Order } from '../../shared/models';

@Component({
    selector: 'order-list',
    templateUrl: './list.orders.component.html',
    styleUrls: ['./orders.component.css'],
    providers: [OrdersService]
})
export class OrdersListComponent implements OnInit {
    // tslint:disable-next-line:no-input-rename
    @Input('model')
    public orders: IOrder[];
    @Input('filter')
    public filter: string;

    @ViewChild(MatPaginator) paginator: MatPaginator;

// MatPaginator Inputs
    length = 100;
    pageSize = 10;
    pageSizeOptions = [5, 10, 25, 100];

    // MatPaginator Output
    pageEvent: PageEvent;

    public displayedColumns = ['caption', 'text', 'cost', 'geomap' ];

    constructor(private ordersService: OrdersService) {}
    public dataSource = new MatTableDataSource<IOrder>();
    public orderSource = new OrderDataSource(this.ordersService, this.paginator);
    ngOnInit() {
    }
    // tslint:disable-next-line:use-life-cycle-interface
    ngAfterViewInit() {
        this.dataSource.paginator = this.paginator;
      }
}
export interface IOrder {
    caption?: string;
    text?: string;
    cost?: number;
    geomap?: string;

}
export class OrderDataSource extends DataSource<any> {
    constructor(private ordersService: OrdersService, private _paginator: MatPaginator) {
      super();
    }
    connect(): Observable<IOrder[]> {
      return this.ordersService.getOrders();
    }
    disconnect() {}
  }
