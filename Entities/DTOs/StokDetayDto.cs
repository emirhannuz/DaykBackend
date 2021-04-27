using Core.Entites.Abstract;
using System;

namespace Entities.DTOs
{
    public class StokDetayDto : IDto
    {
        public int Id { get; set; }
        public UrunDetayDto UrunBilgileri { get; set; }
        public UserDetayDto KayitYapanKullaniciBilgileri { get; set; }
        public int Adet { get; set; }
        public DateTime GirisTarihi { get; set; }
    }
}
