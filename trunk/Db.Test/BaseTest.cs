using System.Configuration;
using NUnit.Framework;

namespace Db.Test
{
    public abstract class BaseTest
    {
        protected AbstractDbFactory DbFactory;
        private static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["DatabaseFile"].ConnectionString; } }

        protected BaseTest()
        {
            DbFactory = new NhDbFactory(ConnectionString);
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
