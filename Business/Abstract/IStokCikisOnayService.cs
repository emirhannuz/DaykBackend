using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStokCikisOnayService
    {
        IResult Add(StokCikisOnay stokCikisOnay);
        IResult Delete(StokCikisOnay stokCikisOnay);
        IResult Update(StokCikisOnay stokCikisOnay);
        IDataResult<StokCikisOnay> GetById(int id);
        IResult CheckIfStokCikisNotConfirmedByStokCikisId(int stokCikisId);
        IDataResult<List<StokCikisOnay>> GetAll();

    }
}
