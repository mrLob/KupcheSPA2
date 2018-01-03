import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { QuestionDialogService } from '../../services/question-dialog.service';

@Component({
    selector: 'app-question-dialog',
    templateUrl: './question-dialog.component.html'
})
export class QuestionDialogComponent implements OnInit {
    title: string;
    caption: string;
    constructor(public dialogRef: MatDialogRef<QuestionDialogComponent>, private service: QuestionDialogService ) { }

    ngOnInit() {
       this.title = this.service.title;
       this.caption = this.service.caption;
     }
     // tslint:disable-next-line:use-life-cycle-interface
    ngAfterViewInit() {
        this.title = this.service.title;
       this.caption = this.service.caption;
    }
    isNo(): void {
        this.dialogRef.close('false');
    }
    isYes(): void {
        this.dialogRef.close('true');
      }
}
