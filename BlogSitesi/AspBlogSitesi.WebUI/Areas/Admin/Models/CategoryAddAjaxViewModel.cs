using AspBlogSitesi.Entities.Dtos;

namespace AspBlogSitesi.WebUI.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto CategoryAddDto{ get; set; }
        public CategoryDto CategoryDto{ get; set; }
        public string CategoryAddPartial{ get; set; }
    }
}
