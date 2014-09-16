using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Db.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UpdateDb();
                Console.WriteLine("Операция выполнена успешно.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении операции.");
            }

            Console.ReadLine();
        }

        public static void UpdateDb()
        {
            var str = string.Format("Data Source=t034.sqlite;Version=3;");
            var cfg2 = Fluently.Configure()
                               .Database(SQLiteConfiguration.Standard.ConnectionString(str))
                               .ExposeConfiguration(c => c.Properties.Add("current_session_context_class",
                                                                          typeof(CallSessionContext).FullName))
                               .Mappings(x => x.FluentMappings.AddFromAssemblyOf<NewsMap>())
                               .BuildConfiguration();

            var t = new SchemaUpdate(cfg2);
            t.Execute(true, true);
        }
    }
}
