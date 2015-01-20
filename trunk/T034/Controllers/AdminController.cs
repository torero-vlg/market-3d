using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Db.DataAccess;
using Db.Entity;
using Db.Entity.Directory;
using T034.Models;
using T034.Tools.FileUpload;
using T034.ViewModel;

namespace T034.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBaseDb _db;

        public AdminController()
        {
            _db = MvcApplication.DbFactory.CreateBaseDb();
        }

        public ActionResult SubjectList()
        {
            var subjects = _db.Select<Subject>();
            return View(subjects);
        }

        public ActionResult PrinterList()
        {
            var subjects = _db.Select<Printer>();
            return View("PrinterList", subjects);
        }

        public ActionResult MaterialList()
        {
            var subjects = _db.Select<Material>();
            return View(subjects);
        }

        [HttpGet]
        //[AuthorizeUser]
        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpGet]
        //[AuthorizeUser]
        public ActionResult AddPrinter()
        {
            var model = new PrinterViewModel
                {
                    PurposeList = SelectListItems<Purpose>(),
                    TechnologyList = SelectListItems<Technology>()
                };
            return View(model);
        }

        private IEnumerable<SelectListItem> SelectListItems<T>() where T : DirectoryEntity
        {
            var purposes = _db.Select<T>().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            return purposes;
        }

        [HttpGet]
        //[AuthorizeUser]
        public ActionResult AddMaterial()
        {
            var model = new MaterialViewModel
            {
                MaterialTypeList = SelectListItems<MaterialType>()
            };
            return View(model);
        }

        public ActionResult AddSubject(Subject subject)
        {
            subject.Category = new Category { Id = 2 };
            var result = _db.Save(subject);

            return RedirectToAction("Subject", new {id = result});
        }

        public ActionResult AddPrinter(PrinterViewModel subject)
        {
            subject.Category = new Category { Id = 1 };

            var result = _db.Save(subject.ToModel());

            return RedirectToAction("Printer", new { id = result });
        }

        public ActionResult AddMaterial(MaterialViewModel subject)
        {
            subject.Category = new Category { Id = 3 };
            var result = _db.Save(subject.ToModel());

            return RedirectToAction("Material", new { id = result });
        }

        public ActionResult Subject(int id)
        {
            var subject = _db.Get<Subject>(id);
            return View(subject);
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var path = Path.Combine(Server.MapPath("~/Files"));
            var model = FileUploadModel.ParseParam(Request.Files.Keys[0]);
            path = Path.Combine(path, model.Category, model.Id);
            var uploader = new Uploader(path);

            var r = new List<ViewDataUploadFilesResult>();
            if (Request.Files.Cast<string>().Any())
            {
                var statuses = new List<ViewDataUploadFilesResult>();
                var headers = Request.Headers;
                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    uploader.UploadWholeFile(Request, statuses);
                }
                else
                {
                    uploader.UploadPartialFile(headers["X-File-Name"], Request, statuses);
                }
                JsonResult result = Json(statuses);
                result.ContentType = "text/plain";
                return result;
            }
            return Json(r);
        }

        public ActionResult Material(int id)
        {
            var subject = _db.Get<Material>(id);
            return View(subject);
        }

        public ActionResult Printer(int id)
        {
            var subject = _db.Get<Printer>(id);
            return View(subject);
        }
    }
}
