using System.Threading;

namespace CoreRankingAPI.Repositories
{
    public class BattleRepository : IBattleRepository
    {
        private readonly CoreRankingContext _context;
        public BattleRepository(CoreRankingContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Battle>> GetBattlesByKilled(string roleName)
        {
            return await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .Where(b => b.KilledRole.CharacterName.Equals(roleName))
                .ToListAsync();
        }

        public async Task<IEnumerable<Battle>> GetBattlesByKiller(string roleName)
        {
            return await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .Where(b => b.KillerRole.CharacterName.Equals(roleName))
                .ToListAsync();
        }

        public async Task<IEnumerable<Battle>> GetBattlesOrderedByDeath(int page, int recordsPerPage, CancellationToken cancellationToken)
        {
            return await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .OrderByDescending(x => x.KillerRole.Death)
                .ThenBy(x => x.KillerRole.Level)
                .ThenBy(x => x.KillerRole.LevelDate)
                .Skip(page * recordsPerPage)
                .Take(recordsPerPage)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Battle>> GetBattlesOrderedByKill(int page, int recordsPerPage, CancellationToken cancellationToken)
        {
            return await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .OrderByDescending(x => x.KillerRole.Kill)
                .ThenBy(x => x.KillerRole.Level)
                .ThenBy(x => x.KillerRole.LevelDate)
                .Skip(page * recordsPerPage)
                .Take(recordsPerPage)
                .ToListAsync(cancellationToken);
        }

        public async Task<Battle> GetSingleBattle(int roleId)
        {
            return await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .FirstOrDefaultAsync(x => x.Id.Equals(roleId));
        }
    }
}
