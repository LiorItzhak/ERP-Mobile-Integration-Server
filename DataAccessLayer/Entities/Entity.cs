using System.Linq;

namespace DataAccessLayer.Entities
{
    public abstract class Entity
    {
        public override string ToString()
        {
            var propertyStrings = from prop in GetType().GetProperties()
                select $"{prop.Name}={prop.GetValue(this)}";
            return string.Join(", ", propertyStrings);
        }
    }
}