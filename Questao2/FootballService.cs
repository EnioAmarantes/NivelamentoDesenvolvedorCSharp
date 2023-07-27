using Newtonsoft.Json;

namespace Questao2
{
    public class FootballService
    {
        private readonly string URI = "https://jsonmock.hackerrank.com/api/football_matches";
        private List<Jogo> Games = new List<Jogo>();
        private HttpResponseMessage response;
        private FootballResponse footballResponse;

        public int GetGoalsByTeamByYear(string time, int year)
        {
            if (year < 0 || year > DateTime.Now.Year)
                throw new InvalidYearException();
            if (string.IsNullOrEmpty(time))
                throw new InvalidTeamException();

            int page = 0;

            do
            {
                GetGames(ref page, time, year);
            } while (page < footballResponse.total_pages);

            return Games.Sum(game => game.team1goals);
        }

        private void GetGames(ref int page, string time, int year)
        {
            response = GetResponse(ref page, time, year);
            footballResponse = GetFootBallResponse(response);
            Games.AddRange(footballResponse.data);
        }
        private HttpResponseMessage GetResponse(ref int page, string time, int year)
        {
            return new HttpClient().GetAsync($"{URI}?page={++page}&year={year}&team1={time}").Result;
        }

        private FootballResponse GetFootBallResponse(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<FootballResponse>(response.Content.ReadAsStringAsync().Result);
        }

    }
}
