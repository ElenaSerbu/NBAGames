using Microsoft.AspNetCore.Mvc;
using NBAGames.Interfaces;
using System.Threading.Tasks;

namespace NBAGames.Controllers
{
    public class NBAGamesController : Controller
    {
        private readonly INBAGamesService nbaGamesService;

        public NBAGamesController(INBAGamesService nbaGamesService)
        {
            this.nbaGamesService = nbaGamesService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.nbaGamesService.GetNBAGames());
        }
    }
}
