using Trading_Service.Presentation.Payload;
using Trading_Service.Presentation.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Domain.IServices
{
  public  interface IStockCompanyService
    {

        Task<AddCompanyResponse> AddCompany(AddNewCompany company);
        Task<CompanyResponse> GetCompanies();

    }
}
