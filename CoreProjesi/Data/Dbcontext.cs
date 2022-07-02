using Microsoft.EntityFrameworkCore;
namespace CoreProjesi.Data
{
    public class Dbcontext
    {
        private DbContextOptions<FotogracilikDbContext> options;

        public Dbcontext(DbContextOptions<FotogracilikDbContext> options)
        {
            this.options = options;
        }

    }
}
