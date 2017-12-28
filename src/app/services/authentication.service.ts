import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

 
@Injectable()
export class AuthenticationService {
    private url: string = "/api/users";
    constructor(private http: Http) { }
    public isAuth: boolean = false;
    lcs: string | null;

    login(email: string, password: string) {
        return this.http.post(this.url+'/authenticate', { email: email, pass: password })
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let user = response.json();
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.lcs = localStorage.getItem('currentUser');
                    this.isAuth = true;
                    console.log("MESSAGE: "+this.lcs);
                }
            });
    }
    getStates() {
        if(this.isAuth === true){
            return "authorized";
        }else{
            return "unauthorized";
        }
    }
    getProfile() {
        return this.lcs;
    }
 
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
}