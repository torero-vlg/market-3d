using System.Web.Mvc;
using Db.Entity;
using T034.Managers;

namespace T034.Controllers
{
    public class AdminController : Controller
    {
        private readonly MarketManager _manager;

        public AdminController()
        {
            _manager = new MarketManager(MvcApplication.Db);
        }

        public ActionResult SubjectList()
        {
            var subjects = MvcApplication.Db.Select<Subject>();
            return View(subjects);
        }

        [HttpGet]
        //[AuthorizeUser]
        public ActionResult AddSubject()
        {
            return View();
        }

        public ActionResult AddSubject(Subject subject)
        {
            var result = _manager.AddSubject(subject);
            return RedirectToAction("Subject", new {subjectId = result});
        }

        public ActionResult Subject(int subjectid)
        {
            var subject = _manager.Db.Get<Subject>(subjectid);
            return View(subject);
        }
    }
}
