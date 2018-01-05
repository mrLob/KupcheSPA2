import { Injectable } from '@angular/core';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs/Rx';

@Injectable()
export class StorageService {

    startListen() {

    }
    public setLocalStorageItem(key: string, value: any): void {
        localStorage.setItem(key, JSON.stringify(value));
    }
    getUserState(): boolean {
        if (localStorage.getItem('curretUser') === null) {
            return false;
        }else {
            return true;
        }
    }
    getLocalStorage() {

    }
}
