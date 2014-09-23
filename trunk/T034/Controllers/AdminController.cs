using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Db.DataAccess;
using Db.Entity;
using Db.Entity.Directory;

namespace T034.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMarketDb _marketDb;

        private string StorageRoot
        {
            get { return Path.Combine(Server.MapPath("~/Files")); }
        }

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
            //var subject = _marketDb.Get<Subject>(subjectid);
            var subject = new Subject();
            return View(subject);
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var r = new List<ViewDataUploadFilesResult>();
            foreach (string file in Request.Files)
            {
                var statuses = new List<ViewDataUploadFilesResult>();
                var headers = Request.Headers;
                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(Request, statuses);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], Request, statuses);
                }
                JsonResult result = Json(statuses);
                result.ContentType = "text/plain";
                return result;
            }
            return Json(r);
        }

        private void UploadPartialFile(string fileName, HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var file = request.Files[0];
            var inputStream = file.InputStream;
            var fullName = Path.Combine(StorageRoot, Path.GetFileName(fileName));
            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];
                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new ViewDataUploadFilesResult()
            {
                name = fileName,
                size = file.ContentLength,
                type = file.ContentType,
                url = "/Home/Download/" + fileName,
                delete_url = "/Home/Delete/" + fileName,
                thumbnail_url = @"data:image/png;base64," + EncodeFile(fullName),
                delete_type = "GET",
            });
        }

        private void UploadWholeFile(HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];
                var fullPath = Path.Combine(StorageRoot, Path.GetFileName(file.FileName));
                file.SaveAs(fullPath);
                statuses.Add(new ViewDataUploadFilesResult()
                {
                    name = file.FileName,
                    size = file.ContentLength,
                    type = file.ContentType,
                    url = "/Home/Download/" + file.FileName,
                    delete_url = "/Home/Delete/" + file.FileName,
                    thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath),
                    delete_type = "GET",
                });
            }
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }
    }
    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string delete_url { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_type { get; set; }
    }
}
