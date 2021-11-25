namespace CoreRankingAPI.Data
{
    public class CoreRankingContext : DbContext
    {
        public CoreRankingContext(DbContextOptions<CoreRankingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(c => c.Battles);
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Battle> Battle { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
