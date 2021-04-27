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

namespace Business.Concrete
{
    public class AfetzedeManager : IAfetzedeService
    {

        IAfetzedeDal _afetzedeDal;

        public AfetzedeManager(IAfetzedeDal afetzedeDal)
        {
            _afetzedeDal = afetzedeDal;
        }


        //[SecuredOperation("talep.onay")]
        [ValidationAspect(typeof(AfetzedeValidator))]
        public IResult Add(Afetzede afetzede)
        {
            var result = BusinessRules.Run(
                CheckIfAfetzedeNotExistsByTcNo(afetzede.TcYuNo)
                );
            if (result != null)
            {
                return result;
            }

            afetzede.KayitTarihi = DateTime.Now;
            _afetzedeDal.Add(afetzede);
            return new SuccessResult("Afetzede başarıyla eklendi.");
        }

        //[SecuredOperation("talep.onay")]
        public IResult Delete(Afetzede afetzede)
        {
            var result = BusinessRules.Run(
                CheckIfAfetzedeExistsById(afetzede.Id)
                );
            if (result != null)
            {
                return result;
            }
            _afetzedeDal.Delete(afetzede);
            return new SuccessResult("Afetzede başarıyla silindi.");
        }

        //[SecuredOperation("yonetici,talep.onay")]
        public IDataResult<List<Afetzede>> GetAll()
        {
            var result = _afetzedeDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Afetzede>>("Afetzede mevcut değil.");
            }
            return new SuccessDataResult<List<Afetzede>>(result);
        }

        //[SecuredOperation("yonetici,talep.onay")]
        public IDataResult<Afetzede> GetById(int id)
        {
            var result = _afetzedeDal.Get(a => a.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Afetzede>("Böyle bir afetzede yok");
            }
            return new SuccessDataResult<Afetzede>(result, "Afetzede  bilgileri getirildi.");
        }

        //[SecuredOperation("yonetici,talep.onay")]
        public IDataResult<Afetzede> GetByTc(string tc)
        {
            var result = _afetzedeDal.Get(a => a.TcYuNo == tc);
            if (result == null)
            {
                return new ErrorDataResult<Afetzede>("Böyle bir afetzede yok");
            }
            return new SuccessDataResult<Afetzede>(result, "Afetzede  bilgileri getirildi.");
        }


        //[SecuredOperation("talep.onay")]
        [ValidationAspect(typeof(AfetzedeValidator))]
        public IResult Update(Afetzede afetzede)
        {
            var result = BusinessRules.Run(
                CheckIfAfetzedeExistsById(afetzede.Id)
                );
            if (result != null)
            {
                return result;
            }
            _afetzedeDal.Update(afetzede);
            return new SuccessResult("Afetzede başarıyla güncellendi.");
        }



        private IResult CheckIfAfetzedeNotExistsByTcNo(string tcNo)
        {
            var result = _afetzedeDal.Get(a => a.TcYuNo == tcNo);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Afetzede sistemde kayıtlı.");
        }

        private IResult CheckIfAfetzedeExistsById(int id)
        {
            var result = GetById(id);
            if (!result.Success)
            {
                return new ErrorResult("Afetzede bulunamadı.");
            }
            return new SuccessResult();
        }

        public IDataResult<List<AfetzedeDetayDto>> GetAllDetails()
        {
            var result = _afetzedeDal.GetAllAfetzedeDetay();
            if(result.Count == 0)
            {
                return new ErrorDataResult<List<AfetzedeDetayDto>>("Afetzede bulunamadi.");
            }
            return new SuccessDataResult<List<AfetzedeDetayDto>>(result,"Afetzede detayları getirildi.");
        }
    }
}
