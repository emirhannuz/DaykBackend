using Core.DataAccess.Concrete.EntityFramework;
using Core.Entites.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DaykContext>, IUserDal
    {
        public List<UserDetayDto> GetAllUserDetay()
        {
            using (var context = new DaykContext())
            {
                var result = from user in context.Users
                             select new UserDetayDto
                             {
                                 Id = user.Id,
                                 TcNo = user.TcNo,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Username = user.Username,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber,
                                 Address = user.Address
                             };

                return result.ToList();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DaykContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();

            }
        }

    }
}
