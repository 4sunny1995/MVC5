namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long id { get; set; }
        [Display(Name ="ID khách hàng")]
        public long? userID { get; set; }

        [StringLength(150), Display(Name = "Tên khách hàng")]
        public string UserName { get; set; }
        [Display(Name = "ID sản phẩm")]
        public long? productID { get; set; }

        [StringLength(150), Display(Name = "Tên sản phẩm")]
        public string productName { get; set; }
        [Display(Name = "Tình trạng")]
        public int Status { get; set; }
        [Display(Name = "Ngày đặt hàng")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(15), Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal? Total { get; set; }
        [StringLength(250),Display(Name ="Địa chỉ")]
        public string Address { get; set; }
    }
}
