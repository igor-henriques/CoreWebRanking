namespace CoreRankingAPI.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly CoreRankingContext _context;
    public RoleRepository(CoreRankingContext _context)
    {
        this._context = _context;
    }

    public async Task<IEnumerable<Role>> GetAllRoles(int page, int recordsPerPage)
    {
        return await _context.Role
            .AsNoTracking()
            .Skip(page * recordsPerPage)
            .Take(recordsPerPage)
            .ToListAsync();
    }

    public async Task<IEnumerable<Banned>> GetBanRecords(int roleId)
    {
        return await _context.Banned
            .AsNoTracking()
            .Where(x => x.RoleId.Equals(roleId))
            .ToListAsync();
    }

    public async Task<IEnumerable<Role>> GetRolesByClass(string className)
    {
        return await _context.Role
            .AsNoTracking()
            .Where(x => x.CharacterClass.Equals(className))
            .ToListAsync();
    }

    public async Task<Role> GetSingleRole(int roleId)
    {
        return await _context.Role
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.RoleId.Equals(roleId));
    }

    public async Task<IEnumerable<Role>> GetTopRankingByDay()
    {
        return await _context.Battle
            .AsNoTracking()
            .Include(x => x.KillerRole)
            .Where(x => x.Date >= DateTime.Now.AddDays(-1))
            .OrderByDescending(x => x.KillerRole.Kill)
            .Select(x => x.KillerRole)
            .ToListAsync();
    }

    public async Task<IEnumerable<Role>> GetTopRankingByMonth()
    {
        return await _context.Battle
            .AsNoTracking()
            .Include(x => x.KillerRole)
            .Where(x => x.Date >= DateTime.Now.AddMonths(-1))
            .OrderByDescending(x => x.KillerRole.Kill)
            .Select(x => x.KillerRole)
            .ToListAsync();
    }

    public async Task<IEnumerable<Role>> GetTopRankingByWeek()
    {
        return await _context.Battle
            .AsNoTracking()
            .Include(x => x.KillerRole)
            .Where(x => x.Date >= DateTime.Now.AddDays(-7))
            .OrderByDescending(x => x.KillerRole.Kill)
            .Select(x => x.KillerRole)
            .ToListAsync();
    }
}