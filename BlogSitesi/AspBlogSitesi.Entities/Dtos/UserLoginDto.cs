﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspBlogSitesi.Entities.Dtos
{
    public class UserLoginDto
    {
        [DisplayName("E-Posta")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(10, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(15, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(6, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
