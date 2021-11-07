using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WatchShop.Common;

namespace WatchShop.EntityFramework
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "Tên sản phẩm")]

        [StringLength(300)]
        public string ProductName { get; set; }
        [Display(Name = "Mô tả")]

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Giá")]

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        //Giá khuyến mãi cho phép null
        [Column(TypeName = "money")]
        public Nullable<decimal> PromotionPrice { get; set; }
        [Display(Name = "Giá bán chính thức")]
        public decimal? SalePrice {
            get
            {
                if(PromotionPrice==null)
                {
                    return Price;
                }    
                else
                {
                    return PromotionPrice;
                }    
            }
        }
        [Display(Name = "Giá gốc")]
        public string OldPrice
        {
            get
            {
                if (PromotionPrice == null)
                {
                    return PromotionPrice.ToString();
                }
                else
                {
                    return StringHelper.CurrencyFormat(Price);
                }
            }
        }
        [Display(Name = "Tồn kho")]
        [Range(0,5000, ErrorMessage ="Quantity must be >=0!")]
        public long Quantity { get; set; }

        //Image gồm 1 ảnh chính và các ảnh khác
        [StringLength(300)]
        [Display(Name = "Ảnh chính")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [Display(Name = "Các ảnh phụ")]
        public string MoreImages { get; set; }


        //Kích thước:
        [Display(Name = "Bán kính mặt")]
        //Bán kính mặt đồng hồ
        [Column(TypeName = "float")]
        public float FaceRadius { get; set; }

        [Display(Name = "Độ dày của mặt")]
        //Độ dày của mặt đồng hồ
        [Column(TypeName = "float")]
        public float FaceThickness { get; set; }

        [Display(Name = "Độ dài dây")]
        //Độ dài dây đồng hồ
        [Column(TypeName = "float")]
        public float WireLength { get; set; }

        //Thông tin người, thời gian tạo cũng như update sản phẩm
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Người tạo")]
        [ForeignKey("CreatedPerson")]
        public int? CreatedBy { get; set; }
        [Display(Name = "Người sửa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Ngày sửa")]
        [ForeignKey("ModifiedPerson")]
        public int? ModifiedBy { get; set; }

        //Khóa ngoại 
        [Display(Name = "Chất liệu")]
        public int MaterialId { get; set; }
        [Display(Name = "Màu sắc")]
        public int ColorId { get; set; }
        [Display(Name = "Nhà cung ứng")]
        public int SupplierId { get; set; }
        [Display(Name = "Loại")]
        public int CategoryId { get; set; }

        [Display(Name = "Chất liệu")]
        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }

        [Display(Name = "Màu sắc")]

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }

        [ForeignKey("SupplierId")]
        [Display(Name = "Nhà cung ứng")]
        public virtual Supplier Supplier { get; set; }
        [Display(Name = "Loại")]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual User CreatedPerson { get; set; }

        public virtual User ModifiedPerson { get; set; }

        public virtual ICollection<OrderDetail> orderDetails { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}