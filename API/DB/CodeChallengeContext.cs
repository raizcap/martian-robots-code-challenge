using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class CodeChallengeContext : DbContext
    {
        public CodeChallengeContext(DbContextOptions<CodeChallengeContext> options)
            : base(options)
        {

        }

        public DbSet<Surface> Surfaces { get; set; }

        public DbSet<LostRobot> LostRobots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Surface>()
                .HasIndex(table => new
                {
                    table.xSize,
                    table.ySize
                }).IsUnique();
            
            modelBuilder.Entity<Surface>()
                .HasMany(a => a.LostRobots)
                .WithOne(b => b.surface)
                .HasForeignKey(surface => surface.surfaceId);
        }
    }
}