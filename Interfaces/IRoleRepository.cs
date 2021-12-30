namespace CoreRankingAPI.Interfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRoles();
    Task<IEnumerable<Role>> GetRolesByClass(string className);
    Task<Role> GetSingleRole(int roleId);
    Task<IEnumerable<Banned>> GetBanRecords(int roleId);
    Task<IEnumerable<Role>> GetTopRankingByDay();
    Task<IEnumerable<Role>> GetTopRankingByWeek();
    Task<IEnumerable<Role>> GetTopRankingByMonth();
}
