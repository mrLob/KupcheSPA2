using System;
using System.Collections.Generic;
using System.Linq;
using webapi.Models;
using webapi.Helpers;

namespace webapi.Services
{
    public interface ICompanyService
    {
        Companies Create(Companies company);
    }
    public class CompanyService: ICompanyService
    {
        public CompanyService()
        {

        }
        public Companies Create(Companies company)
        {
            using(servicedbContext db = new servicedbContext())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }
            return company;
        }
    }
}