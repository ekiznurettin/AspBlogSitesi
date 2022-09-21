using AspBlogSitesi.Core.Entities.Abstract;
using AspBlogSitesi.Core.Utilities.ComplexTypes;
using AspBlogSitesi.Entities.Concrete;

namespace AspBlogSitesi.Entities.Dtos
{
    public  class ArticleDto:DtoGetBase
    {
        public Article Article{ get; set; }
    }
}
