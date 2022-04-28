using System.Threading;

namespace CoreRankingAPI.Interfaces;

public interface IBattleRepository
{
    Task<IEnumerable<Battle>> GetBattlesOrderedByKill(int page, int recordsPerPage, CancellationToken cancellationToken);
    Task<IEnumerable<Battle>> GetBattlesOrderedByDeath(int page, int recordsPerPage, CancellationToken cancellationToken);
    Task<IEnumerable<Battle>> GetBattlesByKiller(string roleName);
    Task<IEnumerable<Battle>> GetBattlesByKilled(string roleName);
    Task<Battle> GetSingleBattle(int roleId);
}
