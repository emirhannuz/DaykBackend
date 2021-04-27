using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITurService
    {
        IResult Add(Tur tur);
        IResult Delete(Tur tur);
        IResult Update(Tur tur);
        IDataResult<Tur> GetById(int id);
        IDataResult<List<Tur>> GetAll();
        IResult CheckIfTurExistsById(int id);
    }
}
