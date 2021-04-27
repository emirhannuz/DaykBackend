using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        string StoragePath { get; set; }
        IDataResult<string> Add(IFormFile file);
        IResult Delete(string path);
    }
}
