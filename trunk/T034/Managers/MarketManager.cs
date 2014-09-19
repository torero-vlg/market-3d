using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Db;
using Db.DataAccess;
using Db.Entity;

namespace T034.Managers
{
    public class MarketManager
    {
        private readonly IBaseDb _db;

        public MarketManager(IBaseDb db)
        {
            _db = db;
        }

        public IBaseDb Db
        {
            get { return _db; }
        }

        public int AddSubject(Subject subject)
        {
            int id;
            using (var tran = _db.SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    id = _db.Save((Product)subject);

                    subject.Id = id;
                    _db.Save(subject);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw;
                }
            }
            return id;   
        }
    }
}