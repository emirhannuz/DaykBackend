using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entites.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }


        //[SecuredOperation("yonetici")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            var result = BusinessRules.Run(
                CheckIfUserNotExistsByTc(user.TcNo),
                CheckIfUsernameExists(user.Username)
                );
            if (result != null)
            {
                return result;
            }

            _userDal.Add(user);
            return new SuccessResult();
        }


        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(result);
        }

        //[SecuredOperation("yonetici")]
        public IResult Delete(User user)
        {
            var result = BusinessRules.Run(
                CheckIfUserExistsById(user.Id)
                );
            if (result != null)
            {
                return result;
            }

            _userDal.Delete(user);
            return new SuccessResult("Kullanıcı kaydı başarıyla silindi.");
        }

        //[SecuredOperation("yonetici")]
        public IDataResult<List<UserDetayDto>> GetAllDetails()
        {
            var result = _userDal.GetAllUserDetay();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<UserDetayDto>>("Sisteme kayitli kullanici bulunamadi.");
            }

            return new SuccessDataResult<List<UserDetayDto>>(result, "Sisteme Kayıtlı Kullanıcılar başarıyla getirildi.");
        }

        //[SecuredOperation("yonetici")]
        public IDataResult<UserDetayDto> GetDetailById(int id)
        {
            var result = _userDal.GetAllUserDetay().SingleOrDefault(u => u.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<UserDetayDto>("Böyle bir kullanici sistemde mevcut değil.");
            }
            return new SuccessDataResult<UserDetayDto>(result, "Kullanici bilgileri başarıyla getirlidi.");
        }

        //[SecuredOperation("yonetici")]
        public IDataResult<User> GetDetailByTc(string tcNo)
        {
            var result = _userDal.Get(u => u.TcNo == tcNo);
            if (result == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadi.");
            }
            return new SuccessDataResult<User>(result, "Kullanici başarıyla getirildi.");
        }

        //[SecuredOperation("yonetici")]

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            var result = BusinessRules.Run(
                CheckIfUserExistsById(user.Id)
                );
            if (result != null)
            {
                return result;
            }

            _userDal.Update(user);
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
        }

        private IResult CheckIfUserNotExistsByTc(string tc)
        {
            var result = GetDetailByTc(tc);
            if (result.Success)
            {
                return new ErrorResult("Bu kimlik numarasina sahip kullanici sisteme zaten kayitli");
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserExistsById(int id)
        {
            var result = GetDetailById(id);
            if (result.Success)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult();
        }

        private IResult CheckIfUsernameExists(string username)
        {
            var result = _userDal.Get(u => u.Username == username);
            if (result != null)
            {
                return new ErrorResult("Kullanıcı adı kullanılıyor.");
            }
            return new SuccessResult();
        }
    }
}
