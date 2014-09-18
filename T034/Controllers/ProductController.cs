using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Db.Entity;
using Db.Entity.Directory;

namespace T034.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult SubjectList()
        {
            var subjects = new List<Subject>
                {
                    new Subject
                        {
                            Article = "1231",
                            Category = new Category {Name = "3D объекты"},
                            Count = 5,
                            Name = "Подставка для планшета",
                            Description = "Подставка для планшета",
                            Price = 150
                        },
                    new Subject
                        {
                            Article = "02030005 ",
                            Category = new Category {Name = "3D объекты"},
                            Count = 5,
                            Name = "Удобный держатель для наушников ",
                            Description = "Удобный держатель для наушников ",
                            Price = 120
                        }
                };
            var list = subjects.Select(x=>(Product)x);


            return View("List", list);
        }

        public ActionResult PrinterList()
        {
            var subjects = new List<Printer>
                {
                    new Printer
                        {
                            Article = "435453",
                            Category = new Category {Name = "3D принтеры"},
                            Count = 5,
                            Name = "Принтер",
                            Description = "Принтере опимсание",
                            Price = 150000
                        }
                };
            var list = subjects.Select(x => (Product)x);

            return View("List", list);
        }

        public ActionResult MaterialList()
        {
            var subjects = new List<Material>
                {
                    new Material()
                        {
                            Article = "547668786534",
                            Category = new Category {Name = "Пластик"},
                            Count = 5,
                            Name = "Белый АБС пластик ",
                            Description = "Акрилонитрилбутадиенстирол, или просто АБС. «ударопрочная техническая термопластическая смола на основе сополимера акрилонитрила с бутадиеном и стиролом (название пластика образовано из начальных букв наименований мономеров)».",
                            Price = 900
                        }
                };
            var list = subjects.Select(x => (Product)x);

            return View("List", list);
        }
    }
}
