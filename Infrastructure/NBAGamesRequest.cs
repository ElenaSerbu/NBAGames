using Microsoft.Extensions.Configuration;
using NBAGames.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NBAGames.Infrastructure
{
    public class NBAGamesRequest : INBAGamesRequest
    {
        public IConfiguration configuration;

        public NBAGamesRequest(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<NBAGamesDto> GetGamesBySeason(int season)
        {
            try
            {
                var getNBAGamesUrl = this.configuration["GetNBGames"];
                using (var httpClientRequest = new HttpRequestMessage(HttpMethod.Get, $"{getNBAGamesUrl}?page=1&per_page=50&seasons[]={season}"))
                {
                    httpClientRequest.Headers.Add("X-RapidAPI-Key", this.configuration["X-RapidAPI-Key"]);
                    httpClientRequest.Headers.Add("X-RapidAPI-Host", this.configuration["X-RapidAPI-Host"]);
                    using (var httpClient = new HttpClient())
                    using (var httpResponse = await httpClient.SendAsync(httpClientRequest))
                    {
                        httpResponse.EnsureSuccessStatusCode();

                        var currenciesJson = await httpResponse.Content.ReadAsStringAsync();
                        var currenciesData = JsonConvert.DeserializeObject<NBAGamesDto>(currenciesJson);
                        return currenciesData;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
