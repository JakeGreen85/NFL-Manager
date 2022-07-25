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
            oPlayers = new Player[5];
            dPlayers = new Player[5];
        }

        /// <summary>
        /// Creates a random team
        /// </summary>
        public void RandomTeam(){
            GetOffensivePlayers();
            GetDefensivePlayers();
        }

        public void AddPlayer(Position pos, int low, int high){
            for (int i = 0; i < this.oPlayers.Length; i++){
                if (oPlayers[i].Pos == pos){
                    this.oPlayers[i] = new OPlayer(low, high, pos);
                }
            }
            for (int i = 0; i < this.dPlayers.Length; i++){
                if (dPlayers[i].Pos == pos){
                    this.dPlayers[i] = new DPlayer(low, high, pos);
                }
            }
        }


        /// <summary>
        /// Creates 5 random offensive players
        /// </summary>
        private void GetOffensivePlayers(){
            oPlayers[0] = new OPlayer(Position.QB);
            oPlayers[1] = new OPlayer(Position.RB);
            oPlayers[2] = new OPlayer(Position.WR);
            oPlayers[3] = new OPlayer(Position.OL);
            oPlayers[4] = new OPlayer(Position.TE);
        }

        /// <summary>
        /// Creates 5 random defensive players
        /// </summary>
        private void GetDefensivePlayers(){
            this.dPlayers[0] = new DPlayer(Position.DE);
            this.dPlayers[1] = new DPlayer(Position.DT);
            this.dPlayers[2] = new DPlayer(Position.CB);
            this.dPlayers[3] = new DPlayer(Position.S);
            this.dPlayers[4] = new DPlayer(Position.LB);
        }

    }
}