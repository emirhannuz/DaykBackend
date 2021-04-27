using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers.Images
{
    public class ImageFileHelper : IImageFileHelper
    {
        public IConfiguration Configuration { get; }
        private ImageOptions _imageOptions;
        public string StoragePath { get; set; }
        public ImageFileHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _imageOptions = configuration.GetSection("ImageOptions").Get<ImageOptions>();
            StoragePath = Environment.CurrentDirectory + _imageOptions.Path; //currentDiretory kısmı silinebilir.
        }

        public IDataResult<string> Add(IFormFile formFile)
        {
            var result = HelperRules.Run(CheckIfAvailableFileExtension(formFile));
            if (result != null)
            {
                return new ErrorDataResult<string>(result.Message);
            }

            var path = WriteFileToFolderAsync(formFile);
            return new SuccessDataResult<string>(data: path.Result);

        }
        public async Task<string> WriteFileToFolderAsync(IFormFile formFile)
        {
            var sourcePath = Path.GetTempFileName();
            using (var stream = new FileStream(sourcePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            var newFileName = CreateNewFileName(formFile);
            var newFullPath = StoragePath + newFileName;
            File.Move(sourcePath, newFullPath);
            return _imageOptions.Path + newFileName;
        }

        public IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            return new SuccessResult();
        }



        private string CreateNewFileName(IFormFile formFile)
        {
            FileInfo fi = new FileInfo(formFile.FileName);
            string extension = fi.Extension;


            var fileName = Guid.NewGuid().ToString() + extension;
            return fileName;
        }

        private IDataResult<string> CheckIfAvailableFileExtension(IFormFile formFile)
        {
            var extensions = _imageOptions.Extensions; //new List<string> { ".jpg", ".jpeg", ".png" };
            FileInfo fi = new FileInfo(formFile.FileName);
            string fileExtension = fi.Extension;
            if (!extensions.Contains(fileExtension))
            {
                return new ErrorDataResult<string>(message: "Kabul edilmeyen dosya uzantısı.");
            }
            return new SuccessDataResult<string>();
        }
    }
}
