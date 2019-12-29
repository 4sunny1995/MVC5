using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public Product GetByID(long id)
        {
            return db.Products.SingleOrDefault(x => x.ID == id);
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Product> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Code.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<Product> All()
        {
            return db.Products;
        }
        public bool Update(Product entity)
        {
            
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.Code = entity.Code;
                product.Description = entity.Description;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.Quantily = entity.Quantily;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                product.CreatedDate = entity.CreatedDate;
                product.CreatedBy = entity.CreatedBy;
                product.ModifiedDate = DateTime.Now;
                product.MeteKeywords = entity.MeteKeywords;
                product.Status = entity.Status;
                product.TopHot = entity.TopHot;
                product.ViewCount = entity.ViewCount;
                product.Avatar = entity.Avatar;
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
            var entity = GetByID(id);
            try
            {

                var product = db.Products.Find(entity.ID);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ChangeStatus(long id)
        {
            var product = db.Products.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

    }
}
