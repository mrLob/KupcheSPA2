import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { Order } from '../shared/models';

@Injectable()
export class OrdersService {

    constructor(private http: HttpClient) {
    }
    // private url = this.config.apiUrl+"/orders";
    private url = 'http://localhost:5000/api/orders';

    getOrders() {
        return this.http.get<Order[]>(this.url);
    }

    createOrders(neworder: Order) {
        return this.http.post<Order>(this.url, neworder);
    }

}
