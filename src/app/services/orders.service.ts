import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { Order, Company } from '../shared/models';
import { AppConfig } from '../../app.config';

@Injectable()
export class OrdersService {
    private config = new AppConfig();
    private url = this.config.apiUrl + '/orders';

    constructor(private http: HttpClient) {
    }

    getOrders() {
        return this.http.get<Order[]>(this.url);
    }
    getFiltered(id: number) {
        return this.http.get<Order[]>(this.url + '/' + id);
    }

    create(order: any) {
        return this.http.post(this.url, order);
    }

}
