using AspBlogSitesi.Core.DataAccess.Abstract;
using AspBlogSitesi.Entities.Concrete;

namespace AspBlogSitesi.DataAccess.Abstract
{
    public  interface IArticleRepository:IEntityRepository<Article>
    {
        
    }
}
