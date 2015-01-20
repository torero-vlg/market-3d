using System.Linq;
using System.Reflection;

namespace Migrator.Model
{
    public class Setting
    {
        public void Parse(string[] args)
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

        public Task Task { get; set; }
        public Assembly Assembly { get; set; }

        private void SetTask(string packType)
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

        private void SetAssembly(string path)
        {
            Assembly = Assembly.LoadFrom(path);
        }
    }
}
