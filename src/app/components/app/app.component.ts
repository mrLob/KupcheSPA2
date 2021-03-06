import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef} from '@angular/material';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../services/authentication.service';
import { StorageService } from '../../services/storage.service';
import { LoginDialogComponent } from '../login-dialog/login-dialog.component';
import { QuestionDialogComponent } from '../question-dialog/question-dialog.component';
import { AuthGuard } from '../../_guards/auth.guard';


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [AuthenticationService, StorageService, AuthGuard],
    encapsulation: ViewEncapsulation.None,
    preserveWhitespaces: false,
})
export class AppComponent implements OnInit  {
    public profile: string | null;
    profLoad: boolean ;
    constructor(private authenticationService: AuthenticationService,
        public localStor: StorageService,
        public authGuard: AuthGuard,
        private router: Router,
        public dialog: MatDialog) {}

    ngOnInit() {
        this.profile = this.localStor.getLocalStorageItem('currentUser');
        console.log(this.profile);
    }

    openDialog(): void {
        const dialog = this.dialog.open(LoginDialogComponent);
        dialog.afterClosed().subscribe(answer => {
            this.profLoad = answer;
        });
    }
    getProfile(): any {
        return JSON.parse(localStorage.getItem('currentUser'));
    }

}
