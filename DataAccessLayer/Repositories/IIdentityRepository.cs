using System.Threading.Tasks;
using DataAccessLayer.Entities.Authentication;

namespace DataAccessLayer.Repositories
{
    public interface IIdentityRepository : IReadOnlyRepository<IdentityUser,int>
    {
    }
}