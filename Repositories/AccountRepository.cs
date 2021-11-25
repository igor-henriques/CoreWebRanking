namespace CoreRankingAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CoreRankingContext _context;
        public AccountRepository(CoreRankingContext _context)
        {
            this._context = _context;
        }
    }
}
