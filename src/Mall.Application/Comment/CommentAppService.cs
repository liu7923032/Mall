﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Mall.Domain.Entities;

namespace Mall.Comment
{

    #region 1.0 接口抽象
    public interface ICommentAppService : IAsyncCrudAppService<CommentDto, int, GetCommentsInput, CreateCommentInput, UpdateCommentInput>
    {

    }
    #endregion

    #region 2.0 具体实现
    [AbpAuthorize]
    public class CommentAppService : AsyncCrudAppService<Mall_Comment, CommentDto, int, GetCommentsInput, CreateCommentInput, UpdateCommentInput>, ICommentAppService
    {

        private IRepository<Mall_Comment> _commentRepository;
        private IRepository<Mall_Account, long> _accountRepository;
        public CommentAppService(IRepository<Mall_Comment> commentRepository, IRepository<Mall_Account, long> accountRepository) : base(commentRepository)
        {
            this._commentRepository = commentRepository;
            this._accountRepository = accountRepository;
        }

        protected override IQueryable<Mall_Comment> CreateFilteredQuery(GetCommentsInput input)
        {
            return base.CreateFilteredQuery(input)
                //通过productId来查询
                .WhereIf(input.ProductId.HasValue,u => u.ProductId.Equals(input.ProductId.Value));
        }


        public async override Task<PagedResultDto<CommentDto>> GetAll(GetCommentsInput input)
        {
            //1：筛选条件
            var comments = this.CreateFilteredQuery(input);
            //2：关联账户表
            var data = from a in comments
                       join b in _accountRepository.GetAll()
                       on a.CreatorUserId equals b.Id
                       select new CommentDto
                       {
                           Comment = a.Comment,
                           CreationTime = a.CreationTime,
                           CreatorUser = b.UserName,
                           Sex = b.Sex,
                           Id = a.Id,
                           CStatus = a.CStatus,
                           ProductId = a.ProductId
                       };
            //3:筛选
            var reuslt = data.OrderBy(u => u.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount);
            return await Task.FromResult(new PagedResultDto<CommentDto>() { Items = reuslt.ToList(), TotalCount = data.Count() });
        }
    }
    #endregion
}
