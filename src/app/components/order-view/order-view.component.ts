import { Component, OnInit, Input } from '@angular/core';
import {Order} from '../../shared/models';
@Component({
  selector: 'app-order-view',
  templateUrl: './order-view.component.html',
  styleUrls: ['./order-view.component.css']
})
export class OrderViewComponent implements OnInit {

@Input('order')
public order = new Order();

  constructor() {}

  ngOnInit() {
  }

}
