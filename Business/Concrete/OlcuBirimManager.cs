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
    public class OlcuBirimManager : IOlcuBirimService
    {
        IOlcuBirimDal _olcuBirimDal;
        public OlcuBirimManager(IOlcuBirimDal olcuBirimDal)
        {
            _olcuBirimDal = olcuBirimDal;
        }


        //[SecuredOperation("stok")]
        [ValidationAspect(typeof(OlcuBirimValidator))]
        public IResult Add(OlcuBirim olcuBirim)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _olcuBirimDal.Add(olcuBirim);
            return new SuccessResult("Tür başarıyla eklendi.");
        }

        public IResult CheckIfOlcuBirimExistsById(int id)
        {
            var result = _olcuBirimDal.Get(ob => ob.Id == id);
            if (result == null)
            {
                return new ErrorResult("Böyle bir ölçü birim mevcut değil.");
            }
            return new SuccessResult();
        }

        //[SecuredOperation("stok")]
        public IResult Delete(OlcuBirim olcuBirim)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _olcuBirimDal.Delete(olcuBirim);
            return new SuccessResult("Tür başarıyla silindi.");
        }


        //[SecuredOperation("yonetici,stok")]
        public IDataResult<List<OlcuBirim>> GetAll()
        {
            var result = _olcuBirimDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<OlcuBirim>>("Ölçü Birimi mevcut değil.");
            }
            return new SuccessDataResult<List<OlcuBirim>>(result);
        }

        //[SecuredOperation("yonetici,stok")]
        public IDataResult<OlcuBirim> GetById(int id)
        {
            var result = _olcuBirimDal.Get(ob => ob.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<OlcuBirim>("Böyle bir ölçü birimi yok");
            }
            return new SuccessDataResult<OlcuBirim>(result, "Ölçü birimleri getirildi.");
        }

        //[SecuredOperation("stok")]
        [ValidationAspect(typeof(OlcuBirimValidator))]
        public IResult Update(OlcuBirim olcuBirim)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _olcuBirimDal.Update(olcuBirim);
            return new SuccessResult("Tür başarıyla güncellendi.");
        }
    }
}
