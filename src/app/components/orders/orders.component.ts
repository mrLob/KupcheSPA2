import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms/src/model';
import { MatDialog, MatDialogRef } from '@angular/material';

import { OrdersFormComponent } from '../orders-form/orders-form.component';
import { OrdersService } from '../../services/orders.service';
import { Order } from '../../shared/models';

@Component({
    selector: 'orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.css'],
    providers: [OrdersService]
})
export class OrdersComponent implements OnInit {
    public order: Order = new Order();
    public orders: Order[];
    changed: boolean = false;

    constructor(private service: OrdersService,
        public dialog: MatDialog) {}

    ngOnInit() {
        this.loadOrders();
    }
    change(id: Order): void {
        this.order = id;
        console.log(this.order.idOrders);
        this.changed = true;
    }
    onChanged(): void {
        this.changed = false;
    }
    loadOrders(): void {
        this.service.getOrders()
        .subscribe((data: Order[]) => this.orders = data);
    }
    openDialog(): void {
        const dialog = this.dialog.open(OrdersFormComponent);
    }
}
