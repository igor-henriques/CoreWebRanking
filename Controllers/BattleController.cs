namespace CoreRankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly CoreRankingContext _context;

        public BattleController(CoreRankingContext context)
        {
            _context = context;
        }

        // GET: api/Battle
        [HttpGet("GetBattlesOrderedByKill")]
        public async Task<ActionResult<IEnumerable<Battle>>> GetBattlesOrderedByKill()
        {
            return await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .OrderByDescending(x => x.KillerRole.Kill)
                .ThenBy(x => x.KillerRole.Level)
                .ThenBy(x => x.KillerRole.LevelDate)
                .ToListAsync();
        }

        [HttpGet("GetBattlesOrderedByDeath")]
        public async Task<ActionResult<IEnumerable<Battle>>> GetBattlesOrderedByDeath()
        {
            return await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .OrderByDescending(x => x.KillerRole.Death)
                .ThenBy(x => x.KillerRole.Level)
                .ThenBy(x => x.KillerRole.LevelDate)
                .ToListAsync();
        }

        [HttpPost("GetBattleById")]
        public async Task<ActionResult<Battle>> GetBattleById([FromBody] int id)
        {
            if (id < 0) return NotFound();

            var battle = await _context.Battle.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (battle is null) return NotFound();

            return battle;
        }

        [HttpGet("GetBattlesByKiller")]
        public async Task<ActionResult<IEnumerable<Battle>>> GetBattlesByKiller(string roleName)
        {
            if (string.IsNullOrEmpty(roleName)) return BadRequest("Informe o nome do personagem");

            var battle = await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .Where(b => b.KilledRole.CharacterName.Equals(roleName))
                .ToListAsync();

            if (battle is null) return NotFound();

            return battle;
        }

        [HttpGet("GetBattlesByKilled")]
        public async Task<ActionResult<IEnumerable<Battle>>> GetBattlesByKilled(string roleName)
        {
            if (string.IsNullOrEmpty(roleName)) return BadRequest("Informe o nome do personagem");

            var battle = await _context.Battle
                .AsNoTracking()
                .Include(x => x.KilledRole)
                .Include(x => x.KillerRole)
                .Where(b => b.KillerRole.CharacterName.Equals(roleName))
                .ToListAsync();

            if (battle is null) return NotFound();

            return battle;
        }
    }
}
