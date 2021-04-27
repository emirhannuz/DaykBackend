using Core.Entites.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class DaykContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = @"(localdb)\mssqllocaldb";
            var db = "Dayk";
            optionsBuilder.UseSqlServer("Server=" + server + ";Database=" + db + ";trusted_connection=True");
        }

        /*tabloların class karşılıkları*/
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<OlcuBirim> OlcuBirimler { get; set; }
        public DbSet<Afetzede> Afetzedeler { get; set; }
        public DbSet<AfetzedeFotograf> AfetzedeFotograflar { get; set; }
        public DbSet<Stok> Stoklar { get; set; }
        public DbSet<StokCikis> StokCikislar { get; set; }
        public DbSet<StokCikisOnay> StokCikisOnaylar { get; set; }
        public DbSet<StokCikisTeslim> StokCikisTeslimler { get; set; }
    }
}
