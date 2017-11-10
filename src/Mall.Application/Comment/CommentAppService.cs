using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Mall.Domain.Entities;

namespace Mall.Comment
{

    #region 1.0 接口抽象
    public interface ICommentAppService : IAsyncCrudAppService<CommentDto, int, GetCommentsInput, CreateCommentInput, UpdateCommentInput>
    {

    }
    #endregion

    #region 2.0 具体实现
    public class CommentAppService : AsyncCrudAppService<Mall_Comment, CommentDto, int, GetCommentsInput, CreateCommentInput, UpdateCommentInput>, ICommentAppService
    {

        private IRepository<Mall_Comment> _commentRepository;
        public CommentAppService(IRepository<Mall_Comment> commentRepository) : base(commentRepository)
        {
            this._commentRepository = commentRepository;
        }

        protected override IQueryable<Mall_Comment> CreateFilteredQuery(GetCommentsInput input)
        {
            return base.CreateFilteredQuery(input)
                //通过productId来查询
                .Where(u => u.ProductId.Equals(input.ProductId));
        }
    } 
    #endregion
}
