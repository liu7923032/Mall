using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    /// <summary>
    /// 对商品的评论
    /// </summary>
    public class Mall_Comment : CreationAuditedEntity
    {
        /// <summary>
        /// 评论的状态
        /// </summary>
        [Required]
        public CommentStatus CStatus { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Mall_Product Product { get; set; }
    }

    public enum CommentStatus
    {
        /// <summary>
        /// 踩
        /// </summary>
        Tread = 0,
        /// <summary>
        /// 赞
        /// </summary>
        Praise
    }
}
