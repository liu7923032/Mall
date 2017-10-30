﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Mall.Domain.Entities;

namespace Mall.Category
{

    public interface ICategoryAppService: IAsyncCrudAppService<CategoryDto, int, GetAllCategoryInput, CreateCategoryInput, UpdateCategoryInput>
    {

    }

    
    public class CategoryAppService : AsyncCrudAppService<Mall_Category, CategoryDto, int, GetAllCategoryInput, CreateCategoryInput, UpdateCategoryInput>, ICategoryAppService
    {
        
        private IRepository<Mall_Category> _categoryRepository;
        public CategoryAppService(IRepository<Mall_Category> categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        protected override IQueryable<Mall_Category> CreateFilteredQuery(GetAllCategoryInput input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(!string.IsNullOrEmpty(input.Name), u => u.Name.Contains(input.Name));
        }
    }
}
