using System;

namespace ManagerGame
{
    public class Game {
        private string[] teamNames = new string[] {"Bears", "Lions", "Packers", "Vikings", "Falcons", "Panthers", "Saints", "Buccaneers", "Giants", "Cowboys", "Commanders", "Eagles", "Cardinals", "Rams", "49ers", "Seahawks", "Ravens", "Bengals", "Browns", "Steelers", "Texans", "Colts", "Jaguars", "Titans", "Bills", "Dolphins", "Patriots", "Jets", "Broncos", "Chiefs", "Raiders", "Chargers"};


        private DivisionsName[] divisionNames = new DivisionsName[] {
            DivisionsName.North, DivisionsName.South, DivisionsName.East, DivisionsName.West
        };
        public Team[] teams = default!;

        /// <summary>User team</summary>
        Team t1 = default!; // User Team
        Team t2 = default!;

        FootballGame fGame = default!;
        
        /// <summary>True until the game / program should stop running</summary>
        bool playgame = true;
        Random rand = new Random();
        /// <summary>Creates an instance of the game class</summary>
        public Game () {
            teams = new Team[32];
            for(int i = 0; i < 32; i++){
                if (i<16){
                    if (i < 4){
                        teams[i] = new Team(teamNames[i], DivisionsName.North, ConferenceName.NFC);
                    }
                    else if (i < 8){
                        teams[i] = new Team(teamNames[i], DivisionsName.South, ConferenceName.NFC);
                    }
                    else if (i < 12){
                        teams[i] = new Team(teamNames[i], DivisionsName.East, ConferenceName.NFC);
                    }
                    else{
                        teams[i] = new Team(teamNames[i], DivisionsName.West, ConferenceName.NFC);
                    }
                }
                if (i>=16){
                    if (i < 4){
                        teams[i] = new Team(teamNames[i], DivisionsName.North, ConferenceName.AFC);
                    }
                    else if (i < 8){
                        teams[i] = new Team(teamNames[i], DivisionsName.South, ConferenceName.AFC);
                    }
                    else if (i < 12){
                        teams[i] = new Team(teamNames[i], DivisionsName.East, ConferenceName.AFC);
                    }
                    else{
                        teams[i] = new Team(teamNames[i], DivisionsName.West, ConferenceName.AFC);
                    }
                }
                CreateRandomTeam(teams[i]);
            }
        }

        /// <summary>Method called when the game should run</summary>
        public void Run(){

            // Create user team
            t1 = teams[0]; // Bears
            t2 = teams[1]; // Lions
            var newPlayer = true;
            Console.WriteLine("Do you want to start a new game? (Y/N)");
            var uInput = Console.ReadKey();
            switch (uInput.Key){
                case ConsoleKey.Y :
                    newPlayer = true;
                    break;
                default : 
                    newPlayer = false;
                    break;
            }

            if (newPlayer){
                Console.Clear();
                Console.WriteLine("Welcome to NFL Manager");
                Console.WriteLine("To start off, we need to pick some players for your team");
                Console.WriteLine("Press any key when you're ready");
                Console.ReadKey();
                PickTeam();
            }
            else {
                LoadGame();
            }

            while (playgame){

                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Pick your team");
                Console.WriteLine("2: Randomize teams");
                Console.WriteLine("3: Play Game");
                Console.WriteLine("4: View your current roster");
                Console.WriteLine("5: View Standings");
                Console.WriteLine("6: Save Game");
                Console.WriteLine("7: Exit game");
                var input = Console.ReadKey();
                Console.Clear();

                switch(input.Key){
                    case ConsoleKey.D1 :
                        PickTeam();
                        break;
                    case ConsoleKey.D2 :
                        CreateRandomTeam(t1);
                        break;
                    case ConsoleKey.D3 :
                        fGame = new FootballGame(t1, t2, 2);
                        fGame.StartGame();
                        break;
                    case ConsoleKey.D4 : 
                        DisplayTeam();
                        break;
                    case ConsoleKey.D5 :
                        DisplayStandings();
                        break;
                    case ConsoleKey.D6 :
                        SaveGame();
                        break;
                    case ConsoleKey.D7 :
                        playgame = false;
                        break;
                    default :
                        break;
                }
            }
        }

