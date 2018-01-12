import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms/src/model';

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
    changed: boolean;

    constructor(private service: OrdersService) {}

    ngOnInit() {
        this.loadOrders();
        this.changed = false;
    }
    change(id: Order) {
        this.order = id;
        console.log(this.order.idOrders);
        this.changed = true;
    }
    onChanged() {
        this.changed = !this.changed;
    }
    loadOrders() {
        this.service.getOrders()
        .subscribe((data: Order[]) => this.orders = data);
    }
}
