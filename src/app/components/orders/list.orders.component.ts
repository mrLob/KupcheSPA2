import { Component, OnInit, Input } from '@angular/core';
import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatTableDataSource} from '@angular/material';

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

    public displayedColumns = ['caption', 'text', 'cost', 'geomap' ];
    

    constructor(private ordersService: OrdersService) {}
    public dataSource = new OrderDataSource(this.ordersService);
    ngOnInit() {
    }
}
export interface IOrder {
    caption?: string;
    text?: string;
    cost?: number;
    geomap?: string;

}
export class OrderDataSource extends DataSource<any> {
    constructor(private ordersService: OrdersService) {
      super();
    }
    connect(): Observable<IOrder[]> {
      return this.ordersService.getOrders();
    }
    disconnect() {}
  }
