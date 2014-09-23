using System;
using Db.Entity;
using Db.Entity.Directory;
using Db.Tools;
using NHibernate;

namespace Db.DataAccess
{
    public class MarketDb : NhBaseDb, IMarketDb
    {
        public MarketDb(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {
        }

        public int AddSubject(Subject subject)
        {
            int result;
            using (var session = Factory.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        var product = new Product
                            {
                                Article = subject.Article,
                                Category = new Category{Id = subject.Category.Id},
                                Count = subject.Count,
                                Description = subject.Description,
                                Name = subject.Name,
                                Price = subject.Price
                            };
                        session.Save(product);

                        subject.Id = product.Id;
                        session.Save(subject);

                        tran.Commit();
                        result = subject.Id;
                    }
                    catch (Exception ex)
                    {
                        MonitorLog.WriteLog("Ошибка выполнения процедуры AddSubject : " + ex.Message, MonitorLog.typelog.Error, true);
                        tran.Rollback();
                        result = 0;
                    }
                }
            }
            return result;
        }
    }
}
