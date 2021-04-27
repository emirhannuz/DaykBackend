using Core.Entites.Abstract;
using System;

namespace Entities.DTOs
{
    public class StokCikisDetayDto : IDto
    {

        public int Id { get; set; }
        public int Adet { get; set; }
        public AfetzedeDetayDto AfetzedeBilgileri { get; set; }
        public UrunDetayDto UrunBilgileri { get; set; }

        public UserDetayDto? OnaylayanKullaniciBigileri { get; set; }
        public UserDetayDto? TeslimEdenKullaniciBilgileri { get; set; }

        public DateTime? OnayTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
    }
}
