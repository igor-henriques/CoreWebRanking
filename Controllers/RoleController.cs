namespace CoreRankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly CoreRankingContext _context;

        public RoleController(CoreRankingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role[]>>> GetRoles([FromQuery] int? chunckSize)
        {
            if (chunckSize.HasValue & chunckSize.GetValueOrDefault() < 5) return BadRequest("O agrupamento precisa ser maior que 5");

            var response = await _context.Role
                .AsNoTracking()
                .Include(x => x.Battles)
                .Chunk(chunckSize.HasValue ? chunckSize.GetValueOrDefault() : 50)
                .ToListAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _context.Role
                .AsNoTracking()
                .Include(x => x.Battles)
                .FirstOrDefaultAsync(x => x.RoleId.Equals(id));

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }
    }
}
