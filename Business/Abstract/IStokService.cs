using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStokService
    {
        IResult Add(Stok stok);
        IResult Delete(Stok stok);
        IResult Update(Stok stok);
        IDataResult<Stok> GetById(int id);
        IDataResult<Stok> GetByUrunId(int urunId);
        IDataResult<List<Stok>> GetByKayitYapanId(int kayitYapanId);
        IDataResult<List<Stok>> GetAll();

        IDataResult<List<StokDetayDto>> GetAllStokDetail();
        IDataResult<StokDetayDto> GetStokDetailById(int id);

        IResult CheckIfStokAdetEnough(int urunId, int stokAdet);
        IResult CheckIfStokExistsById(int id);
    }
}
