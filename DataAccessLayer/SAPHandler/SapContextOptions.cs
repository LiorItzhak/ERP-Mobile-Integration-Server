
using DataAccessLayer.Repositories.Impls.Ral;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.SAPHandler
{
    public class SapContextOptions
    {
        public string DiApiServerConnection { get; set; }
        public DbContextOptions<SapSqlDbContext> SapSqlServerOptions { get; set; }
        public DbContextOptions<RalDbContext> ExtrasServerOptions { get; set; }
    }
}
