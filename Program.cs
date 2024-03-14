using System;
using System.Collections.Generic;
using System.Linq;

namespace draw
{
    class UCL_draw
    {
        public string TeamName { get; set; }
        public string GroupNumber { get; set; }
        public string Pot { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{TeamName} (Group {GroupNumber}, {Country}, Pot {Pot})";
        }
    }
    class Draw
    {
        static void Main()
        {
            List<UCL_draw> teams = new List<UCL_draw>
            {
                new UCL_draw {TeamName = "Bayern Munich", GroupNumber = "A", Country = "Germany", Pot = "1" },
                new UCL_draw {TeamName = "FC Copenhagen", GroupNumber = "A", Country = "Denmark", Pot = "2"},
                new UCL_draw {TeamName = "Arsenal", GroupNumber = "B", Country = "England", Pot = "1"},
                new UCL_draw {TeamName = "PSV", GroupNumber = "B", Country = "Netherlands", Pot = "2"},
                new UCL_draw {TeamName = "Real Madrid", GroupNumber = "C", Country = "Spain", Pot = "1"},
                new UCL_draw {TeamName = "Napoli", GroupNumber = "C", Country = "Italy", Pot = "2"},
                new UCL_draw {TeamName = "Real Sociedad", GroupNumber = "D", Country = "Spain", Pot = "1"},
                new UCL_draw {TeamName = "Inter Milan", GroupNumber = "D", Country = "Italy", Pot = "2"},
                new UCL_draw {TeamName = "Atletico Madrid", GroupNumber = "E", Country = "Spain", Pot = "1"},
                new UCL_draw {TeamName = "Lazio", GroupNumber = "E", Country = "Italy", Pot = "2"},
                new UCL_draw {TeamName = "Dortmund", GroupNumber = "F", Country = "Germany", Pot = "1" },
                new UCL_draw {TeamName = "PSG", GroupNumber = "F", Country = "France", Pot = "2"},
                new UCL_draw {TeamName = "Manchester City", GroupNumber = "G", Country = "England", Pot = "1"},
                new UCL_draw {TeamName = "RB Leipzig", GroupNumber = "G", Country = "Germany", Pot = "2"},
                new UCL_draw {TeamName = "Barcelona", GroupNumber = "H", Country = "Spain", Pot = "1"},
                new UCL_draw {TeamName = "Porto", GroupNumber = "H", Country = "Portugal", Pot = "2"},
            };
            DrawTeamsRandomly(teams);
        }
        static void DrawTeamsRandomly(List<UCL_draw> teams)
        {
            Random rand = new Random();
            List<UCL_draw> shuffledTeams = teams.OrderBy(t => rand.Next()).ToList();

            for (int i = 0; i < shuffledTeams.Count; i += 2)
            {
                if (i + 1 < shuffledTeams.Count)
                {
                    while (AreTeamsFromSameCountryGroupOrPot(shuffledTeams[i], shuffledTeams[i + 1]))
                    {
                        shuffledTeams = teams.OrderBy(t => rand.Next()).ToList();
                    }

                    Console.WriteLine($"{shuffledTeams[i]} vs {shuffledTeams[i + 1]}");
                }
                else
                {
                    Console.WriteLine($"{shuffledTeams[i]} has a bye");
                }
            }
        }
        static bool AreTeamsFromSameCountryGroupOrPot(UCL_draw team1, UCL_draw team2)
        {
            return team1.Country == team2.Country || team1.Pot == team2.Pot || team1.GroupNumber == team2.GroupNumber;
        }
    }
}
