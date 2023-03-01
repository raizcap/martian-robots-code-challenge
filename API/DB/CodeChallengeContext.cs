using Microsoft.EntityFrameworkCore;

namespace DB;
public class CodeChallengeContext : DbContext
{
    public CodeChallengeContext(DbContextOptions<CodeChallengeContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Surface>().HasKey(table => new {
            table.xSize,
            table.ySize
        });
    }
    public DbSet<Surface> Surfaces { get; set; }

    public DbSet<LostRobot> LostRobots { get; set; }
}

