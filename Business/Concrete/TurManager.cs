using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TurManager : ITurService
    {
        ITurDal _turDal;
        public TurManager(ITurDal turDal)
        {
            _turDal = turDal;
        }

        [ValidationAspect(typeof(TurValidator))]
        public IResult Add(Tur tur)
        {
            var result = BusinessRules.Run(CheckIfTurNameNotExists(tur.TurAdi));
            if (result != null)
            {
                return result;
            }
            _turDal.Add(tur);
            return new SuccessResult("Tür başarıyla eklendi.");
        }

        public IResult Delete(Tur tur)
        {
            /*bu türde ürün varsa silme*/
            var result = BusinessRules.Run(
                CheckIfTurExistsById(tur.Id)
                );
            if (result != null)
            {
                return result;
            }
            _turDal.Delete(tur);
            return new SuccessResult("Tür başarıyla silindi.");
        }

        public IDataResult<List<Tur>> GetAll()
        {
            var result = _turDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Tur>>("Tür bulunamadı.");
            }
            return new SuccessDataResult<List<Tur>>(result, "Türler başarıyla getirildi.");
        }

        public IDataResult<Tur> GetById(int id)
        {
            var result = _turDal.Get(t => t.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Tur>("Tür bulunamadi.");
            }
            return new SuccessDataResult<Tur>(result, "Tür başarıyla getirildi.");
        }

        [ValidationAspect(typeof(TurValidator))]
        public IResult Update(Tur tur)
        {
            var result = BusinessRules.Run(CheckIfTurExistsById(tur.Id));
            if (result != null)
            {
                return result;
            }
            _turDal.Delete(tur);
            return new SuccessResult("Tür başarıyla güncellendi.");
        }

        private IResult CheckIfTurNameNotExists(string name)
        {
            var result = _turDal.Get(t => t.TurAdi == name);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir tür zaten mevcut");
        }

        public IResult CheckIfTurExistsById(int id)
        {
            var result = _turDal.Get(t => t.Id == id);
            if (result == null)
            {
                return new ErrorResult("Böyle bir tür mevcut değil.");

            }
            return new SuccessResult();

        }
    }
}
