using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AspBlogSitesi.Entities.Concrete
{
    public  class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate{ get; set; }
        public string  BirthPlace { get; set; }
        public string Picture { get; set; }
        public int Gender { get; set; }

        public int Status { get; set; } = 2;

        public ICollection<Article> Articles { get; set; }
    }
}
