using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers.Images;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AfetzedeFotografManager : IAfetzedeFotografService
    {
        IAfetzedeFotografDal _afetzedeFotografDal;
        IImageFileHelper _imageFileHelper;

        public AfetzedeFotografManager(IAfetzedeFotografDal afetzedeFotografDal, IImageFileHelper imageFileHelper)
        {
            _afetzedeFotografDal = afetzedeFotografDal;
            _imageFileHelper = imageFileHelper;
        }


        //[SecuredOperation("talep.onay")]
        public IResult Add(int afetzedeId, IFormFile formFile)
        {
            var result = BusinessRules.Run(
                CheckIfAfetzedeFotografLimitExceeded(afetzedeId)
                );
            if (result != null)
            {
                return result;
            }

            var uploadResult = _imageFileHelper.Add(formFile);
            if (!uploadResult.Success)
            {
                return uploadResult;
            }


            var afetzedeFoto = new AfetzedeFotograf
            {
                AfetzedeId = afetzedeId,
                EklemeTarihi = DateTime.Now,
                FotografYolu = uploadResult.Data
            };

            _afetzedeFotografDal.Add(afetzedeFoto);
            return new SuccessResult("Fotoğraf başarı ile yüklendi");
        }

        //[SecuredOperation("talep.onay")]
        public IResult Delete(AfetzedeFotograf afetzedeFotograf)
        {
            var image = Get(afetzedeFotograf);
            if (image.Data == null)
            {
                return new ErrorResult("Böyle bir resim yok");
            }

            var deleteResult = _imageFileHelper.Delete(image.Data.FotografYolu);
            if (!deleteResult.Success)
            {
                return deleteResult;
            }

            _afetzedeFotografDal.Delete(afetzedeFotograf);
            return new SuccessResult();
        }

        //[SecuredOperation("talep.onay")]
        public IDataResult<AfetzedeFotograf> Get(AfetzedeFotograf afetzedeFotograf)
        {
            var result = _afetzedeFotografDal.Get(af => af.Id == afetzedeFotograf.Id);
            if (result == null)
            {
                return new ErrorDataResult<AfetzedeFotograf>("Böyle bir fotoğraf yok.");
            }
            return new SuccessDataResult<AfetzedeFotograf>(result, "Fotoğraf başarıyla getirildi.");
        }

        //[SecuredOperation("talep.onay")]
        public IDataResult<List<AfetzedeFotograf>> GetAll()
        {
            var result = _afetzedeFotografDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<AfetzedeFotograf>>("Sistemde fotograf bılunamadı.");
            }
            return new SuccessDataResult<List<AfetzedeFotograf>>(result, "fotograflar getirildi.");
        }

        //[SecuredOperation("talep.onay")]
        public IDataResult<List<AfetzedeFotograf>> GetByAfetzedeId(int afetzedeId)
        {
            var result = _afetzedeFotografDal.GetAll(af => af.AfetzedeId == afetzedeId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<AfetzedeFotograf>>("Afetzedeye ait fotoğraf bulunamadi.");
            }
            return new SuccessDataResult<List<AfetzedeFotograf>>(result, "Afetzedeye ait fotoğraflar getirildi.");
        }

        //[SecuredOperation("talep.onay")]
        public IDataResult<AfetzedeFotograf> GetById(int id)
        {
            var result = _afetzedeFotografDal.Get(af => af.AfetzedeId == id);
            if (result == null)
            {
                return new ErrorDataResult<AfetzedeFotograf>("Afetzedeye ait fotoğraf bulunamadi.");
            }
            return new SuccessDataResult<AfetzedeFotograf>(result, "Afetzedeye ait fotoğraf getirildi.");
        }

        //[SecuredOperation("talep.onay")]
        public IResult Update(AfetzedeFotograf afetzedeFotograf)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfAfetzedeFotografLimitExceeded(int afetzedeId)
        {
            var result = GetByAfetzedeId(afetzedeId).Data;
            if (result.Count >= 1)
            {
                return new ErrorResult("Afetzede için daha fazla fotoğraf ekleyemezsiniz");
            }
            return new SuccessResult();
        }
    }
}
