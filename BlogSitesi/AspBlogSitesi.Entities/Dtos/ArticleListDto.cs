using AspBlogSitesi.Core.Entities.Abstract;
using AspBlogSitesi.Entities.Concrete;
using System.Collections.Generic;

namespace AspBlogSitesi.Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}
