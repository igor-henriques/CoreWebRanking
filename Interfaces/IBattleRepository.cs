namespace CoreRankingAPI.Interfaces;

public interface IBattleRepository
{
    Task<List<Battle>> GetBattles();
    Task<Battle> GetBattle(int id);
}
