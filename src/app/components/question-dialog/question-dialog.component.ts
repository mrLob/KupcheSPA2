import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-question-dialog',
    templateUrl: './question-dialog.component.html'
})
export class QuestionDialogComponent implements OnInit {

    constructor(public dialogRef: MatDialogRef<QuestionDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any ) {}

    ngOnInit() {
     }
}
