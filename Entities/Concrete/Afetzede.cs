using Core.Entites.Abstract;
using System;

namespace Entities.Concrete
{
    public class Afetzede : IEntity
    {
        public int Id { get; set; }
        public string TcYuNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string CepTelefonuNumarasi { get; set; }
        public string AcikAdres { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int KayitYapanId { get; set; }
    }
}
