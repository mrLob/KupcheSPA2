import { Component, OnInit } from '@angular/core';

import { StorageService } from '../../services/storage.service';
import { OrdersService } from '../../services/orders.service';
import { Order } from '../../shared/models';

@Component({
  selector: 'app-home-auth',
  templateUrl: './home-auth.component.html',
  styleUrls: ['./home-auth.component.css', '../../shared/global.css'],
  providers: [OrdersService]
})
export class HomeAuthComponent implements OnInit {
  public order: Order = new Order();
  public orders: Order[] = [];
  changed: boolean = false;

  constructor(private service: OrdersService, public localStor: StorageService) {}

  ngOnInit() {
      this.loadOrders();
  }

  loadOrders() {
      const cId = this.localStor.getLocalStorageItem('currentUser');
      this.service.getFiltered(cId.company)
      .subscribe((data: Order[]) => this.orders = data);

  }
  onChanged(): void {
    this.changed = false;
  }
  change(id: Order): void {
    this.order = id;
    console.log(this.order.idOrders);
    this.changed = true;
  }
}
