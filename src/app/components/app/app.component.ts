import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef} from '@angular/material';

import { AuthenticationService } from '../../services/authentication.service';
import { LoginDialogComponent } from '../login-dialog/login-dialog.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [AuthenticationService],
    encapsulation: ViewEncapsulation.None,
    preserveWhitespaces: false,
})
export class AppComponent implements OnInit  {
    public profile: string | null;
     profLoad: boolean ;
    constructor(private authenticationService: AuthenticationService, public dialog: MatDialog) { }

    ngOnInit() {
    }

    openDialog(): void {
        this.dialog.open(LoginDialogComponent);
    }

}
