using Db.Entity;
using NUnit.Framework;

namespace Db.Test
{
    public class MarketDbTests : BaseTest
    {
        [Test]
        public void GetSunbjectTest()
        {
            var marketDb = DbFactory.CreateMarketDb();

            var subject = marketDb.Get<Product>(1);

            Assert.IsNotNull(subject);
        }
    }
}
