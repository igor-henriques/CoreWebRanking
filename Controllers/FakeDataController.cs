using Bogus;
using static Bogus.DataSets.Name;

namespace CoreRankingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FakeDataController : Controller
{
    private readonly CoreRankingContext context;

    public FakeDataController(CoreRankingContext context)
    {
        this.context = context;
    }

    // GET: api/Battle
    [HttpPost("GenerateRoles/{amount}")]
    public async Task<IActionResult> GenerateRoles([FromRoute] int amount = 2)
    {
        if (amount <= 0)
            return BadRequest("Amount precisa ser maior que 0");

        var accountGenerator = new Faker<Account>()
            .RuleFor(u => u.Login, (f, u) => f.Name.LastName());

        var rolesGenerator = new Faker<Role>()
            .RuleFor(u => u.CharacterName, (f, u) => f.Name.FirstName())
            .RuleFor(u => u.CharacterGender, (f, u) => f.PickRandom<Gender>().ToString())
            .RuleFor(u => u.CharacterClass, (f, u) => f.PickRandom<GameClass>().ToString())
            .RuleFor(o => o.Level, f => f.Random.Number(30, 105))
            .RuleFor(o => o.Doublekill, f => f.Random.Number(0, 100))
            .RuleFor(o => o.Triplekill, f => f.Random.Number(0, 100))
            .RuleFor(o => o.Quadrakill, f => f.Random.Number(0, 100))
            .RuleFor(o => o.Pentakill, f => f.Random.Number(0, 100))
            .RuleFor(o => o.Kill, f => f.Random.Number(0, 10000))
            .RuleFor(o => o.Death, f => f.Random.Number(0, 10000))
            .RuleFor(o => o.Points, f => f.Random.Number(0, 10000))
            .RuleFor(o => o.CollectPoint, f => f.Random.Number(0, 10000));

        var roles = rolesGenerator.Generate(amount);

        foreach (var role in roles)
        {
            var account = accountGenerator.Generate(1).FirstOrDefault();

            context.Account.Add(account);

            await context.SaveChangesAsync();

            role.AccountId = account.Id;
        }

        context.Role.AddRange(roles);

        await context.SaveChangesAsync();

        return Ok();
    }

    // GET: api/Battle
    [HttpPost("GenerateBattles/{amount}")]
    public async Task<IActionResult> GenerateBattles([FromRoute] int amount = 2)
    {
        if (amount <= 0)
            return BadRequest("Amount precisa ser maior que 0");

        var biggestRole = await context.Role.OrderByDescending(x => x.RoleId).FirstOrDefaultAsync();

        if (biggestRole.RoleId < 2)
            return BadRequest("Não há registros de Roles suficientes para gerar essa quantidade de batalha");


        var battlesGenerator = new Faker<Battle>()
            .RuleFor(x => x.KilledId, (f, u) => f.Random.Number(1, biggestRole.RoleId))
            .RuleFor(x => x.KillerId, (f, u) => f.Random.Number(1, biggestRole.RoleId))
            .RuleFor(x => x.Date, (f, u) => DateTime.Now.AddDays(f.Random.Number(-100, 100)).AddSeconds(f.Random.Number(-50000, 50000)));

        var battles = battlesGenerator.Generate(amount);

        context.Battle.AddRange(battles);

        await context.SaveChangesAsync();

        return Ok();
    }
}
