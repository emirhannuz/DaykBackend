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
    public class UrunManager : IUrunService
    {
        IUrunDal _urunDal;
        ITurService _turService;
        IOlcuBirimService _olcuBirimService;
        public UrunManager(IUrunDal urunDal, ITurService turService, IOlcuBirimService olcuBirimService)
        {
            _urunDal = urunDal;
            _turService = turService;
            _olcuBirimService = olcuBirimService;
        }


        [ValidationAspect(typeof(UrunValidator))]
        public IResult Add(Urun urun)
        {
            var result = BusinessRules.Run(
                      _turService.CheckIfTurExistsById(urun.TurId),
                      _olcuBirimService.CheckIfOlcuBirimExistsById(urun.OlcuBirimId)
                    );

            if (result != null)
            {
                return result;
            }
            _urunDal.Add(urun);
            return new SuccessResult("Ürün başarıyla eklendi.");
        }

        public IResult Delete(Urun urun)
        {
            /*stok bilgisi var ise silme*/
            var result = BusinessRules.Run(CheckIfUrunExistsById(urun.Id));
            if (result != null)
            {
                return result;
            }
            _urunDal.Delete(urun);
            return new SuccessResult("Ürün başarıyla silindi.");
        }

        public IDataResult<List<Urun>> GetAll()
        {
            var result = _urunDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Urun>>("Ürün Bulunamadı.");
            }
            return new SuccessDataResult<List<Urun>>(result, "Ürünler başarıyla getirildi.");
        }

        public IDataResult<Urun> GetById(int id)
        {
            var result = _urunDal.Get(u => u.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Urun>("Ürün Bulunamadı.");
            }
            return new SuccessDataResult<Urun>(result, "Ürün başarıyla getirildi.");
        }

        public IDataResult<List<Urun>> GetByTurId(int turId)
        {
            var result = _urunDal.GetAll(u => u.TurId == turId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Urun>>("Türe Ait Ürün Bulunamadi");
            }
            return new SuccessDataResult<List<Urun>>(result, "Türe ait ürünler başarıyla getirildi.");
        }

        [ValidationAspect(typeof(UrunValidator))]
        public IResult Update(Urun urun)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _urunDal.Delete(urun);
            return new SuccessResult("Ürün başarıyla güncellendi.");
        }


        private IResult CheckIfUrunAdiNotExists(string urunAdi)
        {
            var result = _urunDal.Get(u => u.UrunAdi == urunAdi);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Ürün adi zaten mevcut.");
        }

        public IResult CheckIfUrunExistsById(int id)
        {
            var result = _urunDal.Get(u => u.Id == id);
            if (result == null)
            {
                return new ErrorResult("Böyle bir ürün yok.");
            }
            return new SuccessResult();
        }

        public IDataResult<List<UrunDetayDto>> GetAllDetails()
        {
            var result = _urunDal.GetAllUrunDetails();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<UrunDetayDto>>("Urun detayi bulunamadi.");
            }
            return new SuccessDataResult<List<UrunDetayDto>>(result, "Ürün detayları detirildi.");
        }

        public IDataResult<UrunDetayDto> GetDetailById(int id)
        {
            var result = _urunDal.GetAllUrunDetails().SingleOrDefault(udd => udd.Urun.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<UrunDetayDto>("Urun detayi bulunamadi.");
            }
            return new SuccessDataResult<UrunDetayDto>(result, "Ürün detayları detirildi.");
        }
    }
}
