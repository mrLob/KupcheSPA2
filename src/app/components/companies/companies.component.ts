import { Component, OnInit } from '@angular/core';

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
  constructor(private sevice: CompaniesService) { }
  loaded: boolean = false;
  ngOnInit() {
    this.sevice.getAll()
    .subscribe((data: Company[])=> this.companies = data);
  }

}
