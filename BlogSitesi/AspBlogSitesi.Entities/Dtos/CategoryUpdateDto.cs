using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspBlogSitesi.Entities.Dtos
{
    public  class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Category Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string Description { get; set; }

        [DisplayName("Özel Not")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string Note { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        public bool IsActive { get; set; }

        [DisplayName("Silindi Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        public bool IsDeleted { get; set; }
    }
}
