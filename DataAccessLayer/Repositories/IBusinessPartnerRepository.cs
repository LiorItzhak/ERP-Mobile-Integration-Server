using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities.BusinessPartners;

namespace DataAccessLayer.Repositories
{
    public interface IBusinessPartnerRepository : IWritableRepository<BusinessPartner,string> 
    {
        Task<IEnumerable<CardGroup>> GetAllGroupsAsync();
        Task<IEnumerable<Indicator>> GetAllIndicatorsAsync();

        Task<IEnumerable<Industry>> GetAllIndustriesAsync();


        Task<IEnumerable<AccountBalanceRecordEntity>>GetAccountBalanceRecordsAsync(string cid, Sort<IBusinessPartnerRepository> sort = Sort<IBusinessPartnerRepository>.Unsorted);

    }
}
