import { Component } from '@angular/core';

import { AuthGuard } from '../../_guards/auth.guard';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css'],
    providers: [ AuthGuard ]
})
export class NavMenuComponent {
    constructor(public authGuard: AuthGuard) {}
}
