using System;
using System.Linq;
using System.Reflection;

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
                Parse(args);

                if(Task == Task.Clear)
                    ClearDb();
                if (Task == Task.Update)
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
                               //.Mappings(x => x.FluentMappings.AddFromAssemblyOf<NewsMap>())
                               .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly))
                               .BuildConfiguration();

            ////обновим структуру
            var t = new SchemaUpdate(cfg2);
            t.Execute(true, true);
        }

        public static void ClearDb()
        {
            var str = string.Format("Data Source=t034.sqlite;Version=3;");
            var cfg2 = Fluently.Configure()
                               .Database(SQLiteConfiguration.Standard.ConnectionString(str))
                               .ExposeConfiguration(c => c.Properties.Add("current_session_context_class",
                                                                          typeof(CallSessionContext).FullName))
                                //.Mappings(x => x.FluentMappings.AddFromAssemblyOf<NewsMap>())
                               .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly))
                               .BuildConfiguration();

            //очистим БД
            var t = new SchemaExport(cfg2);
            t.Execute(true, true, true);
        }


#region Перенести в другой класс
        
        public static void Parse(string[] args)
        {
            for (var i = 0; i < args.Count(); i++)
            {
                if (args.Count() > i + 1)
                    switch (args[i])
                    {
                        case "-task":
                            SetTask(args[i + 1]);
                            break;
                        case "-dll":
                            SetAssembly(args[i + 1]);
                            break;
                    }
            }
        }

        protected static Task Task { get; set; }
        protected static Assembly Assembly { get; set; }

        private static void SetTask(string packType)
        {
            switch (packType)
            {
                case "clear":
                    Task = Task.Clear;
                    break;
                case "update":
                    Task = Task.Update;
                    break;
            }
        }

        private static void SetAssembly(string path)
        {
            Assembly = Assembly.LoadFrom(path);
        }
#endregion

    }

    public enum Task
    {
        Clear = 0,
        Update = 1
    };

}
