import { Component, OnInit } from '@angular/core';

import { OrdersService } from "../../services/orders.service";
import { Order } from "../../shared/models"

@Component({
    selector: 'order-view',
    templateUrl: './name.component.html',
    styleUrls: ['./orders.component.css'],
    providers: [OrdersService]
})
export class OrderViewComponent implements OnInit {
    public order: Order = new Order();
    constructor(private service: OrdersService) { }

    ngOnInit() {
        
     }
}