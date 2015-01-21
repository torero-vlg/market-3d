using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly IBaseDb _db;

        public AdminController()
        {
            _db = MvcApplication.DbFactory.CreateBaseDb();
        }

        public ActionResult GoodsList()
        {
            var items = _db.Select<Goods>();
            return View(items);
        }

        [HttpGet]
        //[AuthorizeUser]
        public ActionResult AddGoods()
        {
            return View();
        }

        [HttpGet]
        //[AuthorizeUser]
        public ActionResult AddGoodsDetail(int goodsId)
        {
            return View(new GoodsDetail { Goods = new Goods { Id = goodsId } });
        }

        /// <summary>
        /// PurposeList = SelectListItems<Purpose>(), TechnologyList = SelectListItems<Technology>()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private IEnumerable<SelectListItem> SelectListItems<T>() where T : DirectoryEntity
        {
            var purposes = _db.Select<T>().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            return purposes;
        }

        public ActionResult AddGoods(Goods item)
        {
            var result = _db.Save(item);

            return RedirectToAction("Goods", new {id = result});
        }

        public ActionResult AddGoodsDetail(GoodsDetail item)
        {
            var result = _db.Save(item);

            return RedirectToAction("Goods", new { id = item.Goods.Id });
        }


        public ActionResult Goods(int id)
        {
            var item = _db.Get<Goods>(id);
            return View(item);
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
