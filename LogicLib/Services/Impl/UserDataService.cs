using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities.UserData;
using DataAccessLayer.Repositories;

namespace LogicLib.Services.Impl
{
    public class UserDataService : IUserDataService
    {
        private readonly IDalService _dalService;

        public UserDataService(IDalService dalService) 
        {
            _dalService = dalService;
        }
        
        public async Task<UserData> UpsertUserDataAsync(UserData entity, CancellationToken cancellationToken)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            entity.LastModifiedUtc = DateTime.Now;
            var x = await transaction.LeadUsersData.UpsertAsync(entity);
            await transaction.CompleteAsync(cancellationToken);
            return x;
        }

        public async Task<List<UserData>> UpsertUserDataAsync(List<UserData> entities, CancellationToken cancellationToken)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            entities.ForEach(x=>x.LastModifiedUtc = DateTime.Now);
            var result = await transaction.LeadUsersData.UpsertAsync(entities);
            await transaction.CompleteAsync(cancellationToken);
            return result.ToList();
        }

        public async Task<IEnumerable<UserData>> GetUserDataPageAsync(int userId, int page, int size, DateTime? modifiedAfter = null)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var temp = await transaction.LeadUsersData.FindAllAsync(
                x => x.UserId == userId &&
                     (!modifiedAfter.HasValue || x.LastModifiedUtc > modifiedAfter),
                PageRequest.Of(page, size, Sort<UserData>.By(x => x.LeadSn)));
            return temp;
        }
    }
}