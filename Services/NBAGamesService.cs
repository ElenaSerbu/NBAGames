using AutoMapper;
using NBAGames.Infrastructure;
using NBAGames.Interfaces;
using NBAGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAGames.Services
{
    public class NBAGamesService : INBAGamesService
    {
        public readonly INBAGamesRequest nbaGamesRequest;
        //private readonly IMapper mapper;

        public NBAGamesService(INBAGamesRequest nbaGamesRequest)
        {
            this.nbaGamesRequest = nbaGamesRequest;
            //this.mapper = mapper;
        }

        public async Task<NBAGamesModel> GetNBAGames()
        {
            //a better mechanism can can be implemented here in order to retrieve all the games for both 2017 and 2019 seasons
            //make an request and get all the pages(based on games/page) and games
            //create all the requests needed(e.g. 14pages(requests)-> 100 games/page)
            //save the requests in db; now the filtering and sorting is made in memory
            var nbaGamesFirstBatch = await this.nbaGamesRequest.GetGamesBySeason(2017);
            var nbaGamesSecondBatch = await this.nbaGamesRequest.GetGamesBySeason(2019);

            var nbaGames = new List<NBAGameModel>();
            foreach(var nbaGame in nbaGamesFirstBatch.Data)
            {
                if(nbaGame.HomeTeamScore > nbaGame.VisitorTeamScore)
                {
                    nbaGames.Add(CreateNBAGameModel(nbaGame.Date, nbaGame.HomeTeamScore, nbaGame.HomeTeam.Name));
                }
                else
                {
                    nbaGames.Add(CreateNBAGameModel(nbaGame.Date, nbaGame.VisitorTeamScore, nbaGame.VisitorTeam.Name));
                }
                
            }

            var nbaGamesModel = new NBAGamesModel();
            nbaGamesModel.NBAGames = nbaGames.OrderByDescending(n => n.Score).Take(10).OrderBy(n => n.Name).ToList();

            return nbaGamesModel;
        }

        //create a mapping class for this
        public NBAGameModel CreateNBAGameModel(string date, int score, string name)
        {
            return new NBAGameModel
            {
                Date = DateTime.Parse(date),
                Score = score,
                Name = name
            };
        }
    }
}
