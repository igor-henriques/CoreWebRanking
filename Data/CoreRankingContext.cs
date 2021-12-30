namespace CoreRankingAPI.Data
{
    public class CoreRankingContext : DbContext
    {
        public CoreRankingContext(DbContextOptions<CoreRankingContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; }
        public DbSet<Battle> Battle { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Banned> Banned { get; set; }
    }
}
