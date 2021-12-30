namespace CoreRankingAPI.Interfaces;

public interface IBattleRepository
{
    Task<IEnumerable<Battle>> GetBattlesOrderedByKill();
    Task<IEnumerable<Battle>> GetBattlesOrderedByDeath();
    Task<IEnumerable<Battle>> GetBattlesByKiller(string roleName);
    Task<IEnumerable<Battle>> GetBattlesByKilled(string roleName);
    Task<Battle> GetSingleBattle(int roleId);
}
