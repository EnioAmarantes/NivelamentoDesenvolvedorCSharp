using Newtonsoft.Json;
using Questao2.Models;
using Questao2.Services.Enums;

namespace Questao2.Services
{
    public class FootballApiService
    {
        private readonly HttpClient _httpClient;
        private List<Game> GamesInHouse = new List<Game>();
        private List<Game> VisitGames = new List<Game>();
        private HttpResponseMessage response;

        public FootballApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://jsonmock.hackerrank.com/api/football_matches");
        }

        public async Task<List<Game>> GetGamesByYearAndTeam(int year, string team)
        {
            Task inHouseGames = Task.Run(() => GamesInHouse = GetGames(year, team, EGameLocal.InHouse));
            Task visitGames = Task.Run(() => VisitGames = GetGames(year, team, EGameLocal.Visitant));

            await Task.WhenAll(inHouseGames, visitGames);
            
            return GetTotalGames();
        }

        private List<Game> GetTotalGames()
        {
            List<Game> games = new List<Game>();
            games.AddRange(GamesInHouse);
            games.AddRange(VisitGames);

            return games;
        }

        private List<Game> GetGames(int year, string team, EGameLocal localGame)
        {
            int page = 0;
            FootballResponse footballResponse;
            List<Game> games = new List<Game>();
            do
            {
                response = GetResponse(ref page, year, team, localGame);
                footballResponse = GetFootBallResponse(response);
                games.AddRange(footballResponse.data);
            } while (page < footballResponse.total_pages);
            return games;
        }
        private HttpResponseMessage GetResponse(ref int page, int year, string team, EGameLocal localGame)
        {
            string filters = GetFilters(ref page, year, team, localGame);
            return _httpClient.GetAsync(filters).Result;
        }

        private string GetFilters(ref int page, int year, string team, EGameLocal localGame)
        {
            string filters = String.Empty;
            string local = (localGame == (int)EGameLocal.InHouse) ? "team1" : "team2";

            if (year > 0 || !string.IsNullOrEmpty(team))
            {
                filters += $"?page={++page}";
                filters += year > 0 ? $"&year={year}" : String.Empty;
                filters += !string.IsNullOrEmpty(team) ? $"&{local}={team}": String.Empty;
            }

            return filters;
        }

        private FootballResponse GetFootBallResponse(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<FootballResponse>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
