namespace CoreRankingAPI.Data
{
    public class CoreRankingContext : DbContext
    {
        public CoreRankingContext(DbContextOptions<CoreRankingContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connString = ConnectionBuilder.GetConnectionString();

        //    optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));

        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Account> Account { get; set; }
        public DbSet<Battle> Battle { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Banned> Banned { get; set; }
    }
}
