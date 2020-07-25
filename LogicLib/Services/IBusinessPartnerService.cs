using DataAccessLayer.Entities;
using LogicLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Entities.UserData;

namespace LogicLib.Services
{

    public interface IBusinessPartnerService
    {
        Task<BusinessPartner> UpdateBusinessPartnerAsync(string cid, BusinessPartner businessPartner, CancellationToken cancellation);
        Task<BusinessPartner> GetByKeyAsync(string cid);
        Task<IEnumerable<BusinessPartner>> GetPageAsync(int page, int size, DateTime? modifiedAfter = null);
        Task<BusinessPartner> AddBusinessPartnerAsync(BusinessPartner businessPartner , CancellationToken cancellation);
        Task<IEnumerable<CardGroup>> GetCardGroupsAsync();
        Task<IEnumerable<Indicator>> GetCardIndicatorsAsync();
        Task<IEnumerable<Industry>> GetCardIndustriesAsync();
        Task<IEnumerable<AccountBalanceRecordEntity>> GetBalanceAsync(string cid);
        

    }

    public interface IUserDataService 
    {
        
        Task<UserData> UpsertUserDataAsync(UserData entity, CancellationToken cancellationToken);
        
        Task<List<UserData>> UpsertUserDataAsync(List<UserData> entities, CancellationToken cancellationToken);

        Task<IEnumerable<UserData>> GetUserDataPageAsync(int userId, int page, int size , DateTime? modifiedAfter = null);
        
    }
}
