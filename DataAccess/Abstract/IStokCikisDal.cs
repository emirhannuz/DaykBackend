using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IStokCikisDal : IEntityRepository<StokCikis>
    {
        List<StokCikisDetayDto> GetAllDetails();
    }
}
