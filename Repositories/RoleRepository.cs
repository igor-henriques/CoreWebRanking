namespace CoreRankingAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CoreRankingContext _context;
        public RoleRepository(CoreRankingContext _context)
        {
            this._context = _context;
        }
    }
}
