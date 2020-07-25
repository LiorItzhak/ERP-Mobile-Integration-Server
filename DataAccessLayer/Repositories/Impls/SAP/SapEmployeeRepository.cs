using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class SapEmployeeRepository : SapReadOnlyRepository<EmployeeEntity, int>, IEmployeeRepository
    {
        private readonly SapSqlDbContext _dbContext;
        private readonly SapDiApiContext _diApiContext;
        
        public SapEmployeeRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext) : base(
            SelectEmployeeFromDb(dbContext), x => x.Sn)
        {
            _dbContext = dbContext;
            _diApiContext = diApiContext;
        }


        protected class Container
        {
            public OHEM ohem { get; set; }
            public OHPS ohps { get; set; }
            public OUDP pudp { get; set; }
        }

        private static IQueryable<EmployeeEntity> SelectEmployeeFromDb(SapSqlDbContext dbContext)
        {
            return dbContext.OHEM
                .GroupJoin(dbContext.OHPS, ohem => ohem.position, ohps => ohps.posID,
                    (ohem, ohps) => new {OHEM = ohem, OHPS = ohps})
                .SelectMany(x => x.OHPS.DefaultIfEmpty(), (x, y) => new {OHEM = x.OHEM, OHPS = y})
                .GroupJoin(dbContext.OUDP, j1 => j1.OHEM.dept, oudp => oudp.Code,
                    (j1, oudp) => new {OHEM = j1.OHEM, OHPS = j1.OHPS, OUDP = oudp})
                .SelectMany(x => x.OUDP.DefaultIfEmpty(), (x, y) => new {OHEM = x.OHEM, OHPS = x.OHPS, OUDP = y})
                .Select(o => new Container {ohem = o.OHEM, ohps = o.OHPS, pudp = o.OUDP})
                .Select(AsEmployeeEntity) //don't compile Expression (AsEmployeeEntity)! ,use container
                .OrderBy(e => e.Sn);
        }


        protected static readonly Expression<Func<Container, EmployeeEntity>> AsEmployeeEntity =
            c => new EmployeeEntity
            {
                Sn = c.ohem.empID,
                IsActive = c.ohem.Active == "Y",
                FirstName = c.ohem.firstName,
                MiddleName = c.ohem.middleName,
                LastName = c.ohem.lastName,
                ID = c.ohem.govID,
                Gender = c.ohem.sex == "M" ? EmployeeEntity.GenderTypes.Male : EmployeeEntity.GenderTypes.Female,
                Birthday = c.ohem.birthDate,
                JobTitle = c.ohem.jobTitle,

                Department = c.ohem.dept.HasValue
                    ? new Department
                    {
                        Code = c.pudp.Code,
                        Name = c.pudp.Name,
                        Description = c.pudp.Remarks
                    }
                    : null,

                Position = c.ohem.position.HasValue
                    ? new JobPosition
                    {
                        Code = c.ohps.posID,
                        Name = c.ohps.name,
                        Description = c.ohps.descriptio
                    }
                    : null,

                ManagerSN = c.ohem.manager,
                SalesmanSN = c.ohem.salesPrson,
                HomeAddress = new Address
                {
                    ID = "Home",
                    Country = c.ohem.homeCountr,
                    City = c.ohem.homeCity,
                    Block = c.ohem.homeBlock,
                    Street = c.ohem.homeStreet,
                    NumAtStreet = c.ohem.StreetNoH,
                    Apartment = c.ohem.HomeBuild,
                    ZipCode = c.ohem.homeZip
                },
                WorkAddress = new Address
                {
                    ID = "Work",
                    Country = c.ohem.workCountr,
                    City = c.ohem.workCity,
                    Block = c.ohem.workBlock,
                    Street = c.ohem.workStreet,
                    NumAtStreet = c.ohem.StreetNoW,
                    Apartment = c.ohem.WorkBuild,
                    ZipCode = c.ohem.workZip
                },
                HomePhone = c.ohem.homeTel,
                OfficePhone = c.ohem.officeTel,
                WorkCellular = c.ohem.mobile,
                Fax = c.ohem.fax,
                Email = c.ohem.email,
                PicPath = c.ohem.picture,
            };
//        protected static read only Expression<Func<OHEM, OHPS, OUDP, EmployeeEntity>> AsEmployeeEntity =
//(e, jp, dp) => new EmployeeEntity
//{
//    SN = e.empID,
//    IsActive = e.Active == "Y",
//    FirstName = e.firstName,
//    MiddleName = e.middleName,
//    LastName = e.lastName,
//    ID = e.govID,
//    Gender = e.sex == "M" ? EmployeeEntity.GenderTypes.Male : EmployeeEntity.GenderTypes.Female,
//    Birthday = e.birthDate,
//    JobTitle = e.jobTitle,

//    Department = e.dept.HasValue ? new Department
//    {
//        Code = dp.Code,
//        Name = dp.Name,
//        Description = dp.Remarks
//    } : null,

//    Position = e.position.HasValue ? new JobPosition
//    {
//        Code = jp.posID,
//        Name = jp.name,
//        Description = jp.descriptio
//    } : null,

//    ManagerSN = e.manager,
//    SalesmanSN = e.salesPrson,
//    HomeAddress = new AddressEntity
//    {
//        ID = "Home",
//        Country = e.homeCountr,
//        City = e.homeCity,
//        Block = e.homeBlock,
//        Street = e.homeStreet,
//        NumAtStreet = e.StreetNoH,
//        Apartment = e.HomeBuild,
//        ZipCode = e.homeZip
//    },
//    WorkAddress = new AddressEntity
//    {
//        ID = "Work",
//        Country = e.workCountr,
//        City = e.workCity,
//        Block = e.workBlock,
//        Street = e.workStreet,
//        NumAtStreet = e.StreetNoW,
//        Apartment = e.WorkBuild,
//        ZipCode = e.workZip
//    },
//    HomePhone = e.homeTel,
//    OfficePhone = e.officeTel,
//    WorkCellular = e.mobile,
//    Fax = e.fax,
//    Email = e.email,
//    PicPath = "TempValue replace at repository"
//};
    }
}