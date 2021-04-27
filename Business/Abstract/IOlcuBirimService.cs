using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOlcuBirimService
    {
        IResult Add(OlcuBirim olcuBirim);
        IResult Delete(OlcuBirim olcuBirim);
        IResult Update(OlcuBirim olcuBirim);
        IDataResult<OlcuBirim> GetById(int id);
        IDataResult<List<OlcuBirim>> GetAll();

        IResult CheckIfOlcuBirimExistsById(int id);
    }
}
