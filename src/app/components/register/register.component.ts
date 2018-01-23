import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { AlertService } from '../../services/alert.service';
import { UserService } from '../../services/users.service';
import { User } from '../../shared/models';

@Component({
    selector: 'app-register',
    templateUrl: 'register.component.html',
    providers: [ UserService, AlertService ]
})

export class RegisterComponent {
    public user: User = new User();
    public loading = false;
    regForm: FormGroup;
    constructor(
        private router: Router,
        private userService: UserService,
        private alertService: AlertService,
        private fb: FormBuilder) {
            this.regForm = fb.group({
                'lastName': ['', [Validators.required]],
                'firstName': ['', [Validators.required]],
                'secondName': ['', [Validators.required]],
                'telephone': ['', [Validators.required]],
                'email': ['', [Validators.required]],
                'password': ['', [Validators.required]]
            });
        }

    register() {
        this.loading = true;
        this.userService.create(this.user).subscribe(data => {
            this.alertService.success('Registration successful', true);
            this.router.navigate(['/login']);
        },
        error => {
            console.log(error._body);
            this.loading = false;
        });
    }

}
