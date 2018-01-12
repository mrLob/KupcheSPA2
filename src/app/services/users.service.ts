import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { HttpClient } from '@angular/common/http';

import { User } from '../shared/models';
import { Observable } from 'rxjs/Observable';
import { AppConfig } from '../../app.config';

@Injectable()
export class UserService {
    private config = new AppConfig();
    private url = this.config.apiUrl + '/users';

    constructor(private http: Http, private httpClient: HttpClient) { }

    getAll() {
        return this.http.get(this.url, this.jwt()).map((response: Response) => response.json());
    }

    getById(_id: string) {
        return this.http.get(this.url + '/' + _id, this.jwt()).map((response: Response) => response.json());
    }

    create(user: User) {
        return this.http.post(this.url, user, this.jwt());
    }

    update(user: User) {
        return this.http.put(this.url  + user.idUsers, user, this.jwt());
    }

    delete(_id: string) {
        return this.http.delete(this.url  + _id, this.jwt());
    }

    // private helper methods

    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
        if (currentUser && currentUser.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new RequestOptions({ headers: headers });
        }
    }
}
