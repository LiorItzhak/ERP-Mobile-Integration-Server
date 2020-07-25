using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitsOfWorks
{
    public interface ISaveable
    {

         int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
