using Model.Dao;
using Model.EF;
using SunShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString,int page =1,int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(tblUser user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptMd5Pass = Encryptor.MD5Hash(user.Password);
                user.Password = encryptMd5Pass;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");

        }
        
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);

            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(tblUser user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptMd5Pass = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptMd5Pass;
                }
                
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập không thành công");
                }
            }
            return View("Index");

        }
        [HttpGet]
        public ActionResult Delete(long id)
        {
            var dao = new UserDao();
            var result = dao.Delete(id);
            if (result)
            {
                return RedirectToAction("Index", "User");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult setRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult setRole(string Username,string mod,bool status)
        {
            var dao = new UserDao();
            var id = dao.GetByUsername(Username).id;
            var result = dao.setRoleWithID(id,mod,status);
            if (result) return RedirectToAction("Index", "User");
            return View("Index");
        }
        public ActionResult Loggout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index","User");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        
        
    }
}