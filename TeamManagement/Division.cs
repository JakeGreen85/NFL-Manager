using System;

namespace ManagerGame
{
    public class Division {
        public Team[] teams = default!;
        public string Name = default!;
        public Division(string name, Team[] givenTeams){
            this.Name = name;
            teams = givenTeams;
        }
    }
}