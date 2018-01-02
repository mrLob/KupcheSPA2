import { Component, OnInit } from '@angular/core';

import { OrdersService } from '../../services/orders.service';
import { Order } from '../../shared/models';

@Component({
  selector: 'app-home-auth',
  templateUrl: './home-auth.component.html',
  styleUrls: ['./home-auth.component.css'],
  providers: [OrdersService]
})
export class HomeAuthComponent implements OnInit {
  public orders: Order[];

  constructor(private service: OrdersService) {}

  ngOnInit() {
      this.loadOrders();
  }

  loadOrders() {
      this.service.getOrders()
      .subscribe((data: Order[]) => this.orders = data);

  }

}
