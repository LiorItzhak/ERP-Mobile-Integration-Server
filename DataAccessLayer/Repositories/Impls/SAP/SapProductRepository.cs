using DataAccessLayer.Entities.Products;
using DataAccessLayer.Entities.Products.Properties;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class SapProductRepository : SapReadOnlyRepository<ProductEntity, string>, IProductRepository
    {
        private readonly SapSqlDbContext _dbContext;
        private readonly SapDiApiContext _diApiContext;


        public SapProductRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext)
            : base(SelectItems(dbContext), x => x.Code)
        {
            _dbContext = dbContext;
            _diApiContext = diApiContext;
        }


        public async Task<IEnumerable<ProductEntity>> GetAllActiveItemsForeSellAsync(int page, int size)
        {
            var products =
                await SelectItems(_dbContext)
                    .Where(i => i.IsActive && i.IsForSell)
                    .Skip(page * size)
                    .Take(size)
                    .ToListAsync();
            await GetSapProprieties(products);
            await GetPriceList(products);
            return products.getMockProperties();
        }

        private static IQueryable<ProductEntity> SelectItems(SapSqlDbContext dbContext)
        {
            return dbContext.OITM.Select(AsItemEntity);
        }

        private async Task<IEnumerable<ProductEntity>> GetSapProprieties(IEnumerable<ProductEntity> products)
        {
            var productEntities = products as ProductEntity[] ?? products.ToArray();
            var codeList = productEntities.Select(x => x.Code);
            var temp = (await _dbContext.OITM
                .Where(x => codeList.Contains(x.ItemCode))
                .Select(SelectSapProperties)
                .ToArrayAsync());

            productEntities.ToList().ForEach(x =>
            {
                var p = temp.First(i => i.ProductCode == x.Code);
                GetSapProperties(x, p);
            });
            return productEntities;
        }

        private static ProductEntity GetSapProperties(ProductEntity product, TempEntity x)
        {
            var pList = new List<ProductPropertyEntity>();
            if (x.DefaultHeight.HasValue && x.DefaultHeight > 0)
            {
                pList.Add(new ProductPropertyEntity
                {
                    Code = "height",
                    Type = ProductPropertyEntity.PropertyType.Decimal,
                    MinValue = 0,
                    UOM = "M",
                    DefaultValue = x.DefaultHeight
                });
            }

            if (x.DefaultWidth.HasValue && x.DefaultWidth > 0)
            {
                pList.Add(new ProductPropertyEntity
                {
                    Code = "width",
                    Type = ProductPropertyEntity.PropertyType.Decimal,
                    MinValue = 0,
                    UOM = "M",
                    DefaultValue = x.DefaultWidth
                });
            }

            if (x.DefaultLength.HasValue && x.DefaultLength > 0)
            {
                pList.Add(new ProductPropertyEntity
                {
                    Code = "length",
                    Type = ProductPropertyEntity.PropertyType.Decimal,
                    MinValue = 0,
                    UOM = "M",
                    DefaultValue = x.DefaultLength
                });
            }

            product.Properties = pList;

            return product;
        }

        private async Task<ProductEntity> GetSapPropreties(ProductEntity product)
        {
            var x = await _dbContext.OITM.Where(i => product.Code == i.ItemCode)
                .Select(SelectSapProperties).FirstOrDefaultAsync();

            return GetSapProperties(product, x);
        }


        protected static readonly Expression<Func<OITM, TempEntity>> SelectSapProperties =
            x => new TempEntity
            {
                ProductCode = x.ItemCode,
                DefaultHeight = x.SHeight1,
                DefaultWidth = x.SWidth1,
                DefaultLength = x.SLength1,
            };

        private static readonly Expression<Func<OITM, ProductEntity>> AsItemEntity =
            x => new ProductEntity
            {
                Code = x.ItemCode,
                GroupCode = Convert.ToInt16(x.ItmsGrpCod),
                Name = x.ItemName??"",
                NameForeign = x.FrgnName,
                Barcode = x.CodeBars,
                IsActive = x.validFor == "Y" && x.Canceled != "Y",
                IsForBuy = x.PrchseItem == "Y",
                IsForSell = x.SellItem == "Y",
                CreationDateTime = x.CreateTS.HasValue && x.CreateDate.HasValue ? x.CreateDate.Value
                    .AddSeconds( x.CreateTS.Value % 100)
                    .AddMinutes(( x.CreateTS.Value / 100) % 100)
                    .AddHours(( x.CreateTS.Value / 10000) % 10000) : x.CreateDate,
                
                LastUpdateDateTime = x.UpdateTS.HasValue && x.UpdateDate.HasValue ? x.UpdateDate.Value
                    .AddSeconds( x.UpdateTS.Value % 100)
                    .AddMinutes(( x.UpdateTS.Value / 100) % 100)
                    .AddHours(( x.UpdateTS.Value / 10000) % 10000) : x.UpdateDate,
                
   
                PictureUrl = x.PicturName,
                Description = x.UserText
            };


        private async Task GetPriceList(IEnumerable<ProductEntity> products)
        {
            var productsCodes = products.Select(x => x.Code);
            var pDic = products.ToDictionary(x => x.Code, x => x);
            var itm1 = await _dbContext.ITM1.Where(x => productsCodes.Contains(x.ItemCode)).ToListAsync();

            itm1.ToList().ForEach(x =>
            {
                var product = pDic[x.ItemCode];
                applayPriceList(product, x);
            });
        }

        private static void applayPriceList(ProductEntity product, ITM1 x)
        {
            if (x.PriceList == 2) //SELL PRICE LIST
            {
                if (product.SellPriceList == null)
                    product.SellPriceList = new Dictionary<string, decimal>();
                if (!string.IsNullOrEmpty(x.Currency))
                    product.SellPriceList.Add(x.Currency, x.Price.Value);
                if (!string.IsNullOrEmpty(x.Currency1))
                    product.SellPriceList.Add(x.Currency1, x.AddPrice1.Value);
                if (!string.IsNullOrEmpty(x.Currency2))
                    product.SellPriceList.Add(x.Currency2, x.AddPrice2.Value);
            }
            else //BUY PRICE LIST
            {
                if (product.BuyPriceList == null)
                    product.BuyPriceList = new Dictionary<string, decimal>();
                if (!string.IsNullOrEmpty(x.Currency))
                    product.BuyPriceList.Add(x.Currency, x.Price.Value);
                if (!string.IsNullOrEmpty(x.Currency1))
                    product.BuyPriceList.Add(x.Currency1, x.AddPrice1.Value);
                if (!string.IsNullOrEmpty(x.Currency2))
                    product.BuyPriceList.Add(x.Currency2, x.AddPrice2.Value);
            }
        }

        private async Task getPriceList(ProductEntity product)
        {
            var x = await _dbContext.ITM1.Where(i => i.ItemCode == product.Code).FirstOrDefaultAsync();

            applayPriceList(product, x);
        }

        protected class TempPriceList
        {
            public string ProductCode { get; set; }
        }

        protected class TempEntity
        {
            public string ProductCode { get; set; }
            public decimal? DefaultHeight { get; set; }
            public decimal? DefaultWidth { get; set; }
            public decimal? DefaultLength { get; set; }
        }
    }

    static class MockProperties
    {
        public static IEnumerable<ProductEntity> getMockProperties(this IEnumerable<ProductEntity> productEntities)
        {
            productEntities.ToList().ForEach(x => x.getMockProperties());
            return productEntities;
        }


        private static ProductEntity getMockProperties(this ProductEntity productEntity)
        {
            if (productEntity.Properties != null && productEntity.Properties.Count > 0)
                productEntity.Properties
                    .Add(new ProductPropertyEntity
                    {
                        Code = "units", Type = ProductPropertyEntity.PropertyType.Int, MinValue = 0, DefaultValue = 1
                    });
            else
                productEntity.Properties = mockProductPropertyEntites;

            var calString = "";
            productEntity.Properties.ForEach(x => calString += x.Code + "*");
            if (calString.Length > 0)
                calString = calString.Remove(calString.Length - 1);
            productEntity.AutoQuantityCalculationExpression = calString; // "units*length*height*width";
            return productEntity;
        }

        private static List<ProductPropertyEntity> mockProductPropertyEntites = new List<ProductPropertyEntity>
        {
            new ProductPropertyEntity
            {
                Code = "height", Type = ProductPropertyEntity.PropertyType.Decimal, MinValue = 0, UOM = "M",
                DefaultValue = 1
            },
            new ProductPropertyEntity
            {
                Code = "width", Type = ProductPropertyEntity.PropertyType.Decimal, MinValue = 0, UOM = "M",
                DefaultValue = 1
            },
            //new ProductPropertyEntity { Code = "length", Type = ProductPropertyEntity.PropertyType.Decimal, MinValue = 0, UOM = "M" ,DefaultValue = 1} ,
            new ProductPropertyEntity
                {Code = "units", Type = ProductPropertyEntity.PropertyType.Int, MinValue = 0, DefaultValue = 1},
        };
    }
}