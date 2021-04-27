using Core.Entites.Abstract;
using System;

namespace Entities.Concrete
{
    public class StokCikisOnay : IEntity
    {
        public int Id { get; set; }
        public int StokCikisId { get; set; }
        public int OnaylayanKullaniciId { get; set; }
        public DateTime OnayTarihi { get; set; }

    }
}
