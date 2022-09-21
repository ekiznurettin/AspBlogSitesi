using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspBlogSitesi.Core.Utilities.ComplexTypes
{
    public enum ResultStatus
    {
        Success = 0,
        Error = 1,
        Warning = 2,
        Info = 3
    }
    public enum Gender
    {
        [Display(Name = "Erkek")]
        Male = 1,
        [Display(Name ="Kadın")]
        Female =2,
    }
    public enum Status
    {
        [Display(Name = "Aktif")]
        Active = 1,
        [Display(Name = "Pasif")]
        Passive = 2,
    }
}
