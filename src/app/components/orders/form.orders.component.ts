import { Input, Output, Component, OnInit, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms/src/model';

import { OrdersService } from "../../services/orders.service";
import { Order } from "../../shared/models";

@Component({
    selector: 'order-form',
    templateUrl: './form.orders.component.html',
    styleUrls: ['./orders.component.css'],
    providers: [OrdersService]
})
export class OrdersFormComponent implements OnInit {
    public order: Order= new Order();
    public orders: Order[];
    @Output("newOrder")
    newOrderEvent = new EventEmitter<Order>() 
    
    constructor(private ordersService: OrdersService){}

    ngOnInit(){
        this.loadOrders();
    }

    loadOrders(){
        this.ordersService.getOrders()
        .subscribe((data: Order[]) => this.orders = data);
        
    }

    onSubmit(){
        this.newOrderEvent.emit(this.order);
        this.ordersService.createOrders(this.order);
        this.order = new Order();    
    } 
}