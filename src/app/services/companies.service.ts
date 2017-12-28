import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { Company } from '../shared/models';

@Injectable()
export class CompaniesService {
    
    constructor(private http: HttpClient) {
    }
    //private url = this.config.apiUrl+"/orders";
    private url = "api/companies";
    
    getAll(){
        return this.http.get<Company[]>(this.url);
    }

    create(newCompany: Company){
        return this.http.post<Company>(this.url,newCompany);
    }

}