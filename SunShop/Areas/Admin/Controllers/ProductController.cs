using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SunShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString,int page=1,int pageSize=5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Insert(entity);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else ModelState.AddModelError("", "Thêm không thành công");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit( long id)
        {
            var dao = new ProductDao();
            var model = dao.GetByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result) return RedirectToAction("Index", "Product");
                else ModelState.AddModelError("","Cập nhật không thành công");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Details(long id)
        {
            var dao = new ProductDao();
            var model = dao.GetByID(id);
            return View(model);
        }
        public ActionResult Delete(long id)
        {
            var dao = new ProductDao();
            var result = dao.Delete(id);
            if (result) return RedirectToAction("Index", "Product");
            else return View("Index");
        }
        [HttpPost]
        public void Upload(string code)
        {

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Assets/Client/img/"+code+"/"), fileName);
                file.SaveAs(path);
            }
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for(int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string filename;
                        if(Request.Browser.Browser.ToUpper()=="IE"||Request.Browser.Browser.ToUpper()== "INTERNETEXPLORER")
                        {
                            string[] tempFiles =file.FileName.Split(new char[]{ '\\'});
                            filename = tempFiles[tempFiles.Length - 1];
                        }
                        else
                        {
                            filename = file.FileName;
                        }
                        filename = Path.Combine(Server.MapPath("~/Uploads/"),filename + DateTime.Now.ToString());
                        file.SaveAs(filename);
                    }
                    return Json("Upload is successlly!!!");
                }
                catch (Exception ex)
                {
                    return Json("Có lỗi xảy ra trong quá trình xử lý");
                }
            }
            return Json("Không tìm thấy file đã chọn.");
        }
       /// [HttpPost]
        public string ProcessUpload(HttpPostedFileBase file)
        {
            //valiadator
            //Save image Server
            string tmpname = file.FileName;
            string[] temp = new string[2];
            temp = tmpname.Split('.');
            string datetime = DateTime.Now.ToString();
            string resdatetime;
            resdatetime = datetime.Replace(':','_');
            resdatetime = resdatetime.Replace('/', '_');

            /*
            for (int i = 0; i < tmpdatetime.Length; i++)
            {
                processDateTime = processDateTime + '_' + tmpdatetime[i];
            }*/
            string fileName = temp[0]  + resdatetime+ '.' + temp[1];
            string path = Server.MapPath("~/Assets/Client/img/Upload/" + fileName).ToString();
            file.SaveAs(path);
            
            
            return fileName;

        }
    }
}