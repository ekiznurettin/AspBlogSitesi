using AspBlogSitesi.Core.DataAccess.Abstract;
using AspBlogSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspBlogSitesi.DataAccess.Abstract
{
  public  interface ICommentRepository: IEntityRepository<Comment>
    {
    }
}
