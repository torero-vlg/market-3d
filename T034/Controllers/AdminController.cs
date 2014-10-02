using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Db.DataAccess;
using Db.Entity;
using Db.Entity.Directory;
using T034.Models;
using T034.Tools.FileUpload;

namespace T034.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMarketDb _marketDb;

        public AdminController()
        {
            _marketDb = MvcApplication.DbFactory.CreateMarketDb();
        }

        public ActionResult SubjectList()
        {
            var subjects = _marketDb.Select<Subject>();
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
            subject.Category = new Category { Id = 2 };
            var result = _marketDb.AddSubject(subject);


            return RedirectToAction("Subject", new {subjectId = result});
        }

        public ActionResult Subject(int subjectid)
        {
            var subject = _marketDb.Get<Subject>(subjectid);
            //var subject = new Subject();
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
    }
}
