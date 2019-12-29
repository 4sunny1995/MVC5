using Model.Dao;
using SunShop.Area.Admin.Models;
using SunShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByUsername(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.id;
                    userSession.Name = user.Name;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0) ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                else if (result == -1) ModelState.AddModelError("", "Tài khoản đã bị khóa");
                else if (result==-2) ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
              
            }
            return View("Index");
        }
    }
}