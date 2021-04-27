using Core.Entites.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<UserDetayDto>> GetAllDetails();
        IDataResult<User> GetDetailByTc(string tcNo);
        IDataResult<UserDetayDto> GetDetailById(int id);
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

    }
}
