using AspBlogSitesi.Core.Entities.Abstract;
using AspBlogSitesi.Entities.Concrete;

namespace AspBlogSitesi.Entities.Dtos
{
    public  class CategoryDto:DtoGetBase
    {
        public Category Category { get; set; }
    }
}
