using Newtonsoft.Json;

namespace NBAGames.Infrastructure
{
    public class Meta
    {
        [JsonProperty("total_pages")]
        public int TotalPges { get; set; }

        [JsonProperty("current_page")]
        public int CurrentPAge { get; set; }

        [JsonProperty("next_page")]
        public int NextPage { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}
