using AspBlogSitesi.Core.Utilities.ComplexTypes;
using AspBlogSitesi.Core.Utilities.Extensions;
using AspBlogSitesi.Core.Utilities.Results.Abstract;
using AspBlogSitesi.Core.Utilities.Results.Concrete;
using AspBlogSitesi.Entities.ComplexTypes;
using AspBlogSitesi.Entities.Dtos;
using AspBlogSitesi.WebUI.Helpers.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AspBlogSitesi.WebUI.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private readonly string imgFolder = "image";
        private const string userImagesFolder = "userImages";
        private const string postImagesFolder = "postImages";

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/Admin/{imgFolder}/", pictureName);
            if (File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
            }
            return new DataResult<ImageDeletedDto>(ResultStatus.Error, "Böyle bir dosya bulunamadı", null);
        }

        public async Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null)
        {
            folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;

            if (!Directory.Exists($"{_wwwroot}/Admin/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/Admin/{imgFolder}/{folderName}");
            }
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string newFileName = $"{name}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{_wwwroot}/Admin/{imgFolder}/{folderName}", newFileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }
            string message = pictureType == PictureType.User ? $"{name} adlı kullanıcının resmi başarıyla yuklenmiştir." : $"{name} adlı makalenin resmi başarıyla yuklenmiştir.";
            return new DataResult<ImageUploadedDto>(ResultStatus.Success, message, new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            });
        }
    }
}
