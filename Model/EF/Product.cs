namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250), Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(50), Display(Name = "Mã sản phẩm")]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500), Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(250), Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        [ Display(Name = "Đơn giá")]
        public decimal? Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }
        [Display(Name = "Thuế VAT")]
        public bool? IncludeVAT { get; set; }
        [Display(Name = "Số lượng")]
        public int? Quantily { get; set; }
        
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext"), Display(Name = "Chi tiết")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50), Display(Name = "Người tạo")]
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

        public DateTime? TopHot { get; set; }
        [Display(Name = "Lượt xem")]
        public int? ViewCount { get; set; }
    }
}
