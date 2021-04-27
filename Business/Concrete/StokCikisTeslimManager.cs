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
    public class StokCikisTeslimManager : IStokCikisTeslimService
    {

        IStokCikisTeslimDal _stokCikisTeslimDal;
        public StokCikisTeslimManager(IStokCikisTeslimDal stokCikisTeslimDal)
        {
            _stokCikisTeslimDal = stokCikisTeslimDal;
        }


        [ValidationAspect(typeof(StokCikisTeslimValidator))]
        public IResult Add(StokCikisTeslim stokCikisTeslim)
        {
            var result = BusinessRules.Run(
                CheckIfStokCikisNotDeliveredByStokCikisId(stokCikisTeslim.StokCikisId)
                );
            if (result != null)
            {
                return result;
            }

            stokCikisTeslim.TeslimTarihi = DateTime.Now;
            _stokCikisTeslimDal.Add(stokCikisTeslim);
            return new SuccessResult("Stok cikis teslim edildi.");
        }

        public IResult CheckIfStokCikisNotDeliveredByStokCikisId(int stokCikisId)
        {
            var result = _stokCikisTeslimDal.Get(sct => sct.StokCikisId == stokCikisId);
            if (result != null)
            {
                return new ErrorResult("Stok cikis henüz teslim edilmedi.");
            }
            return new SuccessResult();
        }

        public IResult Delete(StokCikisTeslim stokCikisTeslim)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<StokCikisTeslim>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<StokCikisTeslim> GetById(int id)
        {
            var result = _stokCikisTeslimDal.Get(sco => sco.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<StokCikisTeslim>("Bu stok cikis onaylanmamış.");
            }
            return new SuccessDataResult<StokCikisTeslim>(result, "");
        }


        [ValidationAspect(typeof(StokCikisTeslimValidator))]
        public IResult Update(StokCikisTeslim stokCikisTeslim)
        {
            throw new NotImplementedException();
        }
    }
}
