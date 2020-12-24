using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Migrator.Model;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System;

namespace Migrator
{
    public class DbAdmin
    {
        public static void UpdateDb(Setting setting)
        {
            Console.WriteLine($"UpdateDb: '{setting.DbPath}'");

            var str = string.Format("Data Source={0};Version=3;", setting.DbPath);
            var cfg2 = Fluently.Configure()
                               .Database(SQLiteConfiguration.Standard.ConnectionString(str))
                               .ExposeConfiguration(c => c.Properties.Add("current_session_context_class",
                                                                          typeof(CallSessionContext).FullName))
                //.Mappings(x => x.FluentMappings.AddFromAssemblyOf<NewsMap>())
                               .Mappings(x => x.FluentMappings.AddFromAssembly(setting.Assembly))
                               .BuildConfiguration();

            ////обновим структуру
            var t = new SchemaUpdate(cfg2);
            t.Execute(true, true);
        }

        public static void ClearDb(Setting setting)
        {
            Console.WriteLine($"ClearDb: '{setting.DbPath}'");

            var str = string.Format("Data Source={0};Version=3;", setting.DbPath);
            var cfg2 = Fluently.Configure()
                               .Database(SQLiteConfiguration.Standard.ConnectionString(str))
                               .ExposeConfiguration(c => c.Properties.Add("current_session_context_class",
                                                                          typeof(CallSessionContext).FullName))
                //.Mappings(x => x.FluentMappings.AddFromAssemblyOf<NewsMap>())
                               .Mappings(x => x.FluentMappings.AddFromAssembly(setting.Assembly))
                               .BuildConfiguration();

            //очистим БД
            var t = new SchemaExport(cfg2);
            t.Execute(true, true, true);
        }
    }
}
