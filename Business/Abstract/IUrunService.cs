using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUrunService
    {
        IResult Add(Urun urun);
        IResult Delete(Urun urun);
        IResult Update(Urun urun);
        IResult CheckIfUrunExistsById(int id);
        IDataResult<Urun> GetById(int id);
        IDataResult<List<Urun>> GetByTurId(int turId);
        IDataResult<List<Urun>> GetAll();
        IDataResult<List<UrunDetayDto>> GetAllDetails();
        IDataResult<UrunDetayDto> GetDetailById(int id);
    }
}
