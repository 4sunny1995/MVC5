using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunShop.Models
{
    [Serializable]
    public class UserOrder
    {
        public tblUser User { get; set; }
        public List<Order> Order { get; set; }
    }
}