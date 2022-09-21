using AspBlogSitesi.Core.DataAccess.Concrete.EntityFramework;
using AspBlogSitesi.DataAccess.Abstract;
using AspBlogSitesi.DataAccess.Concrete.EntityFramework.Contexts;
using AspBlogSitesi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspBlogSitesi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetById(int categoryId)
        {
            return await BlogContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }
        private BlogContext BlogContext
        {
            get
            {
                return _context as BlogContext;
            }
        }
    }
}
