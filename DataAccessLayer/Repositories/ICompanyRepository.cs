using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICompanyRepository : IRepository
    {
        Task<CompanyEntity> GetAsync();

    }
}
