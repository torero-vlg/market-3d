using System;
using Db.DataAccess;
using Db.Entity;
using Db.Entity.Directory;
using NUnit.Framework;

namespace Db.Test
{
    public class MarketDbTests : BaseTest
    {
        private readonly IMarketDb _marketDb;

        public MarketDbTests()
        {
            _marketDb = DbFactory.CreateMarketDb();
        }

        [Test]
        public void AddPrinterTest()
        {
            var printer = new Printer
                {
                    Name = "erterter",
                    Category = new Category {Id = 1},
                    Area = "123",
                    Count = 100,
                    Article = "45646",
                    Description = "8878787",
                    Diametr = 45,
                    HasDisplay = true,
                    Price = 450000,
                    Printhead = 4,
                    Purpose = new Purpose { Id = 1 },
                    Technology = new Technology { Id = 1 },
                    Weight = 500
                };

            var id = _marketDb.AddPrinter(printer);
            Assert.IsNotNull(id);

            var result = _marketDb.Get<Printer>(id);

            Assert.IsNotNull(result);
        }
    }
}
