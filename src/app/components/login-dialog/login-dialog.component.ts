import { Component } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router, ActivatedRoute } from '@angular/router';

import { AlertService } from '../../services/alert.service';
import { AuthenticationService } from '../../services/authentication.service';
import { User } from '../../shared/models';

@Component({
    selector: 'app-login-dialog',
    templateUrl: './login-dialog.component.html',
    styleUrls: ['./login-dialog.component.css']
})
export class LoginDialogComponent {
  public model: User = new User();
  loading = false;
//   returnUrl: string;

  constructor(public dialogRef: MatDialogRef<LoginDialogComponent>,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private alertService: AlertService) {}
  login() {
    this.loading = true;
    this.authenticationService.login(this.model.email || '{}', this.model.pass || '{}')
        .subscribe(
            data => {
                this.dialogRef.close('true');
                this.router.navigate(['/myhome']);
            },
            error => {
                this.alertService.error(error._body);
                this.loading = false;
            });
  }
}
