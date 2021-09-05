using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CP.FinTech.SVO.Core.ProjectAggregate;
using CP.FinTech.SVO.Core.ProjectAggregate.Enum;
using CP.FinTech.SVO.Infrastructure.Data;
using CP.FinTech.SVO.Web.ApiModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CP.FinTech.SVO.Web
{
    public static class SeedData
    {

        public static readonly Tenant TestTenant1 = new Tenant
        {
            Id = 1,
            Name = "ООО \"Переработка остатков крупного рогатого скота\"",
            ShortName = "ООО \"Рога и копыта\"",
            Address = "135040, Челябинская область, город Чехов, спуск Косиора, 90",
            ActualAddress = "217221, Тульская область, город Серпухов, наб. Ленина, 69",
            Contacts = "+7(555) 562-45-45 rogov@net.biz",
            Inn = "8452150736",
            Kpp = "309445806",
            Ogrn = "9113863442937",
            orgType = OrgType.Org,
            WalletAddress = new[] { "hgjhgjhgjhgjh" },
            Contracts = new List<Contract>()
            {
                new Contract()
                {
                    Id =1,
                    Signature = Encoding.ASCII.GetBytes("hggasdgcfasgxcgZXGcGZxJKCZXZXXcZXJclKZJHXclkNZC"),
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddMonths(12),
                    Conssesion = 20,
                    RatePerSquareMeter = 1000,
                    RentalObjectId = Guid.NewGuid().ToString(),
                    WalletAddress = "qajhdaJKSHDAjsdhaskjdhkajsh",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Id = 1,
                            EthereumTransactionId = "aSasaSasASaSas",
                            Amount = 19,
                            Date = DateTime.Now,
                            Source ="sGHASDJKGasdgaSJKDHGAsjhdgaJ",
                            Destination = "ASGDJKAHGSDJAGHSJDHGHAJSHGDA"                            
                        },
                        new Transaction
                        {
                            Id = 2,
                            EthereumTransactionId = "aSasaSasASaSas",
                            Amount = 20,
                            Date = DateTime.Now.AddHours(-30),
                            Source ="sGHASDJKGasdgaSJKDHGAsjhdgaJ",
                            Destination = "ASGDJKAHGSDJAGHSJDHGHAJSHGDA"
                        }
                    }
                }

            }
        };
        public static readonly Tenant TestTenant2 = new Tenant
        {
            Id = 2,
            Name = "ИП Фролов Макар Никитич",
            ShortName = "ИП Фролов",
            Address = "925789, Рязанская область, город Шатура, спуск Домодедовская, 03",
            ActualAddress = "534146, Архангельская область, город Солнечногорск, наб. Косиора, 26",
            Contacts = "+7(666) 012-45-15 frolof@trest.bum",
            Inn = "256686264933",
            Kpp = "",
            Ogrn = "",
            orgType = OrgType.Ip,
            WalletAddress = new[] { "hgjhgjhgjhgjh" },
        };
      

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any TODO items.
                if (dbContext.Tenants.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);


            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Tenants)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();            
            dbContext.Tenants.Add(TestTenant1);
            dbContext.Tenants.Add(TestTenant2);

            dbContext.SaveChanges();
        }
    }
}
