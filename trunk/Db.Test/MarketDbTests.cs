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

            var result = _marketDb.Get<Printer>(1);

            Assert.IsNotNull(result);
        }
    }
    public class BlogTestFixture : InMemoryDatabaseTest
    {
        public BlogTestFixture()
            : base(typeof(Blog).Assembly)
        {
        }

        [Test]
        public void CanSaveAndLoadBlog()
        {
            object id;

            using (var tx = session.BeginTransaction())
            {
                id = session.Save(new Blog
                {
                    AllowsComments = true,
                    CreatedAt = new DateTime(2000, 1, 1),
                    Subtitle = "Hello",
                    Title = "World",
                });

                tx.Commit();
            }

            session.Clear();


            using (var tx = session.BeginTransaction())
            {
                var blog = session.Get<Blog>(id);

                Assert.AreEqual(new DateTime(2000, 1, 1), blog.CreatedAt);
                Assert.AreEqual("Hello", blog.Subtitle);
                Assert.AreEqual("World", blog.Title);
                Assert.True(blog.AllowsComments);

                tx.Commit();
            }
        }
    }

    public class Blog
    {
        public virtual object Subtitle{ get; set; }

        public virtual bool AllowsComments { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual string Title { get; set; }
    }
}
