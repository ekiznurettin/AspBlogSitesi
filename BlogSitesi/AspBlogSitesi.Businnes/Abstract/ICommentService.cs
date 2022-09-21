using AspBlogSitesi.Core.Utilities.Results.Abstract;
using AspBlogSitesi.Core.Utilities.Results.Concrete;
using System.Threading.Tasks;

namespace AspBlogSitesi.Businnes.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByNonDeleted();
    }
}
