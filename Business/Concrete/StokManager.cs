using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class StokManager : IStokService
    {
        IStokDal _stokDal;
        IUrunService _urunService;
        public StokManager(IStokDal stokDal, IUrunService urunService)
        {
            _stokDal = stokDal;
            _urunService = urunService;
        }


        //[SecuredOperation("stok")]
        [ValidationAspect(typeof(StokValidator))]
        public IResult Add(Stok stok)
        {
            var result = BusinessRules.Run(
                _urunService.CheckIfUrunExistsById(stok.UrunId),
                CheckIfStokExistsByUrunId(stok.UrunId)
                );
            if (result != null)
            {
                return result;
            }

            stok.GirisTarihi = DateTime.Now;
            _stokDal.Add(stok);
            return new SuccessResult("Stok başarıyla eklendi");
        }

        //[SecuredOperation("stok")]
        public IResult Delete(Stok stok)
        {
            var result = BusinessRules.Run(
                CheckIfStokExistsById(stok.Id)
                );
            if (result != null)
            {
                return result;
            }

            _stokDal.Delete(stok);
            return new SuccessResult("Stok başarıyla silindi");
        }

        //[SecuredOperation("yonetici,stok")]
        public IDataResult<List<Stok>> GetAll()
        {
            var result = _stokDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Stok>>("Stok bilgisi bulunamadi.");
            }
            return new SuccessDataResult<List<Stok>>(result, "Stok bilgileri getirildi.");
        }


        //[SecuredOperation("yonetici,stok")]
        public IDataResult<Stok> GetById(int id)
        {
            var result = _stokDal.Get(s => s.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Stok>("Stok bilgisi bulunamadi.");
            }
            return new SuccessDataResult<Stok>(result, "Stok bilgisi getirildi.");
        }

        //[SecuredOperation("yonetici,stok")]
        public IDataResult<List<Stok>> GetByKayitYapanId(int kayitYapanId)
        {
            var result = _stokDal.GetAll(s => s.KayitYapanId == kayitYapanId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Stok>>("Stok bilgisi bulunamadi.");
            }
            return new SuccessDataResult<List<Stok>>(result, "Stok bilgisi getirildi.");
        }

        //[SecuredOperation("yonetici,stok")]
        public IDataResult<Stok> GetByUrunId(int urunId)
        {
            var result = _stokDal.Get(s => s.UrunId == urunId);
            if (result == null)
            {
                return new ErrorDataResult<Stok>("Belirtilen ürün için stok bilgisi bulunamadı.");
            }
            return new SuccessDataResult<Stok>(result, "Ürüne ait stok bilgisi getirildi.");
        }


        //[SecuredOperation("stok")]
        [ValidationAspect(typeof(StokValidator))]
        public IResult Update(Stok stok)
        {
            var result = BusinessRules.Run(
                CheckIfStokExistsById(stok.Id)
                );
            if (result != null)
            {
                return result;
            }

            _stokDal.Update(stok);
            return new SuccessResult("Stok başarıyla güncellendi.");
        }

        public IResult CheckIfStokAdetEnough(int urunId, int stokCikisAdet)
        {
            var stok = GetByUrunId(urunId);
            var result = BusinessRules.Run(stok);
            if (result != null)
            {
                return result;
            }

            if (stok.Data.Adet < stokCikisAdet)
            {
                return new ErrorResult("Stok yeterli değil.");
            }

            return new SuccessResult();
        }


        public IResult CheckIfStokExistsById(int id)
        {
            var result = _stokDal.Get(s => s.Id == id);
            if (result == null)
            {
                return new ErrorResult("Stok bilgisi bulunamadi.");
            }
            return new SuccessResult();
        }

        private IResult CheckIfStokExistsByUrunId(int urunId)
        {
            var result = _stokDal.Get(s => s.UrunId == urunId);
            if (result != null)
            {
                return new ErrorResult("Ürüne ait stok bilgisi mevcut");
            }
            return new SuccessResult();
        }

        //[SecuredOperation("yonetici,stok")]
        public IDataResult<List<StokDetayDto>> GetAllStokDetail()
        {
            var result = _stokDal.GetAllStokDetay();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<StokDetayDto>>("Stok detay bilgisi bulunamadı.");
            }
            return new SuccessDataResult<List<StokDetayDto>>(result, "Stok detayları getirildi.");
        }

        //[SecuredOperation("yonetici,stok")]
        public IDataResult<StokDetayDto> GetStokDetailById(int id)
        {
            var result = _stokDal.GetAllStokDetay().SingleOrDefault(sdd => sdd.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<StokDetayDto>("Stok detay bilgisi bulunamadı.");
            }
            return new SuccessDataResult<StokDetayDto>(result, "Stok detay bilgisi getirildi.");
        }
    }
}
