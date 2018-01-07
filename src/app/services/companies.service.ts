import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { Company } from '../shared/models';
import { AppConfig } from '../../app.config';

@Injectable()
export class CompaniesService {
    private config = new AppConfig();
    private url = this.config.apiUrl + '/companies';

    constructor(private http: HttpClient) {
    }

    getAll() {
        return this.http.get<Company[]>(this.url);
    }

    create(newCompany: Company) {
        return this.http.post<Company>(this.url, newCompany);
    }

}
