using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUrunDal : IEntityRepository<Urun>
    {
        List<UrunDetayDto> GetAllUrunDetails();
    }
}
