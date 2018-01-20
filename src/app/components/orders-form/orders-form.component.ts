import { Input, Output, Component, OnInit, EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { OrdersService } from '../../services/orders.service';
import { Order } from '../../shared/models';
import { Company } from '../../shared/models';
import { CompaniesService } from '../../services/companies.service';

@Component({
    selector: 'app-order-form',
    templateUrl: './orders-form.component.html',
    styleUrls: ['./orders-form.component.css'],
    providers: [OrdersService, CompaniesService]
})
export class OrdersFormComponent implements OnInit {
    public order: Order = new Order();
    public orders: Order[];
    companies: Company[];
    orderForm: FormGroup;
    date = new Date();
    // tslint:disable-next-line:no-output-rename
    @Output('newOrder') change = new EventEmitter<Order>();

    constructor(private ordersService: OrdersService,
        private companiesService: CompaniesService,
        public dialogRef: MatDialogRef<OrdersFormComponent>, private fb: FormBuilder) {
            this.orderForm = fb.group({
                'caption': ['', [Validators.required]],
                'description': ['', [Validators.required]],
                'cost': ['', [Validators.required]],
                'date': [new Date(this.date.getFullYear(), this.date.getMonth(), this.date.getDate() + 1), [Validators.required]]
            });
        }

    ngOnInit() {
        this.loadOrders();
    }

    loadOrders() {
        this.ordersService.getOrders()
        .subscribe((data: Order[]) => this.orders = data);
        this.companiesService.getAll()
        .subscribe((data: Company[]) => this.companies = data);
    }

    onSubmit() {
        console.log('post');
        this.order.caption = this.orderForm.value.caption;
        this.order.text = this.orderForm.value.description;
        this.order.cost = this.orderForm.value.cost;
        // this.order.upTo = this.orderForm.value.date;
        // this.change.emit(this.order);
        // this.ordersService.createOrders(this.order);

        console.log(this.order);
        this.ordersService.create(this.order).subscribe(data => {
            console.log(data);
        },
        error => {
            console.log(error._body);
        });
        this.order = new Order();
    }
}
