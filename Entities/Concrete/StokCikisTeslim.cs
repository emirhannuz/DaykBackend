using Core.Entites.Abstract;
using System;

namespace Entities.Concrete
{
    public class StokCikisTeslim : IEntity
    {
        public int Id { get; set; }
        public int StokCikisId { get; set; }
        public int TeslimEdenKullaniciId { get; set; }
        public DateTime TeslimTarihi{ get; set; }

    }
}