        private void DisplayStandings(){
            Console.Clear();
            Console.WriteLine("1: View NFL");
            Console.WriteLine("2: View NFC");
            Console.WriteLine("3: View AFC");
            Console.WriteLine("Press any key to go back");

            switch(Console.ReadKey().Key){
                case ConsoleKey.D1 :
                    DisplayNFL();
                    break;
                case ConsoleKey.D2 :
                    DisplayNFC();
                    break;
                case ConsoleKey.D3 :
                    DisplayAFC();
                    break;
                default :
                    break;
            }
        }
        private void DisplayNFL(){
            Console.Clear();
            foreach(Team t in teams){
                Console.WriteLine(t);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        private void DisplayNFC(){
            Console.Clear();

            foreach(Team t in teams){
                if (t.conference == ConferenceName.NFC){
                    Console.WriteLine(t);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();

        }

        private void DisplayAFC(){
            Console.Clear();

            foreach(Team t in teams){
                if (t.conference == ConferenceName.AFC){
                    Console.WriteLine(t);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints all players on the team nicely to the user
        /// </summary>
        private void DisplayTeam(){
            Console.WriteLine("Team:              Record      Win %");
            Console.WriteLine(t1);
            Console.WriteLine("Name                           Age     #     Pos     OVR");
            Console.WriteLine("--------------------------------------------------------");

            // Print offensive players
            foreach(Player p in t1.oPlayers){
                Console.WriteLine(p);
            }

            // Print defensive players
            foreach(Player p in t1.dPlayers){
                Console.Write(p.fName + " " + p.lName);
                for(int i = 0; i < (30-(p.fName.Length+p.lName.Length)); i++){
                    Console.Write(" ");
                }
                Console.Write(p.Age + "      ");
                if (p.Number <= 9){
                    Console.Write("0");
                }
                Console.Write(p.Number + "    " + p.Pos);
                if (p.Pos == Position.S){
                    Console.Write(" ");
                }
                Console.Write("      ");
                Console.WriteLine(p.Overall);
            }

            Console.WriteLine();
            Console.WriteLine("Team Overall:                                        " + t1.TeamOverall());
            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        private void SaveGame(){
            using (StreamWriter outputfile = new StreamWriter(Path.Combine("SaveFiles", "save1.txt"))){
                outputfile.WriteLine("OFFENSE");
                foreach(Player p in t1.oPlayers){
                    outputfile.WriteLine(p.fName + "," + p.lName + "," + p.Age + "," + p.Number + "," + p.Pos + "," + p.Overall);
                }
                outputfile.WriteLine("DEFENSE");
                foreach(Player p in t1.dPlayers){
                    outputfile.WriteLine(p.fName + "," + p.lName + "," + p.Age + "," + p.Number + "," + p.Pos + "," + p.Overall);
                }
            }
        }

        private void LoadGame(){
            using (StreamReader outputfile = new StreamReader(Path.Combine("SaveFiles", "save1.txt"))){
                string reading = "1";
                for (int i = 0; i < (t1.oPlayers.Length + t1.dPlayers.Length); i++){
                    reading = outputfile.ReadLine();
                    if (reading == "OFFENSE"){
                        i--;
                    }
                    else if (reading == "DEFENSE"){
                        i--;
                    }
                    else{
                        if (reading != null){
                            string[] splitReading = reading.Split(",");

                            t1.AddPlayer(splitReading[0], splitReading[1], Int32.Parse(splitReading[2]), Int32.Parse(splitReading[3]), PositionTransformer.stringToPos(splitReading[4]), Int32.Parse(splitReading[5]));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Allows the player to choose between 3 randomly generated players for each position
        /// </summary>
        private void PickTeam(){
            Console.Clear();
            var oPositions = new Position[5] {Position.QB, Position.RB, Position.WR, Position.OL, Position.TE};
            
            for (int i = 0; i < t1.oPlayers.Length; i++){
                Console.Clear();
                var newPlayers = new Player[3];
                Console.WriteLine("Pick a " + oPositions[i]);
                Console.WriteLine();
                Console.WriteLine("   Name                           Age     #     Pos     OVR");
                Console.WriteLine("-----------------------------------------------------------");
                
                for (int j = 0; j < newPlayers.Length; j++){
                    newPlayers[j] = new OPlayer(oPositions[i]);
                    Console.WriteLine((j+1) + ": " + newPlayers[j]);
                }
                Console.WriteLine("Which player would you like to add to your team?");
                var input = Console.ReadKey();
                switch (input.Key){
                    case ConsoleKey.D1 :
                        t1.oPlayers[i] = newPlayers[0];
                        break;
                    case ConsoleKey.D2 :
                        t1.oPlayers[i] = newPlayers[1];
                        break;
                    case ConsoleKey.D3 :
                        t1.oPlayers[i] = newPlayers[2];
                        break;
                    default :
                        t1.oPlayers[i] = newPlayers[rand.Next(3)];
                        break;
                }
            }

            Console.Clear();
            var dPositions = new Position[5] {Position.DE, Position.DT, Position.CB, Position.S, Position.LB};
            
            for (int i = 0; i < t1.dPlayers.Length; i++){
                Console.Clear();
                var newPlayers = new Player[3];
                Console.WriteLine("Pick a " + dPositions[i]);
                Console.WriteLine();
                Console.WriteLine("   Name                           Age     #     Pos     OVR");
                Console.WriteLine("-----------------------------------------------------------");
                
                for (int j = 0; j < newPlayers.Length; j++){
                    newPlayers[j] = new DPlayer(dPositions[i]);
                    Console.WriteLine((j+1) + ": " + newPlayers[j]);
                }
                Console.WriteLine("Which player would you like to add to your team?");
                var input = Console.ReadKey();
                switch (input.Key){
                    case ConsoleKey.D1 :
                        t1.dPlayers[i] = newPlayers[0];
                        break;
                    case ConsoleKey.D2 :
                        t1.dPlayers[i] = newPlayers[1];
                        break;
                    case ConsoleKey.D3 :
                        t1.dPlayers[i] = newPlayers[2];
                        break;
                    default :
                        t1.dPlayers[i] = newPlayers[rand.Next(3)];
                        break;
                }
            }
        }

        /// <summary>
        /// Creates a random team with randomized players and skill
        /// </summary>
        public void CreateRandomTeam(Team team){
            team.RandomTeam();
        }
    }
}