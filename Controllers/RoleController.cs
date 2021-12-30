namespace CoreRankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _context;

        public RoleController(IRoleRepository context)
        {
            _context = context;
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _context.GetAllRoles();

            return Ok(response.ToList());
        }

        [HttpPost("GetSingleRole")]
        public async Task<IActionResult> GetSingleRole([FromBody] int roleId)
        {            
            if (roleId <= 0) return BadRequest("ID do personagem inválido");

            var role = await _context.GetSingleRole(roleId);

            if (role == null) return NotFound("Não existe personagem com o ID especificado");

            return Ok(role);
        }

        [HttpPost("GetBanRecordsFromPlayer")]
        public async Task<IActionResult> GetBanRecordsFromPlayer([FromBody] int roleId)
        {            
            if (roleId <= 0) return BadRequest("ID do personagem inválido");

            var banRecords = await _context.GetBanRecords(roleId);

            var response = banRecords.ToList();

            if (response?.Count == 0) return NotFound("Não existe restrição para o personagem especificado");

            return Ok(response);
        }

        [HttpGet("GetTopRankingByDay")]
        public async Task<IActionResult> GetTopRankingByDay()
        {         
            var response = await _context.GetTopRankingByDay();

            return Ok(response.ToList());
        }

        [HttpGet("GetTopRankingByWeek")]
        public async Task<IActionResult> GetTopRankingByWeek()
        {         
            var response = await _context.GetTopRankingByWeek();

            return Ok(response.ToList());
        }

        [HttpGet("GetTopRankingByMonth")]
        public async Task<IActionResult> GetTopRankingByMonth()
        {         
            var response = await _context.GetTopRankingByMonth();

            return Ok(response.ToList());
        }

        [HttpPost("GetRolesByClass")]
        public async Task<IActionResult> GetRolesByClass([FromBody] string characterClass)
        {
            if (string.IsNullOrEmpty(characterClass)) return BadRequest("Classe inválida");

            var response = await _context.GetRolesByClass(Enum.Parse<GameClass>(characterClass).GetDescription());

            return Ok(response.ToList());
        }
    }
}
