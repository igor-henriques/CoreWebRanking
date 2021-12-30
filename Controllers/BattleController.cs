namespace CoreRankingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BattleController : ControllerBase
{
    private readonly IBattleRepository _context;

    public BattleController(IBattleRepository _context)
    {        
        this._context = _context;
    }

    // GET: api/Battle
    [HttpGet("GetBattlesOrderedByKill")]
    public async Task<IActionResult> GetBattlesOrderedByKill()
    {
        var response = await _context.GetBattlesOrderedByKill();

        return Ok(response.ToList());
    }

    [HttpGet("GetBattlesOrderedByDeath")]
    public async Task<IActionResult> GetBattlesOrderedByDeath()
    {
        var response = await _context.GetBattlesOrderedByDeath();

        return Ok(response.ToList());
    }

    [HttpPost("GetSingleBattle")]
    public async Task<IActionResult> GetSingleBattle([FromBody] int roleId)
    {
        if (roleId < 0) return NotFound();

        var battle = await _context.GetSingleBattle(roleId);

        if (battle is null) return NotFound("Não existe registros de batalha para o personagem especificado");

        return Ok(battle);
    }

    [HttpPost("GetBattlesByKiller")]
    public async Task<IActionResult> GetBattlesByKiller([FromBody] string roleName)
    {
        if (string.IsNullOrEmpty(roleName)) return BadRequest("Nome do personagem inválido");

        var battle = await _context.GetBattlesByKiller(roleName);

        if (battle is null) return NotFound("Não existe registros de batalha para o personagem especificado");

        return Ok(battle.ToList());
    }

    [HttpPost("GetBattlesByKilled")]
    public async Task<IActionResult> GetBattlesByKilled([FromBody] string roleName)
    {
        if (string.IsNullOrEmpty(roleName)) return BadRequest("Nome do personagem inválido");

        var battle = await _context.GetBattlesByKilled(roleName);

        if (battle is null) return NotFound("Não existe registros de batalha para o personagem especificado");

        return Ok(battle.ToList());
    }
}