using AspBlogSitesi.Entities.Dtos;

namespace AspBlogSitesi.WebUI.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
        public UserUpdateDto UserUpdateDto{ get; set; }
        public UserDto UserDto{ get; set; }
        public string UserUpdatePartial{ get; set; }
    }
}
