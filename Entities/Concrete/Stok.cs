using Core.Entites.Abstract;
using System;

namespace Entities.Concrete
{
    public class Stok : IEntity
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public DateTime GirisTarihi { get; set; }
        public int KayitYapanId { get; set; }
    }
}
