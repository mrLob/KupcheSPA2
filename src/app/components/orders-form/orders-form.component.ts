import { Input, Output, Component, OnInit, EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DatePipe } from '@angular/common';

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
    neworder: IOrder = new IOrder();
    companies: Company[];
    selectedCompany: Company = new Company();
    orderForm: FormGroup;
    datenow = new Date();
    @Input() mode: string;
    @Input() company: number;
    // tslint:disable-next-line:no-output-rename
    @Output('newOrder') change = new EventEmitter<Order>();

    constructor(private ordersService: OrdersService,
        private companiesService: CompaniesService,
        public dialogRef: MatDialogRef<OrdersFormComponent>, private fb: FormBuilder) {
            this.datenow.setDate(this.datenow.getDate() + 1);
            this.orderForm = fb.group({
                'caption': ['', [Validators.required]],
                'description': ['', [Validators.required]],
                'cost': [0.00, [Validators.required]],
                'date': [new Date(this.datenow.getFullYear(), this.datenow.getMonth(), this.datenow.getDate()), [Validators.required]]
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
        if ( this.mode !== 'short') {
            console.log('post T'+this.mode);
            this.neworder.caption = this.orderForm.value.caption;
            this.neworder.description = this.orderForm.value.description;
            this.neworder.cost = this.orderForm.value.cost;
            this.neworder.upTo = this.orderForm.value.date;
            this.neworder.companyId = this.selectedCompany.idCompany;
        } else {
            this.neworder.caption = this.orderForm.value.caption;
            this.neworder.description = this.orderForm.value.description;
            this.neworder.cost = this.orderForm.value.cost;
            this.neworder.upTo = this.orderForm.value.date;
            this.neworder.companyId = this.company;
        }
        this.change.emit(this.order);
        this.ordersService.create(this.neworder).subscribe(data => {
            console.log('response ' + data);
        },
        error => {
            console.log(error._body);
        });
        this.order = new Order();
    }
}

export class IOrder {
    idOrder?: number;
    caption?: string;
    description?: string;
    cost?: number;
    geomap?: string;
    upTo?: Date;
    companyId?: number;

}
