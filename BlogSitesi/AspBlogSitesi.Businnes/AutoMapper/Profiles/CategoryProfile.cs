using AspBlogSitesi.Entities.Concrete;
using AspBlogSitesi.Entities.Dtos;
using AutoMapper;
using System;

namespace AspBlogSitesi.Businnes.AutoMapper.Profiles
{
    public  class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
