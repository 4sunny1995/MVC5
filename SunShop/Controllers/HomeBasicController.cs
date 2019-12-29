using Model.Dao;
using Model.EF;
using SunShop.Area.Admin.Models;
using SunShop.Common;
using SunShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunShop.Controllers
{
    public class HomeBasicController : Controller
    {
        // GET: HomeBasic
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult BH()
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging("BH", 1, 12);
            return View("homePage", model);
        }
        [HttpGet]
        public ActionResult CH()
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging("CH", 1, 12);
            return View("homePage", model);
        }
        [HttpGet]
        public ActionResult LH()
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging("LH", 1, 12);
            return View("homePage", model);
        }
        [HttpGet]
        public ActionResult SP()
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging("SP", 1, 12);
            return View("homePage", model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
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
                    return RedirectToAction("homePage", "HomeBasic");
                }
                else if (result == 0) ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                else if (result == -1) ModelState.AddModelError("", "Tài khoản đã bị khóa");
                else if (result == -2) ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");

            }
            return View("Login");
        }
        public ActionResult homePage(string searchString,int page=1,int pageSize=12)
        {
            
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString,page,pageSize);
            return View(model);
        }
       
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblUser user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptMd5Pass = Encryptor.MD5Hash(user.Password);
                user.Password = encryptMd5Pass;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Login", "HomeBasic");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng ký không thành công");
                }
            }
            return View("Login");
        }
        public ActionResult Loggout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login", "HomeBasic");
        }
        public new ActionResult Profile(long id)
        {
            var dao1 = new OrderDao();
            var order = dao1.GetByUserID(id); 
            var dao = new UserDao();
            var user = dao.FindByID(id);
            var model = new UserOrder();
            model.User = user;
            model.Order = order.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new UserDao();
            var model = dao.FindByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblUser user)
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
                return RedirectToAction("homePage", "HomeBasic");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhập không thành công");
            }
            return View("Profile");
        }
            
    }
}