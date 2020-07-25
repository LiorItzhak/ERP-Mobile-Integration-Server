using DataAccessLayer.Repositories.Impls.Ral;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer
{
    public class RalDbContextContextFactory : IDesignTimeDbContextFactory<RalDbContext>
    {
        public RalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RalDbContext>();
         //   optionsBuilder.UseSqlite("Data Source=blog.db");
            optionsBuilder.UseSqlServer("Server=CM-SAP-SERVER;Database=IAM_AppV1;persist security info=True;user id=cm;password=Aa1234567;multipleactiveresultsets=True;");

            return new RalDbContext(optionsBuilder.Options);
        }
    }

   
}