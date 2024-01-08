using Questao2.Exceptions;
using Questao2.Models;

namespace Questao2.Services
{
    public class FootballService
    {
        private readonly FootballApiService _apiService;

        public FootballService()
        {
            _apiService = new FootballApiService(new HttpClient());
        }

        public async Task<int> GetGoalsByTeamByYear(int year, string teamName)
        {
            if (!IsvalidYear(year))
                throw new InvalidYearException();

            if(!IsvalidTeam(teamName))
                throw new InvalidTeamException();

            List<Game> gamesOfTeam = await _apiService.GetGamesByYearAndTeam(year, teamName);

            return GetTotalGoals(gamesOfTeam, teamName);
        }

        private int GetTotalGoals(List<Game> gamesOfTeam, string teamName)
        {
            int totalGoals = gamesOfTeam
                .Where(game => game.team1 == teamName)
                .Sum(game => game.team1goals);

            totalGoals += gamesOfTeam
                .Where(game => game.team2 == teamName)
                .Sum(game => game.team2goals);

            return totalGoals;
        }

        private bool IsvalidTeam(string team)
        {
            return !string.IsNullOrEmpty(team) || !string.IsNullOrWhiteSpace(team);
        }

        private bool IsvalidYear(int year)
        {
            return year > 0 && year < DateTime.UtcNow.Year;
        }
    }
}
