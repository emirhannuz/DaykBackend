using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAfetzedeDal : EfEntityRepositoryBase<Afetzede, DaykContext>, IAfetzedeDal
    {
        public List<AfetzedeDetayDto> GetAllAfetzedeDetay()
        {
            using (var context = new DaykContext())
            {
                var result = from afetzede in context.Afetzedeler
                             join afetzedeFotograf in context.AfetzedeFotograflar
                             on afetzede.Id equals afetzedeFotograf.AfetzedeId
                             into afList
                             from afetzedeFotograf in afList.DefaultIfEmpty()
                             select new AfetzedeDetayDto
                             {
                                 Afetzede = afetzede,
                                 AfetzedeFotograf = afetzedeFotograf
                             };
                return result.ToList();
            }
        }
    }
}
