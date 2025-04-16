using Microsoft.EntityFrameworkCore;
using MetroDigital.Infraestructure.Identity.Entities;


namespace MetroDigital.Infrastructure.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        #region DbSets

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Identity
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "Identity");
            modelBuilder.Entity<ApplicationUser>().Metadata.SetIsTableExcludedFromMigrations(true);
            #endregion

            #region RelationShiops


            #endregion
        }
        #endregion
    }
}
