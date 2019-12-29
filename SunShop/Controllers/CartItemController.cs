using Model.Dao;
using Model.EF;
using SunShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SunShop.Common;
namespace SunShop.Controllers
{
    public class CartItemController : Controller
    {
        // GET: CartItem
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult Thanhtoan()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public JsonResult Update(string cartModel)
        {
            var JsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = JsonCart.SingleOrDefault(x => x.Product.ID==item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
                
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return RedirectToAction("Index", "CartItem");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult AddItem(long productID, int quantity)
        {
            var product = new ProductDao().ViewDetail(productID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productID))
                {
                    foreach(var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Đưa lại vào Session
                Session[CartSession] = list;
            }
            else
            {
                //Taọ mới Object
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Đẩy vào Session
                Session[CartSession] = list;
            }
            return Json(new { productID=productID, quantity= quantity });
        }
        
        [HttpPost]
        public ActionResult Thanhtoan(long userID)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            var dao = new OrderDao();
            var user = dao.GetByID(userID);
            foreach (var item in sessionCart)
            {
                Order temp = new Order();
                temp.userID = userID;
                temp.UserName = user.UserName;
                temp.productID = item.Product.ID;
                temp.productName = item.Product.Name;
                temp.Phone = user.Phone;
                temp.Address = user.Address;
                temp.CreatedDate = DateTime.Now;
                decimal? res=0;
                if (item.Product.PromotionPrice == null)
                {
                    res = item.Product.Price;
                }
                else res = item.Product.PromotionPrice;
                temp.Total = res;
                dao.Insert(temp);
            }
            return View("ThongBao");
        }
        public ActionResult Orders(long userID)
        {
            
            var dao = new OrderDao();
            var model = dao.GetByUserID(userID);
            return View(model);
        }
    }
}