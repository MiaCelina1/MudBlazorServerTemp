using Microsoft.EntityFrameworkCore;

namespace BServerTempWithMud.Models
{
	public class MyDbContext:DbContext
	{
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            

        }

		public DbSet<MyUser> MyUsers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

	}
}
