import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AgmCoreModule } from '@agm/core';

import { MaterialModule } from './material.module';
import { AuthGuard } from './_guards/auth.guard';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { OrdersComponent } from './components/orders/orders.component';
import { OrdersFormComponent} from './components/orders/form.orders.component';
import { OrdersListComponent } from './components/orders-list/orders-list.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AlertComponent } from './components/alert/alert.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { GoogleMapComponent } from './components/googlemap/googlemap.component';
import { HomeAuthComponent } from './components/home-auth/home-auth.component';
import { CompaniesComponent } from './components/companies/companies.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoginDialogComponent } from './components/login-dialog/login-dialog.component';

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
        LoginComponent,
        RegisterComponent,
        AlertComponent,
        ToolbarComponent,
        GoogleMapComponent,
        HomeAuthComponent,
        CompaniesComponent,
        FooterComponent,
        LoginDialogComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        HttpModule,
        FormsModule,
        MaterialModule,
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyBh7lDB034yICiJdrTsOUruVLvnmbvI8ug'
          }),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'orders', component: OrdersComponent },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent },
            { path: 'myhome', component: HomeAuthComponent, canActivate: [AuthGuard] },

            { path: '**', redirectTo: 'home' }
        ])
    ],
    entryComponents: [
        LoginDialogComponent
    ]
})
export class AppModuleShared {
}
