using Microsoft.EntityFrameworkCore;

namespace SoundProdHelper.DAL.Write
{
    public class SoundProdHelperContext : DbContext
    {
        public SoundProdHelperContext(DbContextOptions<SoundProdHelperContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoundProdHelperContext).Assembly);
        }
    }
}