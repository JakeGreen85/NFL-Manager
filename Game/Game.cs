using System;

namespace ManagerGame
{
    public class Game {
        private string[] teamNames = new string[] {"Bears", "Lions", "Packers", "Vikings", "Falcons", "Panthers", "Saints", "Buccaneers", "Giants", "Cowboys", "Commanders", "Eagles", "Cardinals", "Rams", "49ers", "Seahawks", "Ravens", "Bengals", "Browns", "Steelers", "Texans", "Colts", "Jaguars", "Titans", "Bills", "Dolphins", "Patriots", "Jets", "Broncos", "Chiefs", "Raiders", "Chargers"};

        private DivisionsName[] divs = new DivisionsName[16] {DivisionsName.North, DivisionsName.North, DivisionsName.North, DivisionsName.North, DivisionsName.South, DivisionsName.South, DivisionsName.South, DivisionsName.South, DivisionsName.East, DivisionsName.East, DivisionsName.East,DivisionsName.East, DivisionsName.West, DivisionsName.West, DivisionsName.West, DivisionsName.West};

        public Team[] teams = new Team[32];

        FootballGame fGame = default!;
        Random rand = new Random();
        /// <summary>Creates an instance of the game class</summary>
        public Game () {
            StartNewGame();
        }

        /// <summary>Method called when the game should run</summary>
        public void Run(){
            bool playgame = true;
            
            Console.WriteLine("Do you want to start a new game? (Y/N)");
            switch (Console.ReadKey().Key){
                case ConsoleKey.Y :
                    Console.Clear();
                    Console.WriteLine("Welcome to NFL Manager");
                    Console.WriteLine("To start off, we need to pick some players for your team");
                    Console.WriteLine("Press any key when you're ready");
                    Console.ReadKey();
                    PickTeam();
                    break;
                default : 
                    LoadGame();
                    break;
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

                switch(Console.ReadKey().Key){
                    case ConsoleKey.D1 :
                        PickTeam();
                        break;
                    case ConsoleKey.D2 :
                        CreateRandomTeam(teams[0]);
                        break;
                    case ConsoleKey.D3 :
                        fGame = new FootballGame(teams[0], teams[1], 2);
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
                        Console.Clear();
                        playgame = false;
                        break;
                    default :
                        break;
                }
            }
        }

        private void StartNewGame(){
            // Creates 32 random teams
            for(int i = 0; i < teams.Length; i++){
                if (i<16){
                    teams[i] = new Team(teamNames[i], divs[i], ConferenceName.NFC);
                    
                }
                if (i>=16){
                    teams[i] = new Team(teamNames[i], divs[i-16], ConferenceName.AFC);
                }
                CreateRandomTeam(teams[i]);
            }
        }

