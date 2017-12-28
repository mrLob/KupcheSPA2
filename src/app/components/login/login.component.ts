import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialogRef } from '@angular/material';

import { AlertService } from '../../services/alert.service'; 
import { AuthenticationService } from '../../services/authentication.service';
import { User } from '../../shared/models';

@Component({
    selector: 'login',
    templateUrl: 'login.component.html',
    styleUrls: ['./login.component.css'],
    providers: [AuthenticationService,AlertService]
})
 
export class LoginComponent implements OnInit {
    public model: User = new User();
    loading = false;
    returnUrl: string;
 
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService,
        public dialogRef: MatDialogRef<LoginComponent>) { }
 
    ngOnInit() {
        // reset login status
        this.authenticationService.logout();
 
        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/myhome';
    }
 
    login() {
        this.loading = true;
        this.authenticationService.login(this.model.email || '{}', this.model.pass || '{}')
            .subscribe(
                data => {
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    this.alertService.error(error._body);
                    this.loading = false;
                });
    }
}