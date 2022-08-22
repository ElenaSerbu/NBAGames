using NBAGames.Models;
using System.Threading.Tasks;

namespace NBAGames.Interfaces
{
    public interface INBAGamesService
    {
        Task<NBAGamesModel> GetNBAGames();
    }
}
