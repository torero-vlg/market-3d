using System;
using System.Linq;
using System.Reflection;
using Migrator.Model;

namespace Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (args.Any(a => a == "help" || a == "?"))
            {
                Console.WriteLine("Пример параметров:");
                Console.WriteLine("-task update -dll Db.dll");
                Console.WriteLine("-task clear -dll Db.dll");
                return;
            }

            var setting = new Setting();

            try
            {
                setting.Parse(args);
                Console.WriteLine($"{setting}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении параметров.\r\n" + ex);
            }

            try
            {
                if(setting.Task == Task.Clear)
                    DbAdmin.ClearDb(setting);
                if (setting.Task == Task.Update)
                    DbAdmin.UpdateDb(setting);
                
                Console.WriteLine("Операция выполнена успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении операции.\r\n" + ex);
                Console.WriteLine("InnerException:\r\n" + ex.InnerException);
                if(ex.InnerException is ReflectionTypeLoadException)
                {
                    Console.WriteLine("ReflectionTypeLoadException:");
                    foreach (var loaderEx in (ex.InnerException as ReflectionTypeLoadException).LoaderExceptions)
                    {
                        Console.WriteLine(loaderEx.Message);
                    }
                }
            }
        }
    }
}
