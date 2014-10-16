using NUnit.Framework;

namespace Db.Test
{
    public abstract class BaseTest
    {
        protected AbstractDbFactory DbFactory;

        protected BaseTest()
        {
            DbFactory = new NhDbFactory("/t034_test.sqlite");
        }

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
