using System.Collections.Generic;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class DemoProductPropertiesRepository : IProductPropertiesRepository
    {
        public Dictionary<string, string> FindProperties(string itemCode)
        {
            //Key : database column name , Value: property name (item's property key)
            return new Dictionary<string, string> {
                { "Width1", "width" },
                { "Length1", "length"},
                { "Height1", "height"},
                { "U_roll", "units"}
            };
        }
    }
}
