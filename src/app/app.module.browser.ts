import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.module';
import { AppComponent } from './components/app/app.component';
import { AuthenticationService } from './services/authentication.service';
import { AuthGuard } from './_guards/auth.guard';
import { AlertService } from './services/alert.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import 'hammerjs';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared,
        BrowserAnimationsModule
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        AuthenticationService,
        AuthGuard,
        AlertService
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
