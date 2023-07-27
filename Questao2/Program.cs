using Newtonsoft.Json;
using Questao2;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        // Fiz o teste acessando a api diretamente e contando manualmente e o resultado foi:
        // Team Paris Saint - Germain scored 62 goals in 2013
        // Team Chelsea scored 47 goals in 2014
        try
        {
            return new FootballService().GetGoalsByTeamByYear(team, year);
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
            return 0;
        }
    }

}