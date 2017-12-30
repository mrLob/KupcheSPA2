import { Component, OnInit, HostListener } from '@angular/core';

import { CompaniesService } from '../../services/companies.service';
import { Company } from '../../shared/models';

@Component({
  selector: 'companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css'],
  providers: [CompaniesService]
})

export class CompaniesComponent implements OnInit {

  public companies: Company[];
  public test= 3;

  constructor(private sevice: CompaniesService) { }

  ngOnInit() {
    this.sevice.getAll()
    .subscribe((data: Company[]) => this.companies = data);
  }
  @HostListener('window:resize', ['$event'])
  onResize(event) {
    const element = event.target.innerWidth;
    console.log(element);

    if ( element > 980 ) {
      this.test = 3;
    }
    if (element <= 980) {
      this.test = 2;
    }

    if (element <= 750) {
      this.test = 1;
    }
  }
}
