import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {MatDialog, MatDialogRef} from '@angular/material';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../services/authentication.service';
import { QuestionDialogComponent } from '../question-dialog/question-dialog.component';

@Component({
  selector: 'app-profile-bar',
  templateUrl: './profile-bar.component.html',
  styleUrls: ['./profile-bar.component.css'],
  providers: [AuthenticationService]
})
export class ProfileBarComponent implements OnInit {

  @Input() profile: any;
  @Output() logout: EventEmitter<any> = new EventEmitter<any>();

  constructor(private authenticationService: AuthenticationService,
    private router: Router,
    public dialog: MatDialog) {}

  ngOnInit() {
  }

  logoutDialog(): void {
    const dialog = this.dialog.open(QuestionDialogComponent, {
      data: { title: 'Предупреждение!', text: 'Хотите выйти?' }
    });
    dialog.afterClosed().subscribe(answer => {
      if ( answer === true) {
        this.router.navigate(['/home']);
        this.authenticationService.logout();
      }
      this.logout.emit(answer);
    });
  }
}
