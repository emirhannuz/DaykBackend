using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IStokDal : IEntityRepository<Stok>
    {
        List<StokDetayDto> GetAllStokDetay();
    }
}
