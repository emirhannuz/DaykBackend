using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStokCikisService
    {
        IResult Add(StokCikis stokCikis);
        IResult Delete(StokCikis stokCikis);
        IResult Update(StokCikis stokCikis);
        IResult StokCikisiOnayla(StokCikisOnay stokCikisForOnay);
        IResult StokCikisiTeslimEdildiOlarakİsaretle(StokCikisTeslim stokCikisForTeslim);
        IDataResult<StokCikis> GetById(int id);
        IDataResult<List<StokCikis>> GetByUrunId(int id);
        IDataResult<List<StokCikisDetayDto>> GetDetailsByOlcuBirimId(int olcuBirimId);
        IDataResult<List<StokCikisDetayDto>> GetByOnaylayanId(int id);
        IDataResult<List<StokCikisDetayDto>> GetByTeslimEdenId(int id);
        IDataResult<List<StokCikis>> GetAll();
        IDataResult<List<StokCikisDetayDto>> GetAllDetails();
        IDataResult<StokCikisDetayDto> GetDetailsById(int id);
        IDataResult<List<StokCikisDetayDto>> GetDetailsByAfetzedeId(int afetzedeId);
        int GetTotalStokCikisAdetByUrunId(int urunId);
    }
}

