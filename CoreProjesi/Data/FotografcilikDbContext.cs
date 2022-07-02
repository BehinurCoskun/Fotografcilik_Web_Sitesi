
using CoreProjesi.Models;//ekledik
using Microsoft.EntityFrameworkCore;//ekledik


namespace CoreProjesi.Data
{  //adınıa yapsan iyiydi tablodakiyle benzetme 
    public class FotogracilikDbContext : DbContext //yanına DbContext yazmalısın
    {
        public FotogracilikDbContext(DbContextOptions<FotogracilikDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Fotografci> Fotografcis { get; set; }
        public virtual DbSet<Mekan> Mekans { get; set; }

        public virtual DbSet<Musteri> Musteris { get; set; }


    }
}
