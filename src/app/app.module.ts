import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AgmCoreModule } from '@agm/core';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MaterialModule } from './material.module';
import { AuthGuard } from './_guards/auth.guard';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { OrdersComponent } from './components/orders/orders.component';
import { OrdersFormComponent} from './components/orders-form/orders-form.component';
import { OrdersListComponent } from './components/orders-list/orders-list.component';
import { OrderViewComponent } from './components/order-view/order-view.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AlertComponent } from './components/alert/alert.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { GoogleMapComponent } from './components/googlemap/googlemap.component';
import { HomeAuthComponent } from './components/home-auth/home-auth.component';
import { CompaniesComponent } from './components/companies/companies.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoginDialogComponent } from './components/login-dialog/login-dialog.component';
import { QuestionDialogComponent } from './components/question-dialog/question-dialog.component';
import { ProfileBarComponent } from './components/profile-bar/profile-bar.component';
import { CompanyViewComponent } from './components/company-view/company-view.component';
import { CompanyPostsComponent } from './components/company-posts/company-posts.component';
import { OrdersDialogComponent } from './components/orders-dialog/orders-dialog.component';
import { InvoicesListComponent } from './components/invoices-list/invoices-list.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        OrdersComponent,
        OrdersFormComponent,
        OrdersListComponent,
        OrderViewComponent,
        LoginComponent,
        RegisterComponent,
        AlertComponent,
        ToolbarComponent,
        GoogleMapComponent,
        HomeAuthComponent,
        CompaniesComponent,
        FooterComponent,
        LoginDialogComponent,
        QuestionDialogComponent,
        ProfileBarComponent,
        CompanyViewComponent,
        CompanyPostsComponent,
        OrdersDialogComponent
    ],
    imports: [
        FlexLayoutModule,
        CommonModule,
        HttpClientModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule,
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyBh7lDB034yICiJdrTsOUruVLvnmbvI8ug'
          }),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'companies', component: CompaniesComponent },
            { path: 'orders', component: OrdersComponent },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent },
            { path: 'myhome', component: HomeAuthComponent, canActivate: [AuthGuard] },

            { path: '**', redirectTo: 'home' }
        ])
    ],
    entryComponents: [
        OrdersFormComponent,
        OrdersDialogComponent,
        LoginDialogComponent,
        QuestionDialogComponent
    ]
})
export class AppModuleShared {
}
