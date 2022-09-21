using AspBlogSitesi.DataAccess.Abstract;
using AspBlogSitesi.DataAccess.Concrete.EntityFramework.Contexts;
using AspBlogSitesi.DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspBlogSitesi.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        private EfArticleRepository _articleReporitory = null;
        private EfCategoryRepository _categoryRepository=null;
        private EfCommentRepository _commentRepository=null;

        public UnitOfWork(BlogContext context)
        {
            _context = context;
        }

         public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public IArticleRepository Articles => _articleReporitory ?? new EfArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
