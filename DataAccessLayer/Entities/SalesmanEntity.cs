using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class SalesmanEntity :Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sn { get; set; }
        public enum Status { Active, NoActive }
        public string Name { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }
        public Status ActiveStatus { get; set; }
    }
}
