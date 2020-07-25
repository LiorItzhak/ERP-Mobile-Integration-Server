using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public interface IProductPropertiesRepository
    {
        Dictionary<string, string> FindProperties(string itemCode);
    }
}
