using AspBlogSitesi.Core.Entities.Abstract;
using AspBlogSitesi.Entities.Concrete;
using System.Collections;
using System.Collections.Generic;

namespace AspBlogSitesi.Entities.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users{ get; set; }
    }
}
