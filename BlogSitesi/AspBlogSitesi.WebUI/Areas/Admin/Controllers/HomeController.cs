using AspBlogSitesi.Businnes.Abstract;
using AspBlogSitesi.Core.Utilities.ComplexTypes;
using AspBlogSitesi.Entities.Concrete;
using AspBlogSitesi.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AspBlogSitesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;
        private readonly IArticleService _articleService;

        public HomeController(ICategoryService categoryService, ICommentService commentService, UserManager<User> userManager, IArticleService articleService)
        {
            _categoryService = categoryService;
            _commentService = commentService;
            _userManager = userManager;
            _articleService = articleService;
        }
    
        public async Task<IActionResult> Index()
        {
            var categoriesCountResult = await _categoryService.CountByNonDeleted();
            var articlesCountResult = await _articleService.CountByNonDeleted();
            var commentsCountResult = await _commentService.CountByNonDeleted();
            var usersCountResult = await _userManager.Users.CountAsync();
            var articlesResult = await _articleService.GetAllAsync();
            if(categoriesCountResult.ResultStatus == ResultStatus.Success && articlesCountResult.ResultStatus == ResultStatus.Success && commentsCountResult.ResultStatus == ResultStatus.Success && articlesResult.ResultStatus == ResultStatus.Success && usersCountResult > -1)
            {
               return View(new DashboardViewModel
                {
                   CategoriesCount = categoriesCountResult.Data,
                   ArticlesCount = articlesCountResult.Data,
                   CommentsCount = commentsCountResult.Data,
                   Articles = articlesResult.Data,
                   UsersCount = usersCountResult
                });
            }
            return NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
    }
}
