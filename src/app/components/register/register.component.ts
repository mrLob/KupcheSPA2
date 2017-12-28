import { Component } from '@angular/core';
import { Router } from '@angular/router';
 
import { AlertService } from '../../services/alert.service';
import { UserService } from '../../services/users.service';
import { User } from '../../shared/models'; 

@Component({
    selector: 'register',
    templateUrl: 'register.component.html',
    providers: [ UserService,AlertService ]
})
 
export class RegisterComponent {
    public user: User = new User();
    public loading = false;
    constructor(
        private router: Router,
        private userService: UserService,
        private alertService: AlertService){}
 
    register() {
        this.loading = true;
        this.userService.create(this.user).subscribe(data => {
            this.alertService.success('Registration successful', true);
            this.router.navigate(['/login']);
        },
        error => {
            this.alertService.error(error._body);
            this.loading = false;
        });
    }

}