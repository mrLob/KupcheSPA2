import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { AppConfig } from '../../app.config';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthenticationService {
    config = new AppConfig();
    private url: string = this.config.apiUrl + '/users';
    constructor(private http: Http) { }

    login(email: string, password: string) {
        return this.http.post(this.url + '/authenticate', { email: email, pass: password })
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let user = response.json();
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }
            });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
}
