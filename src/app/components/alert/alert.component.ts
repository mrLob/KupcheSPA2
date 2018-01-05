import { Component, OnInit } from '@angular/core';
import { AlertService } from '../../services/alert.service';

@Component({
   selector: 'app-alert',
   templateUrl: 'alert.component.html',
   providers: [AlertService]
})

export class AlertComponent implements OnInit {
   public message: any;

   constructor(private alertService: AlertService) { }

   ngOnInit() {
       this.alertService.getMessage().subscribe(message => { this.message = message; });
   }
}
