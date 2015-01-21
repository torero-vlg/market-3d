using System;
using System.Linq;
using Migrator.Model;

namespace Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any(a => a == "help" || a == "?"))
            {
                Console.WriteLine("Пример параметров:");
                Console.WriteLine("-task update -dll Db.dll");
                Console.WriteLine("-task clear -dll Db.dll");
                return;
            }


            try
            {
                var setting = new Setting();
                setting.Parse(args);

                if(setting.Task == Task.Clear)
                    DbAdmin.ClearDb(setting);
                if (setting.Task == Task.Update)
                    DbAdmin.UpdateDb(setting);
                
                Console.WriteLine("Операция выполнена успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении операции.");
            }
        }
    }
}
