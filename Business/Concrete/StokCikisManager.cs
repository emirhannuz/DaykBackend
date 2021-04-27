using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class StokCikisManager : IStokCikisService
    {
        IStokCikisDal _stokCikisDal;
        IStokService _stokService;
        IStokCikisOnayService _stokCikisOnayService;
        IStokCikisTeslimService _stokCikisTeslimService;
        public StokCikisManager(
            IStokCikisDal stokCikisDal,
            IStokService stokService,
            IStokCikisOnayService stokCikisOnayService,
            IStokCikisTeslimService stokCikisTeslimService)
        {
            _stokCikisDal = stokCikisDal;
            _stokService = stokService;
            _stokCikisOnayService = stokCikisOnayService;
            _stokCikisTeslimService = stokCikisTeslimService;
        }


        //[SecuredOperation("talep.onay")]
        [ValidationAspect(typeof(StokCikisValidator))]
        public IResult Add(StokCikis stokCikis)
        {
            var cikisiVerilmisStokAdedi = GetTotalStokCikisAdetByUrunId(stokCikis.UrunId);
            var result = BusinessRules.Run(
                _stokService.CheckIfStokAdetEnough(stokCikis.UrunId, stokCikis.Adet + cikisiVerilmisStokAdedi)
                );
            if (result != null)
            {
                return result;
            }

            _stokCikisDal.Add(stokCikis);
            return new SuccessResult("Stok Cikis bilgisi eklendi.");
        }

        //[SecuredOperation("talep.onay")]
        public IResult Delete(StokCikis stokCikis)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            _stokCikisDal.Delete(stokCikis);
            return new SuccessResult("Stok Cikis bilgisi silindi.");
        }

        //[SecuredOperation("talep.onay,dagitici")]
        public IDataResult<List<StokCikis>> GetAll()
        {
            var result = _stokCikisDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<StokCikis>>("Stok Cikis bilgileri bulunamadı");
            }
            return new SuccessDataResult<List<StokCikis>>(result, "Stok cikis bilgileri getirildi.");
        }

        //[SecuredOperation("talep.onay,dagitici")]
        public IDataResult<StokCikis> GetById(int id)
        {
            var result = _stokCikisDal.Get(sc => sc.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<StokCikis>("Stok Cikisa ait bilgi bulunamadi.");
            }
            return new SuccessDataResult<StokCikis>(result, "Stok Cikisa ait bilgi getirildi.");
        }

        //[SecuredOperation("talep.onay")]
        public IDataResult<List<StokCikisDetayDto>> GetDetailsByOlcuBirimId(int olcuBirimId)
        {
            var result = _stokCikisDal.GetAllDetails().Where(scd => scd.UrunBilgileri.OlcuBirim.Id == olcuBirimId).ToList();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<StokCikisDetayDto>>("Bu ölçü birimine ait stok cikis bilgisi bulunamadı");
            }
            return new SuccessDataResult<List<StokCikisDetayDto>>(result, "Ölçü birimine ait stok cikis bilgileri getirildi.");
        }


        //[SecuredOperation("talep.onay")]
        public IDataResult<List<StokCikisDetayDto>> GetByOnaylayanId(int onaylayanId)
        {
            var result = _stokCikisDal.GetAllDetails().Where(scd => scd.OnaylayanKullaniciBigileri.Id == onaylayanId).ToList();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<StokCikisDetayDto>>("Stok Cikis bilgileri bulunamadı");
            }
            return new SuccessDataResult<List<StokCikisDetayDto>>(result, "Stok cikis bilgileri getirildi.");
        }


        //[SecuredOperation("talep.onay,dagitici")]
        public IDataResult<List<StokCikisDetayDto>> GetByTeslimEdenId(int teslimEdenId)
        {
            var result = _stokCikisDal.GetAllDetails().Where(sc => sc.TeslimEdenKullaniciBilgileri.Id == teslimEdenId).ToList();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<StokCikisDetayDto>>("Stok Cikis bilgileri bulunamadı");
            }
            return new SuccessDataResult<List<StokCikisDetayDto>>(result, "Stok cikis bilgileri getirildi.");
        }

        //[SecuredOperation("talep.onay,dagitici")]
        public IDataResult<List<StokCikis>> GetByUrunId(int urunId)
        {
            var result = _stokCikisDal.GetAll(sc => sc.UrunId == urunId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<StokCikis>>("Stok Cikis bilgileri bulunamadı");
            }
            return new SuccessDataResult<List<StokCikis>>(result, "Stok cikis bilgileri getirildi.");
        }


        //[SecuredOperation("talep.onay")]
        public IResult StokCikisiOnayla(StokCikisOnay stokCikisOnay)
        {

            var result = BusinessRules.Run(
                GetById(stokCikisOnay.StokCikisId)
               );
            if (result != null)
            {
                return result;
            }

            var confirmResult = _stokCikisOnayService.Add(stokCikisOnay);
            return confirmResult;
        }

        //[SecuredOperation("dagitici")]
        public IResult StokCikisiTeslimEdildiOlarakİsaretle(StokCikisTeslim stokCikisTeslim)
        {
            var result = BusinessRules.Run(
                GetById(stokCikisTeslim.StokCikisId)
                );
            if (result != null)
            {
                return result;
            }

            var delivereResult = _stokCikisTeslimService.Add(stokCikisTeslim);
            return delivereResult;
        }


        //[SecuredOperation("talep.onay")]
        [ValidationAspect(typeof(StokCikisValidator))]
        public IResult Update(StokCikis stokCikis)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            _stokCikisDal.Update(stokCikis);
            return new SuccessResult("Stok Cikis bilgisi güncellendi.");
        }


        public int GetTotalStokCikisAdetByUrunId(int urunId)
        {
            var stokCikislar = GetByUrunId(urunId);
            var cikisiVerilmisStokAdedi = 0;
            if (!stokCikislar.Success) return cikisiVerilmisStokAdedi;
            stokCikislar.Data.ForEach(delegate (StokCikis cikis) { cikisiVerilmisStokAdedi += cikis.Adet; });
            return cikisiVerilmisStokAdedi;
        }


        //[SecuredOperation("yonetici,talep.onay,dagitici")]
        public IDataResult<List<StokCikisDetayDto>> GetAllDetails()
        {
            var result = _stokCikisDal.GetAllDetails();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<StokCikisDetayDto>>("Stok cikis detayı bulunamdi");
            }
            return new SuccessDataResult<List<StokCikisDetayDto>>(result, "Stok cikis detayları getirildi.");
        }

        //[SecuredOperation("yonetici,talep.onay,dagitici")]
        public IDataResult<StokCikisDetayDto> GetDetailsById(int id)
        {
            var result = GetAllDetails().Data.SingleOrDefault(scdd => scdd.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<StokCikisDetayDto>("Stok cikis detayı bulunamdi");
            }
            return new SuccessDataResult<StokCikisDetayDto>(result, "Stok cikis detayı getirildi.");
        }

        //[SecuredOperation("yonetici,talep.onay,dagitici")]
        public IDataResult<List<StokCikisDetayDto>> GetDetailsByAfetzedeId(int afetzedeId)
        {
            var result = GetAllDetails().Data.Where(scdd => scdd.AfetzedeBilgileri.Afetzede.Id == afetzedeId).ToList();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<StokCikisDetayDto>>("Stok cikis detayı bulunamdi");
            }
            return new SuccessDataResult<List<StokCikisDetayDto>>(result, "Stok cikis detayı getirildi.");
        }




    }
}
