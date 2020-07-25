//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using DataAccessLayer.Entities;
//using DataAccessLayer.Entities.UserData;
//
//namespace LogicLib.Services
//{
//    public interface ILeadUserDataService
//    {
//        Task<LeadUserData> UpsertAsync(LeadUserData entity, CancellationToken cancellationToken);
//        
//        Task<IEnumerable<LeadUserData>> GetPageAsync(int userId, int page, int size , DateTime? modifiedAfterUtc = null);
//
//    }
//}