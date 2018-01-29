import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { AppConfig } from '../../app.config';


@Injectable()
export class AddressService {
    private config = new AppConfig();
    private url = this.config.apiUrl + '/addresses';

    constructor(private http: Http) {}

    create(addr: any) {
        return this.http.post(this.url , addr);
    }
}
