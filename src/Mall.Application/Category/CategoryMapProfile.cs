using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Category
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<CreateCategoryInput, Mall_Category>();
            CreateMap<Mall_Category, CategoryDto>();
            CreateMap<UpdateCategoryInput, Mall_Category>();
        }
    }
}
