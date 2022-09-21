using AspBlogSitesi.Core.Utilities.ComplexTypes;

namespace AspBlogSitesi.Core.Entities.Abstract
{
    public class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
