using NBAGames.Infrastructure;
using System.Threading.Tasks;

namespace NBAGames.Interfaces
{
    public interface INBAGamesRequest
    {
        Task<NBAGamesDto> GetGamesBySeason(int season);
    }
}