        private void DisplayStandings(){
            while(true){
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
                        return;
                }
            }
        }
        private void DisplayNFL(){
            Console.Clear();

            Team[] temp = teams;

            foreach(Team t in temp){
                Console.WriteLine(t);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        private void DisplayNFC(){
            Console.Clear();

            DisplayDivison(ConferenceName.NFC, DivisionsName.North);
            Console.WriteLine();
            DisplayDivison(ConferenceName.NFC, DivisionsName.South);
            Console.WriteLine();
            DisplayDivison(ConferenceName.NFC, DivisionsName.East);
            Console.WriteLine();
            DisplayDivison(ConferenceName.NFC, DivisionsName.West);

            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        private void DisplayDivison(ConferenceName conf, DivisionsName div){

            Console.WriteLine(conf.ToString() + " " + div.ToString());
            Console.WriteLine("-----------------------------");
            foreach(Team t in teams){
                if (t.conference == conf && t.division == div){
                    Console.WriteLine(t);
                }
            }
        }

        private void DisplayAFC(){
            Console.Clear();

            DisplayDivison(ConferenceName.AFC, DivisionsName.North);
            Console.WriteLine();
            DisplayDivison(ConferenceName.AFC, DivisionsName.South);
            Console.WriteLine();
            DisplayDivison(ConferenceName.AFC, DivisionsName.East);
            Console.WriteLine();
            DisplayDivison(ConferenceName.AFC, DivisionsName.West);

            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints all players on the team nicely to the user
        /// </summary>
        private void DisplayTeam(){
            Console.Clear();
            Console.WriteLine("Team:              Record      Win %");
            Console.WriteLine(teams[0]);
            Console.WriteLine("Name                           Age     #     Pos     OVR");
            Console.WriteLine("--------------------------------------------------------");

            // Print offensive players
            foreach(Player p in teams[0].oPlayers){
                Console.WriteLine(p);
            }

            // Print defensive players
            foreach(Player p in teams[0].dPlayers){
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
            Console.WriteLine("Team Overall:                                        " + teams[0].TeamOverall());
            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        private void SaveGame(){
            Console.Clear();
            for(int i = 0; i < teams.Length; i++){
                using (StreamWriter outputfile = new StreamWriter(Path.Combine("SaveFiles", "save"+i+".txt"))){
                    outputfile.WriteLine("OFFENSE");
                    foreach(Player p in teams[i].oPlayers){
                        outputfile.WriteLine(p.fName + "," + p.lName + "," + p.Age + "," + p.Number + "," + p.Pos + "," + p.Overall);
                    }
                    outputfile.WriteLine("DEFENSE");
                    foreach(Player p in teams[i].dPlayers){
                        outputfile.WriteLine(p.fName + "," + p.lName + "," + p.Age + "," + p.Number + "," + p.Pos + "," + p.Overall);
                    }
                }
            }
            Console.WriteLine("Game Saved Succesfully");
            Console.ReadKey();
        }

        private void LoadGame(){
            Console.Clear();
            for(int j = 0; j < teams.Length; j++){
                using (StreamReader outputfile = new StreamReader(Path.Combine("SaveFiles", "save1.txt"))){
                    string reading = "1";
                    for (int i = 0; i < (teams[j].oPlayers.Length + teams[j].dPlayers.Length); i++){
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

                                teams[j].AddPlayer(splitReading[0], splitReading[1], Int32.Parse(splitReading[2]), Int32.Parse(splitReading[3]), PositionTransformer.stringToPos(splitReading[4]), Int32.Parse(splitReading[5]));
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Game Loaded Succesfully");
            Console.ReadKey();
        }

        /// <summary>
        /// Allows the player to choose between 3 randomly generated players for each position
        /// </summary>
        private void PickTeam(){
            Console.Clear();

            var oPositions = new Position[5] {Position.QB, Position.RB, Position.WR, Position.OL, Position.TE};
            var dPositions = new Position[5] {Position.DE, Position.DT, Position.CB, Position.S, Position.LB};
            
            for (int i = 0; i < teams[0].oPlayers.Length; i++){
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
                        teams[0].oPlayers[i] = newPlayers[0];
                        break;
                    case ConsoleKey.D2 :
                        teams[0].oPlayers[i] = newPlayers[1];
                        break;
                    case ConsoleKey.D3 :
                        teams[0].oPlayers[i] = newPlayers[2];
                        break;
                    default :
                        teams[0].oPlayers[i] = newPlayers[rand.Next(3)];
                        break;
                }
            }
            
            for (int i = 0; i < teams[0].dPlayers.Length; i++){
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
                        teams[0].dPlayers[i] = newPlayers[0];
                        break;
                    case ConsoleKey.D2 :
                        teams[0].dPlayers[i] = newPlayers[1];
                        break;
                    case ConsoleKey.D3 :
                        teams[0].dPlayers[i] = newPlayers[2];
                        break;
                    default :
                        teams[0].dPlayers[i] = newPlayers[rand.Next(3)];
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Team Succesfully Created");
            Console.ReadKey();
        }

        /// <summary>
        /// Creates a random team with randomized players and skill
        /// </summary>
        public void CreateRandomTeam(Team team){
            team.RandomTeam();
        }
    }
}