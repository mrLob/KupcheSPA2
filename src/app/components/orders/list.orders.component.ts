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

    public displayedColumns = ['caption', 'text', 'cost', 'geomap' ];
    public dataSource= new  MatTableDataSource<IOrder>();
    // tslint:disable-next-line:no-input-rename
    @Input('model')
    public orders: IOrder[];
    @Input('filter')
    public filter: string;
    @Input('dataSource')
    set allowDay(value: IOrder[]) {
        this.dataSource = new MatTableDataSource<IOrder>(value);
        this.dataSource.paginator = this.paginator;
    }

    @ViewChild(MatPaginator) paginator: MatPaginator;

// MatPaginator Inputs
    length = 100;
    pageSize = 10;
    pageSizeOptions = [5, 10, 25, 100];

    // MatPaginator Output
    pageEvent: PageEvent;

    constructor(private ordersService: OrdersService) {
    }
    ngOnInit() {

    }
    // tslint:disable-next-line:use-life-cycle-interface
    ngAfterViewInit() {
    }
}
export interface IOrder {
    caption?: string;
    text?: string;
    cost?: number;
    geomap?: string;

}
