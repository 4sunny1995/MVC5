using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        OnlineShopDbContext db = null;
        public OrderDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
            return entity.id;
        }
        public IEnumerable<Order> GetByUserID(long userID)
        {
            return db.Orders.Where(x=>x.userID==userID).ToList();
        }
        public Order GetByProductID(long ProductID)
        {
            return db.Orders.SingleOrDefault(x => x.productID == ProductID);
        }
        public Order GetByID(long ID)
        {
            return db.Orders.SingleOrDefault(x => x.id == ID);
        }
        public string Switch(int value)
        {
            switch (value)
            {
                case 0:return "đã giao";
                case 1:return "đang giao";
                case 2:return "đã hủy";
                default:return "đang xem xét";
            }
        }
        public IEnumerable<Order> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                
                model = model.Where(x => x.UserName.Contains(searchString) || x.productName.Contains(searchString));
            }
            /*||x.userID.ToString().Contains(searchString)||x.productID.ToString().Contains(searchString) ||Switch(x.Status).Contains(searchString.ToLower())*/
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Order> ListAllPagingUser(long userID)
        {
            IQueryable<Order> model = db.Orders.Where(x=>x.userID==userID);
            /*||x.userID.ToString().Contains(searchString)||x.productID.ToString().Contains(searchString) ||Switch(x.Status).Contains(searchString.ToLower())*/
            return model.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public bool Update(Order entity)
        {
            try
            {

                var order = db.Orders.Find(entity.id);
                
                order.userID = entity.userID;
                order.productID = entity.productID;
                order.Status = entity.Status;
                order.Total = entity.Total;
                order.Phone = entity.Phone;
                order.productName = entity.productName;
                order.UserName = entity.UserName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var order = GetByID(id);
                db.Orders.Remove(GetByID(id));
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
