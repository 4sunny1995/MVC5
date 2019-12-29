using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(tblUser entity)
        {
            db.tblUsers.Add(entity);
            db.SaveChanges();
            return entity.id;
        }
        public int Login(string userName,string passWord)
        {
            var result = db.tblUsers.SingleOrDefault(x => x.UserName == userName);
            if (result ==null) return 0;
            else if (result.Status == false) return -1;
                else if (result.Password == passWord) return 1;
                else return -2;
        }

        public object Login(string userName, object password)
        {
            throw new NotImplementedException();
        }

        public tblUser GetByUsername(string userName)
        {
            return db.tblUsers.SingleOrDefault(x => x.UserName==userName);
        }
        public tblUser GetByName(string name)
        {
            return db.tblUsers.SingleOrDefault(x => x.Name == name);
        }
        public IEnumerable<tblUser> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<tblUser> model = db.tblUsers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString)||x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page,pageSize);
        }
        public bool Update(tblUser entity)
        {
            try
            {
                var user = db.tblUsers.Find(entity.id);
                user.Name = entity.Name;
                user.UserName = entity.UserName;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    
                    user.Password = entity.Password;
                }

                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedDate = DateTime.Now;
                user.Mod = entity.Mod;
                user.MeteKeywords = entity.MeteKeywords;
                user.MetaDesciptions = user.MetaDesciptions;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tblUser ViewDetail(int id)
        {
            return db.tblUsers.Find(id);
        }
        public tblUser FindByID(long ID)
        {
            return db.tblUsers.SingleOrDefault(x => x.id == ID);
        }
        public bool Delete(long id)
        {
            try
            {
                var user = FindByID(id);
                db.tblUsers.Remove(FindByID(id));
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool setRoleWithID(long id,string mod,bool status)
        {
            try
            {
                var user = FindByID(id);
                user.Mod = mod;
                user.Status = status;
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
            var user = db.tblUsers.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            
            return user.Status;
        }
    }
}
