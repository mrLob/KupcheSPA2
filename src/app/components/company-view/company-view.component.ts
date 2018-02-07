import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CompaniesService } from '../../services/companies.service';
import { Company } from '../../shared/models';

@Component({
  selector: 'app-company-view',
  templateUrl: './company-view.component.html',
  styleUrls: ['./company-view.component.css', '../../shared/global.css'],
  providers: [CompaniesService]
})
export class CompanyViewComponent implements OnInit {

  public company: Company = new Company();
  private id: number;
  private sub: any;
  constructor(private service: CompaniesService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.service.getById(this.id).subscribe((data: Company) => this.company = data); // (+) converts string 'id' to a number
    });
  }

}
