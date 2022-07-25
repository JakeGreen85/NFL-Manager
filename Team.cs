using System;

namespace ManagerGame {
    public class Team {

        // Name of the team
        public string Name {get; private set;} = default!;

        // List of all players on the team
        public Player[] Players {get; private set;} = default!;

        // List of offensive players
        public Player[] oPlayers {get; private set;} = default!;

        // List of defensive players
        public Player[] dPlayers {get; private set;} = default!;
        
        /// <summary>
        /// Creates a team with the given name and 5 random offensive players and 5 random defensive players
        /// </summary>
        public Team (string name) {
            this.Name = name;
        }

        /// <summary>
        /// Creates a random team
        /// </summary>
        public void RandomTeam(){
            this.oPlayers = GetOffensivePlayers();
            this.dPlayers = GetDefensivePlayers();
        }


        /// <summary>
        /// Creates 5 random offensive players
        /// </summary>
        /// <returns>
        /// A list of 5 offensive players
        /// </returns>
        private Player[] GetOffensivePlayers(){
            return new Player[5]{new OPlayer(Position.QB), new OPlayer(Position.RB), new OPlayer(Position.WR), new OPlayer(Position.OL), new OPlayer(Position.TE)};
        }

        /// <summary>
        /// Creates 5 random defensive players
        /// </summary>
        /// <returns>
        /// A list of 5 defensive players
        /// </returns>
        private Player[] GetDefensivePlayers(){
            return new Player[5]{new DPlayer(Position.DE), new DPlayer(Position.DT), new DPlayer(Position.CB), new DPlayer(Position.S), new DPlayer(Position.LB)};
        }

    }
}