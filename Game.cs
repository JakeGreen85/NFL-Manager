using System;

namespace ManagerGame
{
    public class Game {
        Team t1;
        Team t2;
        FootballGame fGame;
        /// <summary>Creates an instance of the game class</summary>
        public Game () {

        }

        /// <summary>Method called when the game should run</summary>
        public void Run(){
            // Console.WriteLine(t1.Name);
            // Console.WriteLine("Name    Age # Pos OVR");
            // foreach(Player p in t1.oPlayers){
            //     Console.WriteLine(p.fName[0] + ". " + p.lName + " " + p.Age + " " + p.Number + " " + p.Pos + " " + p.Overall);
            // }
            // foreach(Player p in t1.dPlayers){
            //     Console.WriteLine(p.fName[0] + ". " + p.lName + " " + p.Age + " " + p.Number + " " + p.Pos + " " + p.Overall);
            // }
            // Console.WriteLine();
            // Console.WriteLine(t2.Name);
            // Console.WriteLine("Name    Age # Pos OVR");
            // foreach(Player p in t2.oPlayers){
            //     Console.WriteLine(p.fName[0] + ". " + p.lName + " " + p.Age + " " + p.Number + " " + p.Pos + " " + p.Overall);
            // }
            // foreach(Player p in t2.dPlayers){
            //     Console.WriteLine(p.fName[0] + ". " + p.lName + " " + p.Age + " " + p.Number + " " + p.Pos + " " + p.Overall);
            // }

            // Add this to the end game:
            // Console.WriteLine("What is your favorite team?");
            // t1 = new Team(Console.ReadLine());

            t1 = new Team("Bears");

            t2 = new Team("Giants");
            CreateRandomTeam(t2);

            Console.WriteLine("Randomize teams?");
            var input = Console.ReadKey();
            Console.Clear();

            if (input.Key == ConsoleKey.Y){
                CreateRandomTeam(t1);
            }
            else {
                // Pick team
            }



            fGame = new FootballGame(t1, t2, 2);

            fGame.StartGame();

        }

        /// <summary>
        /// Creates a random team with randomized players and skill
        /// </summary>
        public void CreateRandomTeam(Team team){
            team.RandomTeam();
        }
    }
}