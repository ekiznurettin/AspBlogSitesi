using AspBlogSitesi.Entities.Dtos;
using AspBlogSitesi.WebUI.Areas.Admin.Models;
using AutoMapper;

namespace AspBlogSitesi.WebUI.AutoMapper.Profiles
{
    public class ViewModelsProfile:Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleUpdateDto, ArticleUpdateViewModel>().ReverseMap();
        }
    }
}
