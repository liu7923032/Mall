using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    /// <summary>
    /// 产品名称
    /// </summary>
    public class Mall_Product : FullAuditedEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(40)]
        public string ItemNo { get; set; }

        [StringLength(1000)]
        public string Describe { get; set; }

        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// 上传的主要图片
        /// </summary>
        [Required]
        public string ImgPic { get; set; }

        /// <summary>
        /// 商品的编号
        /// </summary>
        public string Skuid { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [StringLength(500)]
        public string LinkAddr { get; set; }

        /// <summary>
        /// 外键
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Mall_Category Category { get; set; }

        /// <summary>
        /// 销售梳理
        /// </summary>
        [Required]
        public int SaleNums { get; set; }

        /// <summary>
        /// 上架下架的状态
        /// </summary>
        public ProductStatus PStatus { get; set; }

        /// <summary>
        /// 一个产品有多个记录
        /// </summary>
        [NotMapped]
        public virtual ICollection<Mall_CartItem> CartItems { get; set; }

        /// <summary>
        /// 一个商品有多个评论
        /// </summary>
        [NotMapped]
        public virtual ICollection<Mall_Comment> Comments { get; set; }

        public Mall_Product()
        {
            Price = 0;
            IsDeleted = false;
            SaleNums = 0;
            //新建商品默认是上架状态
            PStatus = ProductStatus.Up;
        }
    }


    public enum ProductStatus
    {
        //下架
        Down = 0,
        //上架
        Up = 1
    }
}
