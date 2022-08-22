using Newtonsoft.Json;

namespace NBAGames.Infrastructure
{
    public class Data
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("home_team")]
        public Team HomeTeam { get; set; }

        [JsonProperty("home_team_score")]
        public int HomeTeamScore { get; set; }

        [JsonProperty("visitor_team")]
        public Team VisitorTeam { get; set; }

        [JsonProperty("visitor_team_score")]
        public int VisitorTeamScore { get; set; }
    }
}
