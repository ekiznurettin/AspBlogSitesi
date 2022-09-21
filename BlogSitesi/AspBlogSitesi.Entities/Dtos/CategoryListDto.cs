using AspBlogSitesi.Core.Entities.Abstract;
using AspBlogSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspBlogSitesi.Entities.Dtos
{
  public  class CategoryListDto:DtoGetBase
    {
        public IList<Category>  Categories{ get; set; }
    }
}
