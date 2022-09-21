using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspBlogSitesi.Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string Name { get; set; }

        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string Surname { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        public string BirthDate { get; set; }

        [DisplayName("Doğum Yeri")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string BirthPlace { get; set; }

        [DisplayName("Cinsiyeti")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        public string Gender { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string UserName { get; set; }

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

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(13, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(13, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "Lütfen bir {0} seçiniz")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        public string Picture { get; set; }
    }
}
