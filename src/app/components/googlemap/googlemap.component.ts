import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'google-map',
    templateUrl: './googlemap.component.html',
    styleUrls: ['./googlemap.component.css']
})
export class GoogleMapComponent implements OnInit {
    lat: number ;
    lng: number ;
    constructor() { }

    ngOnInit() {
        this.lng = 7.809007;
        this.lat = 51.678418;
     }
}