import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatTableDataSource, PageEvent} from '@angular/material';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';


import { OrdersService } from '../../services/orders.service';
import { Order } from '../../shared/models';

@Component({
    selector: 'app-order-list',
    templateUrl: './orders-list.component.html',
    styleUrls: ['./orders-list.component.css'],
    providers: [OrdersService]
})
export class OrdersListComponent implements OnInit {

    public displayedColumns = ['caption', 'upTo', 'cost' ];
    public dataSource= new  MatTableDataSource<IOrder>();
    // tslint:disable-next-line:no-input-rename
    @Input('model')
    public orders: IOrder[];

    @Input('dataSource')
    set allowDay(value: IOrder[]) {
        this.dataSource = new MatTableDataSource<IOrder>(value);
        this.dataSource.paginator = this.paginator;
    }

    @Output() change: EventEmitter<any> = new EventEmitter();

    @ViewChild(MatPaginator) paginator: MatPaginator;

    // MatPaginator Inputs
    length = 100;
    pageSize = 10;
    pageSizeOptions = [ 4, 7, 10 ];

    // MatPaginator Output
    pageEvent: PageEvent;

    constructor(private ordersService: OrdersService) {}

    ngOnInit() {

    }
    // tslint:disable-next-line:use-life-cycle-interface
    ngAfterViewInit() {
    }

    public applyFilter(filterValue: string) {
        filterValue = filterValue.trim();
        if (filterValue === '') {
            return;
        }
        filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
        this.dataSource.filter = filterValue;
    }
    public onClick(id: any) {
        this.change.emit(id);
        console.log('changed ' + id);
    }
}

export interface IOrder {
    idOrder?: number;
    caption?: string;
    description?: string;
    cost?: number;
    geomap?: string;
    upTo?: string;

}
