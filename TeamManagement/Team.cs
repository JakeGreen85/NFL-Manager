using System;

namespace ManagerGame {
    public class Team {
        public ConferenceName conference;
        public DivisionsName division;
        public int wins = 0;
        public int losses = 0;
        public int ties = 0;
        public float winpct {get; private set;} = 0;

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
        public Team (string name, DivisionsName div, ConferenceName conf) {
            this.Name = name;
            this.division = div;
            this.conference = conf;
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

        public void AddPlayer(string fname, string lname, int age, int number, Position pos, int overall){
            for (int i = 0; i < this.oPlayers.Length; i++){
                if (oPlayers[i].Pos == pos){
                    this.oPlayers[i] = new OPlayer(fname, lname, age, number, pos, overall);
                }
            }
            for (int i = 0; i < this.dPlayers.Length; i++){
                if (dPlayers[i].Pos == pos){
                    this.dPlayers[i] = new DPlayer(fname, lname, age, number, pos, overall);
                }
            }
        }

        public int TeamOverall(){
            var temp = 0;
            foreach(Player p in oPlayers){
                temp += p.Overall;
            }
            foreach(Player p in dPlayers){
                temp += p.Overall;
            }
            return temp / (oPlayers.Length + dPlayers.Length);
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

        public override string ToString()
        {
            var str1 = this.Name;
            for(int i = 0; i < 15-this.Name.Length; i++){
                str1 += " ";
            }
            str1 += this.wins;
            if (this.wins<9){
                str1 += "  -  ";
            }
            else{
                str1 += " - ";
            }
            str1 += this.losses;
            if (this.losses<9){
                str1 += "  -  ";
            }
            else{
                str1 += " - ";
            }
            str1 += this.ties;
            if (this.ties<9){
                str1 += " ";
            }
            str1 += $"{this.winpct, 5:G} %";
            return str1;
        }
    }
}