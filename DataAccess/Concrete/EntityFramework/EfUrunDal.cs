using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUrunDal : EfEntityRepositoryBase<Urun, DaykContext>, IUrunDal
    {
        public List<UrunDetayDto> GetAllUrunDetails()
        {
            using (var context = new DaykContext())
            {
                var result = from urun in context.Urunler
                             join tur in context.Turler
                             on urun.TurId equals tur.Id
                             join olcuBirim in context.OlcuBirimler
                             on urun.OlcuBirimId equals olcuBirim.Id
                             select new UrunDetayDto
                             {
                                 Urun = urun,
                                 Tur = tur,
                                 OlcuBirim = olcuBirim
                             };
                return result.ToList();
            }
        }
    }
}
