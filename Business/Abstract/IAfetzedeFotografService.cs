using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAfetzedeFotografService
    {
        IResult Add(int afetzedeId, IFormFile formFile);
        IResult Delete(AfetzedeFotograf afetzedeFotograf);
        IResult Update(AfetzedeFotograf afetzedeFotograf);

        IDataResult<AfetzedeFotograf> Get(AfetzedeFotograf afetzedeFotograf);
        IDataResult<List<AfetzedeFotograf>> GetAll();
        IDataResult<List<AfetzedeFotograf>> GetByAfetzedeId(int afetzedeId);
        IDataResult<AfetzedeFotograf> GetById(int id);


    }
}
