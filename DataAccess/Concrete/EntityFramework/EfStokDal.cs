using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStokDal : EfEntityRepositoryBase<Stok, DaykContext>, IStokDal
    {
        public List<StokDetayDto> GetAllStokDetay()
        {
            using (var context = new DaykContext())
            {
                var result = from stok in context.Stoklar
                             join urun in context.Urunler
                             on stok.UrunId equals urun.Id
                             join olcuBirim in context.OlcuBirimler
                             on urun.OlcuBirimId equals olcuBirim.Id
                             join user in context.Users
                             on stok.KayitYapanId equals user.Id
                             join tur in context.Turler on urun.TurId equals tur.Id
                             select new StokDetayDto
                             {
                                 Id = stok.Id,
                                 UrunBilgileri = new UrunDetayDto { Urun = urun, Tur = tur, OlcuBirim = olcuBirim },
                                 KayitYapanKullaniciBilgileri = new UserDetayDto
                                 {
                                     Id = user.Id,
                                     TcNo = user.TcNo,
                                     FirstName = user.FirstName,
                                     LastName = user.LastName,
                                     Username = user.Username,
                                     Email = user.Email,
                                     PhoneNumber = user.PhoneNumber,
                                     Address = user.Address
                                 },
                                 Adet = stok.Adet,
                                 GirisTarihi = stok.GirisTarihi
                             };
                return result.ToList();
            }
        }
    }
}
