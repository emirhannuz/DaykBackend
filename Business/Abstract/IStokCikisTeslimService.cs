using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStokCikisTeslimService
    {
        IResult Add(StokCikisTeslim stokCikisTeslim);
        IResult Delete(StokCikisTeslim stokCikisTeslim);
        IResult Update(StokCikisTeslim stokCikisTeslim);
        IDataResult<StokCikisTeslim> GetById(int id);
        IResult CheckIfStokCikisNotDeliveredByStokCikisId(int stokCikisId);
        IDataResult<List<StokCikisTeslim>> GetAll();
    }
}

