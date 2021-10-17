using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(300)]
        public string ProductName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        //Giá khuyến mãi cho phép null
        [Column(TypeName = "money")]
        public Nullable<decimal> PromotionPrice { get; set; }

        [Range(0,5000, ErrorMessage ="Quantity must be >=0!")]
        public long Quantity { get; set; }

        //Image gồm 1 ảnh chính và các ảnh khác
        [StringLength(300)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public DateTime? TopHot { get; set; }

        //Kích thước:
        //Bán kính mặt đồng hồ
        [Column(TypeName = "float")]
        public float FaceRadius { get; set; }

        //Độ dày của mặt đồng hồ
        [Column(TypeName = "float")]
        public float FaceThickness { get; set; }

        //Độ dài dây đồng hồ
        [Column(TypeName = "float")]
        public float WireLength { get; set; }

        //Thông tin người, thời gian tạo cũng như update sản phẩm

        public DateTime? CreatedDate { get; set; }

        [ForeignKey("CreatedPerson")]
        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("ModifiedPerson")]
        public int? ModifiedBy { get; set; }

        //Khóa ngoại 

        public int MaterialId { get; set; }
        public int ColorId { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }


        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual User CreatedPerson { get; set; }

        public virtual User ModifiedPerson { get; set; }

        public ICollection<OrderDetail> orderDetails { get; set; }

        public ICollection<Review> Reviews { get; set; }

        //a movie can belong to many genre
        //public virtual ICollection<Genre> Genres { get; set; }

        //public virtual ICollection<Actor> Actors { get; set; }
    }
}