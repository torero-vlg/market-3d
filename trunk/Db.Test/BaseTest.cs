using System;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Environment = NHibernate.Cfg.Environment;

namespace Db.Test
{
    public abstract class BaseTest
    {
        protected AbstractDbFactory DbFactory;

        protected BaseTest()
        {
            DbFactory = new NhDbFactory();
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

    public class InMemoryDatabaseTest : IDisposable
    {
        private readonly Assembly _assemblyContainingMapping;
        private static Configuration Configuration;
        private static ISessionFactory SessionFactory;
        protected ISession session;

        public InMemoryDatabaseTest(Assembly assemblyContainingMapping)
        {
            _assemblyContainingMapping = assemblyContainingMapping;
            //if (Configuration == null)
            //{
            //    Configuration = new Configuration()
            //        .SetProperty(Environment.ReleaseConnections, "on_close")
            //        .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
            //        .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
            //        .SetProperty(Environment.ConnectionString, "data source=:memory:")
            //        .SetProperty(Environment.ProxyFactoryFactoryClass, typeof(Blog).AssemblyQualifiedName)
            //        .AddAssembly(assemblyContainingMapping);

            //    SessionFactory = Configuration.BuildSessionFactory();
            //}

            //session = SessionFactory.OpenSession();

            //new SchemaExport(Configuration).Execute(true, true, true);
        }

        public void Dispose()
        {
            session.Dispose();
        }


        [SetUp]
        public void SetUp()
        {
            if (Configuration == null)
            {
                Configuration = new Configuration()
                    .SetProperty(Environment.ReleaseConnections, "on_close")
                    .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                    .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                    .SetProperty(Environment.ConnectionString, "data source=:memory:")
                    .SetProperty(Environment.ProxyFactoryFactoryClass, typeof(ProxyFactoryFactory).AssemblyQualifiedName)
                    .AddAssembly(_assemblyContainingMapping);

                SessionFactory = Configuration.BuildSessionFactory();
            }

            session = SessionFactory.OpenSession();

            new SchemaExport(Configuration).Execute(true, true, true);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
