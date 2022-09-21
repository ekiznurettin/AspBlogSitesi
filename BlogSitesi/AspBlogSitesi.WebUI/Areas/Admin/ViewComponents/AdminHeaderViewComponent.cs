using AspBlogSitesi.Entities.Concrete;
using AspBlogSitesi.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AspBlogSitesi.WebUI.Areas.Admin.ViewComponents
{
    public class AdminHeaderViewComponent: ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public AdminHeaderViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public ViewViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var roles = _userManager.GetRolesAsync(user).Result;
            return View(new UserWithRolesViewModel
            {
                User = user,
                Roles = roles
            });
        }
    }
}
