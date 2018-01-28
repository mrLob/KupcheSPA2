import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { AppConfig } from '../../app.config';

@Injectable()
export class FilesService {
    private config = new AppConfig();
    private url = this.config.apiUrl + '/images';

    constructor(private http: Http) {}

    uploadImage(image: any) {
        const headers = new Headers();
        headers.append('Accept', 'application/json');
        // DON'T SET THE Content-Type to multipart/form-data, You'll get the Missing content-type boundary error
        const options = new RequestOptions({ headers: headers });
        return this.http.post( this.url, image, options);
    }

}
