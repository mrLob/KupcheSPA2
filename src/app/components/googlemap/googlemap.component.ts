import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'app-google-map',
    templateUrl: './googlemap.component.html',
    styleUrls: ['./googlemap.component.css']
})
export class GoogleMapComponent implements OnInit {
    @Input() lat: number ;
    @Input() lng: number ;
    constructor() { }

    ngOnInit() {
    }
}
