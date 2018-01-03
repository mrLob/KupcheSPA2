import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef} from '@angular/material';

import { AuthenticationService } from '../../services/authentication.service';
import { LoginDialogComponent } from '../login-dialog/login-dialog.component';
import { QuestionDialogComponent } from '../question-dialog/question-dialog.component';
import { QuestionDialogService } from '../../services/question-dialog.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [AuthenticationService, QuestionDialogService],
    encapsulation: ViewEncapsulation.None,
    preserveWhitespaces: false,
})
export class AppComponent implements OnInit  {
    public profile: string | null;
    profLoad: boolean ;
    constructor(private authenticationService: AuthenticationService,
        private questionService: QuestionDialogService,
        public dialog: MatDialog) {}

    ngOnInit() {
        console.log(this.profLoad);
        this.profLoad = false;
    }

    openDialog(): void {
        let dialog = this.dialog.open(LoginDialogComponent);
        dialog.afterClosed().subscribe(answer => {
            this.profLoad = answer;
            this.profile = JSON.parse(localStorage.getItem('currentUser'));
        });
    }
    logoutDialog(): void {
        this.questionService.title = 'Вопрос';
        this.questionService.caption = 'Хотите выйти?';
        let dialog = this.dialog.open(QuestionDialogComponent);
        dialog.afterClosed().subscribe(answer => {
            if ( answer === true ) {
                this.profLoad = false;
                this.authenticationService.logout();
            }
        });
    }

}
