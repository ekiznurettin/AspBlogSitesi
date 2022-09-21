using AspBlogSitesi.Entities.Dtos;

namespace AspBlogSitesi.WebUI.Areas.Admin.Models
{
    public class CategoryUpdateAjaxViewModel
    {
        public CategoryUpdateDto CategoryUpdateDto{ get; set; }
        public CategoryDto CategoryDto{ get; set; }
        public string CategoryUpdatePartial{ get; set; }
    }
}
