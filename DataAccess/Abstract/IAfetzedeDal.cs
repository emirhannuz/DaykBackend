using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IAfetzedeDal : IEntityRepository<Afetzede>
    {
        List<AfetzedeDetayDto> GetAllAfetzedeDetay();
    }
}
