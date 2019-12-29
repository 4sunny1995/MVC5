using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunShop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index(string searchString,int page=1,int pageSize=10)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Order entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var result = dao.Insert(entity);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Order");
                }
                else ModelState.AddModelError("", "Thêm không thành công");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new OrderDao();
            var model = dao.GetByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var result = dao.Update(order);
                if (result) return RedirectToAction("Index", "Order");
                else ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return View("Index");
        }
        public ActionResult Delete(long id)
        {
            var dao = new OrderDao();
            var result = dao.Delete(id);
            if (result) return RedirectToAction("Index", "Order");
            else return View("Index");
        }
    }
}