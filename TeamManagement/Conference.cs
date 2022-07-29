using System;

namespace ManagerGame
{
    public class Conference {
        Team[] teams = default!;
        Division[] divisions = default!;
        string Name = default!;
        public Conference(string name, Team[] givenTeams, Division[] givenDivisions){
            this.Name = name;
            this.teams = givenTeams;
            this.divisions = givenDivisions;
        }

        public void PrintConference(){
            foreach(Division d in divisions){
                Console.WriteLine(this.Name + " " + d.Name);
                Console.WriteLine("----------------------------");
                Console.WriteLine("Team              Record              Win %");
                foreach(Team t in d.teams){
                    Console.WriteLine(t);
                }
            }
        }
    }
}