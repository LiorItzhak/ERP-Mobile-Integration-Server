using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities.UserData;

namespace DataAccessLayer.Repositories
{
    public interface ILeadUserDataRepository  : IWritableRepository<UserData,LeadUserDataKey>
    {
        Task<UserData> UpsertAsync(UserData entity);
        Task<IEnumerable<UserData>> UpsertAsync(IEnumerable<UserData> entity);

    }

    public class LeadUserDataKey
    {
        public LeadUserDataKey(int userId, string leadSn)
        {
            UserId = userId;
            LeadSn = leadSn;
        }

        public int UserId { get; private set; }
        public string LeadSn { get; private set; }
        



    }
}