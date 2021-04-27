using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStokCikisDal : EfEntityRepositoryBase<StokCikis, DaykContext>, IStokCikisDal
    {
        public List<StokCikisDetayDto> GetAllDetails()
        {
            using (var context = new DaykContext())
            {
                
                var result = from stokCikis in context.StokCikislar
                             join afetzede in context.Afetzedeler on stokCikis.AfetzedeId equals afetzede.Id
                             join afetzedeFotograf in context.AfetzedeFotograflar on stokCikis.Id equals afetzedeFotograf.AfetzedeId
                             into afetzedeFotografList
                             from afetzedeFotoraf in afetzedeFotografList.DefaultIfEmpty()
                             join urun in context.Urunler on stokCikis.UrunId equals urun.Id
                             join tur in context.Turler on urun.TurId equals tur.Id
                             join olcuBirim in context.OlcuBirimler on urun.OlcuBirimId equals olcuBirim.Id
                             into olcuBirimList
                             from olcuBirim in olcuBirimList.DefaultIfEmpty()

                             join stokCikisOnay in context.StokCikisOnaylar on stokCikis.Id equals stokCikisOnay.StokCikisId
                             into stokCikisOnayList
                             from stokCikisOnay in stokCikisOnayList.DefaultIfEmpty()
                             join userOnay in context.Users on stokCikisOnay.OnaylayanKullaniciId equals userOnay.Id
                             into userOnayList
                             from userOnay in userOnayList.DefaultIfEmpty()

                             join stokCikisTeslim in context.StokCikisTeslimler on stokCikis.Id equals stokCikisTeslim.StokCikisId
                             into stokCikisTeslimList
                             from stokCikisTeslim in stokCikisTeslimList.DefaultIfEmpty()
                             join userTeslim in context.Users on stokCikisTeslim.TeslimEdenKullaniciId equals userTeslim.Id
                             into userTeslimList
                             from userTeslim in userTeslimList.DefaultIfEmpty()

                             select new StokCikisDetayDto
                             {
                                 Id = stokCikis.Id,
                                 Adet = stokCikis.Adet,
                                 AfetzedeBilgileri = new AfetzedeDetayDto { Afetzede = afetzede, AfetzedeFotograf = afetzedeFotoraf },
                                 UrunBilgileri = new UrunDetayDto { Urun = urun, Tur = tur, OlcuBirim = olcuBirim },
                                 OnaylayanKullaniciBigileri = new UserDetayDto
                                 {
                                     Id = userOnay.Id,
                                     TcNo = userOnay.TcNo,
                                     FirstName = userOnay.FirstName,
                                     LastName = userOnay.LastName,
                                     Username = userOnay.Username,
                                     Email = userOnay.Email,
                                     PhoneNumber = userOnay.PhoneNumber,
                                     Address = userOnay.Address
                                 },
                                 TeslimEdenKullaniciBilgileri = new UserDetayDto
                                 {
                                     Id = userTeslim.Id,
                                     TcNo = userTeslim.TcNo,
                                     FirstName = userTeslim.FirstName,
                                     LastName = userTeslim.LastName,
                                     Username = userTeslim.Username,
                                     Email = userTeslim.Email,
                                     PhoneNumber = userTeslim.PhoneNumber,
                                     Address = userTeslim.Address
                                 },
                                 OnayTarihi = stokCikisOnay.OnayTarihi,
                                 TeslimTarihi = stokCikisTeslim.TeslimTarihi
                             };

                return result.ToList();
            }
        }
    }
}
