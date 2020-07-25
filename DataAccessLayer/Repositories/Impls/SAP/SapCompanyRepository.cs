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
    public class SapCompanyRepository : ICompanyRepository
    {
        private readonly SapSqlDbContext _dbContext;
        private readonly SapDiApiContext _diApiContext;

        public SapCompanyRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext)
        {
           _dbContext = dbContext;
           _diApiContext = diApiContext;
        }

        public async Task<CompanyEntity> GetAsync()
        {
            var company =
                await _dbContext.OADM
                .Join(_dbContext.ADM1,oadm=> oadm.Code,adm1=>adm1.Code,(oadm, adm1)=>new {OADM = oadm,ADM1 = adm1})
                .Join(_dbContext.ODSC, x =>new { BankCode= x.OADM.DflBnkCode , CountryCode = x.OADM.BankCountr },
                    odsc=> new { BankCode =  odsc.BankCode , CountryCode = odsc.CountryCod }, 
                    (x, odsc) => new JoinContainer{ OADM = x.OADM,ADM1 = x.ADM1, ODSC = odsc })
                .Select(AsCompany).FirstOrDefaultAsync(); // Note: no await
            return company;
        }

        private class JoinContainer
        {
            public OADM OADM { get; set; }
            public ADM1 ADM1 { get; set; }
            public ODSC ODSC { get; set; }

        }

        private static readonly Expression<Func<JoinContainer, CompanyEntity>> AsCompany =
            (e) => new CompanyEntity
            {
                Code = e.OADM.Code,
                Name = e.OADM.CompnyName,
                FederalTaxID = e.OADM.TaxIdNum,
                Manager = e.OADM.Manager,
                VatPercent = e.OADM.VatPrcnt ?? 0.0m,
                DefaultCurrency = e.OADM.SysCurrncy,
                Phone1 = e.OADM.Phone1,
                Phone2 = e.OADM.Phone2,
                Fax = e.OADM.Fax,
                Email = e.OADM.E_Mail,
                BankAccount = new BankAccountEntity {
                    Account = e.OADM.DflBnkAcct,
                    Branch = e.OADM.DflBranch,
                    Bank = new BankEntity
                    {
                        Code = e.ODSC.BankCode,
                        Name = e.ODSC.BankName,
                        CountryCode = e.ODSC.CountryCod,
                    }
                },
                Address = new Address
                {
                    ID = "Company Address",
                    Country = e.ADM1.Country,
                    City = e.ADM1.City,
                    Block = e.ADM1.Block,
                    Street = e.ADM1.Street,
                    NumAtStreet = e.ADM1.StreetNo,
                    Apartment = e.ADM1.Building,
                    ZipCode = e.ADM1.ZipCode

                },
                WebSite = e.ADM1.IntrntAdrs


            };
        private static Expression<Func<ADM1, Address>> AsAddressDetails =
            (a) => new Address
            {
                ID = "Company Address",
                Country = a.Country,
                City = a.City,
                Block = a.Block,
                Street = a.Street,
                NumAtStreet = a.StreetNo,
                Apartment = a.Building,
                ZipCode = a.ZipCode

            };

        private static Expression<Func<ODSC, BankEntity>> AsBankEntity =
            x => new BankEntity
            {
                Code = x.BankCode,
                Name = x.BankName,
                CountryCode = x.CountryCod,
            };

    }
}
