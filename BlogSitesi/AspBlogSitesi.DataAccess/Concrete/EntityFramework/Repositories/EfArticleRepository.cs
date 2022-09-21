using AspBlogSitesi.Core.DataAccess.Concrete.EntityFramework;
using AspBlogSitesi.DataAccess.Abstract;
using AspBlogSitesi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AspBlogSitesi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        public EfArticleRepository(DbContext context) : base(context)
        {

        }
    }
}
