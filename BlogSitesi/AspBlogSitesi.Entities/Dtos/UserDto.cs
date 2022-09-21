using AspBlogSitesi.Core.Entities.Abstract;
using AspBlogSitesi.Entities.Concrete;

namespace AspBlogSitesi.Entities.Dtos
{
    public class UserDto:DtoGetBase
    {
        public User User{ get; set; }
    }
}
