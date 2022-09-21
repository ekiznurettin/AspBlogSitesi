using AspBlogSitesi.Entities.Dtos;

namespace AspBlogSitesi.WebUI.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        public UserAddDto UserAddDto{ get; set; }
        public UserDto UserDto{ get; set; }
        public string UserAddPartial{ get; set; }
    }
}
