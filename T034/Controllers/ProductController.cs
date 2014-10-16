using System.Linq;
using System.Web.Mvc;
using Db.DataAccess;
using Db.Entity;

namespace T034.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBaseDb _db;

        public ProductController()
        {
            _db = MvcApplication.DbFactory.CreateBaseDb();
        }

        public ActionResult SubjectList()
        {
            var subjects = _db.Select<Subject>();

            var list = subjects.Select(x=>(Product)x);
            
            return View("List", list);
        }

        public ActionResult PrinterList()
        {
            var subjects = _db.Select<Printer>();

            var list = subjects.Select(x => (Product)x);

            return View("List", list);
        }

        public ActionResult MaterialList()
        {
            var subjects = _db.Select<Material>();

            var list = subjects.Select(x => (Product)x);

            return View("List", list);
        }
    }
}
