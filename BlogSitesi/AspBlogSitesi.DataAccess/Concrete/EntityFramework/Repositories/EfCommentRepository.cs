using AspBlogSitesi.Core.DataAccess.Concrete.EntityFramework;
using AspBlogSitesi.DataAccess.Abstract;
using AspBlogSitesi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AspBlogSitesi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public EfCommentRepository(DbContext context) : base(context)
        {
        }
    }
}
