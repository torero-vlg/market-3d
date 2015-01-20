using System;
using Migrator.Model;

namespace Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.ReadLine();
        }
    }
}
