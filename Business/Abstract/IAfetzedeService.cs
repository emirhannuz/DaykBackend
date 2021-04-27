using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAfetzedeService
    {

        IResult Add(Afetzede afetzede);
        IResult Delete(Afetzede afetzede);
        IResult Update(Afetzede afetzede);
        IDataResult<Afetzede> GetById(int id);
        IDataResult<Afetzede> GetByTc(string tc);
        IDataResult<List<Afetzede>> GetAll();
        IDataResult<List<AfetzedeDetayDto>> GetAllDetails();
    }
}
