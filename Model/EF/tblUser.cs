namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        public long id { get; set; }

        [StringLength(50), Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [StringLength(50), Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150), Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50), Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Người tạo")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string Mod { get; set; }

        [StringLength(250)]
        public string MeteKeywords { get; set; }

        [StringLength(250)]
        public string MetaDesciptions { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        [StringLength(150)]
        public string Avatar { get; set; }
        [StringLength(150)]
        public string Cover{get;set; }
    }
}
