using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class StokCikisOnayManager : IStokCikisOnayService
    {
        IStokCikisOnayDal _stokCikisOnayDal;
        public StokCikisOnayManager(IStokCikisOnayDal stokCikisOnayDal)
        {
            _stokCikisOnayDal = stokCikisOnayDal;
        }


        [ValidationAspect(typeof(StokCikisOnayValidator))]
        public IResult Add(StokCikisOnay stokCikisOnay)
        {

            var result = BusinessRules.Run(
                CheckIfStokCikisNotConfirmedByStokCikisId(stokCikisOnay.StokCikisId)
                );
            if (result != null)
            {
                return result;
            }

            stokCikisOnay.OnayTarihi = DateTime.Now;
            _stokCikisOnayDal.Add(stokCikisOnay);
            return new SuccessResult("Stok Cikis başarıyla onaylandi.");
        }

        public IResult CheckIfStokCikisNotConfirmedByStokCikisId(int stokCikisId)
        {
            var result = _stokCikisOnayDal.Get(sco => sco.StokCikisId == stokCikisId);
            if (result != null)
            {
                return new ErrorResult("Bu stok çıkış henüz onaylanmamış");
            }
            return new SuccessResult();
        }

        public IResult Delete(StokCikisOnay stokCikisOnay)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<StokCikisOnay>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<StokCikisOnay> GetById(int id)
        {
            var result = _stokCikisOnayDal.Get(sco => sco.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<StokCikisOnay>("Bu stok cikis onaylanmamış.");
            }
            return new SuccessDataResult<StokCikisOnay>(result, "");
        }

        [ValidationAspect(typeof(StokCikisOnayValidator))]
        public IResult Update(StokCikisOnay stokCikisOnay)
        {
            throw new NotImplementedException();
        }
    }
}
