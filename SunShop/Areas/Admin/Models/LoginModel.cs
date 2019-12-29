﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SunShop.Area.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = " Mời nhập tên tài khoản")]
        public string UserName { set; get; }
        [Required(ErrorMessage = " Mời nhập mật khẩu")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }

    }
}