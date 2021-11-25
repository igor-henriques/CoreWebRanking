namespace CoreRankingAPI.Repositories
{
    public class BattleRepository : IBattleRepository
    {
        private readonly CoreRankingContext _context;
        public BattleRepository(CoreRankingContext _context)
        {
            this._context = _context;
        }

        public async Task<Battle> GetBattle(int id)
        {
            return await _context.Battle.FindAsync(id);
        }

        public async Task<List<Battle>> GetBattles()
        {
            return await _context.Battle.ToListAsync();
        }
    }
}
