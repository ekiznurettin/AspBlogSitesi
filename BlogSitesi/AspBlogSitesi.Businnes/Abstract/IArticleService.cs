using AspBlogSitesi.Core.Utilities.Results.Abstract;
using AspBlogSitesi.Entities.Concrete;
using AspBlogSitesi.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspBlogSitesi.Businnes.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> GetAsync(int articleyId);
        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleyId);
        Task<IDataResult<ArticleListDto>> GetAllAsync();
        Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync(int categoryId);
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<ArticleDto>> AddAsync(ArticleAddDto articleAddDto, string createdByName,int userId);
        Task<IDataResult<ArticleDto>> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IDataResult<ArticleDto>> DeleteAsync(int articleId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int articleId);
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByNonDeleted();

    }
}
