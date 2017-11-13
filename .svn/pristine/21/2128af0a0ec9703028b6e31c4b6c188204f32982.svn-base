using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Comment
{
    [AutoMapFrom(typeof(Mall_Comment))]
    public class CommentDto : UpdateCommentInput
    {

    }

    [AutoMapTo(typeof(Mall_Comment))]
    public class CreateCommentInput
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
    }


    public class UpdateCommentInput : CreateCommentInput, IEntityDto<int>
    {
        public int Id { get; set; }
    }


    public class GetCommentsInput
    {
        public int ProductId { get; set; }
    }
}
