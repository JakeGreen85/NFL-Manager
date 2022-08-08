using System;

namespace ManagerGame
{
    public class FootballGame {
        private Random rand = new Random();

        /// <summary>Home Team</summary>
        private Team hTeam = default!;

        /// <summary>Away Team</summary>
        private Team aTeam = default!;

        /// <summary>Max number of drives for a game</summary>
        private int MaxDrives = default!;

        /// <summary>The current drive number</summary>
        private int currentDrive = 0;

        /// <summary>The current down being played</summary>
        private int Down = default!;

        /// <summary>The current distance before the team gets a new first down</summary>
        private int Distance = default!;

        /// <summary>The current yard line where the ball is placed</summary>
        private int YardLine = default!;

        /// <summary>How many yards the offense gained on the previous play</summary>
        private int Gain = default!;

        /// <summary>The current play type, given by the player</summary>
        private PlayType playtype = default!;

        /// <summary>The team that is currently on offense</summary>
        private Team activeTeam = default!;

        /// <summary>The team that is currently on defense</summary>
        private Team inactiveTeam = default!;

        /// <summary>The score of the home team</summary>
        private int hTeamScore = default!;

        /// <summary>The score of the away team</summary>
        private int aTeamScore = default!;

        /// <summary>The string representation of the field</summary>
        private string[] field = default!;

        /// <summary>A boolean for whether or not a touchdown should be awarded</summary>
        private bool Touchdown = false;

        /// <summary>A boolean for whether or not a first down should be awareded</summary>
        private bool FirstDown = false;

        /// <summary>A boolean for whether or not a turnover happened</summary>
        private bool Turnover = false;

        /// <summary>Creates a game with two teams and the number of drives the game will last</summary>
        /// <returns>An instance of the football game class</returns>
        public FootballGame (Team t1, Team t2, int maxDrives) {
            this.hTeam = t1;
            this.aTeam = t2;
            this.MaxDrives = maxDrives * 2;
            this.activeTeam = this.aTeam; // Away team starts with the ball
            this.inactiveTeam = this.hTeam;
            this.field = new string[100];
            NewDrive();
        }

        /// <summary>Resets global variables for a new drive to start </summary>
        private void NewDrive(){
            Console.WriteLine("Press any button to start next drive");
            currentDrive++;
            Down = 1;
            Distance = 10;
            if (Turnover){
                YardLine = 100 - YardLine;
                Turnover = false;
            }
            else if (this.playtype == PlayType.Punt){
                YardLine = 100 - (YardLine + 45);
            }
            else {
                YardLine = 25;
            }
            Gain = 0;
            Console.ReadKey();
            this.playtype = PlayType.DriveStart;
            Console.Clear();
        }

        /// <summary>Starts the flow of the game</summary>
        public void StartGame(){
            GameRunning();
        }

        /// <summary>
        /// Method for simulating a game
        /// </summary>
        public void SimGame(){
            // SIMULATE A GAME
        }

        public void SimPlay(){
            this.playtype = AI.SimPlay(this.Down, this.Distance);
        }

        /// <summary>Switches the active team after a touchdown or turnover, usually</summary>
        private void SwitchSides(){
            var temp = this.activeTeam;
            this.activeTeam = this.inactiveTeam;
            this.inactiveTeam = temp;
            NewDrive();
        }

        /// <summary>
        /// Updates the console with the newest information.
        /// Pretty-prints field, score, down and distance, and where on the field they are
        /// </summary>
        private void UpdateField(){
            
            GamePrints.UpdateField(playtype, YardLine, Distance);
            Console.WriteLine();

            // Prints team names and the current score
            Console.ForegroundColor = ConsoleColor.White;
            if (this.activeTeam == this.hTeam){
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(this.hTeam.Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   -   ");
            if (this.activeTeam == this.aTeam){
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(this.aTeam.Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  " + this.hTeamScore + "           " + this.aTeamScore);

            Console.WriteLine();

            Commentary.ExPlay(playtype, Gain, this.activeTeam);

            if (this.FirstDown){
                Console.WriteLine("FIRST DOWN!");
                this.FirstDown = false;
            }

            Console.WriteLine();
            
            // If the result of the play was not a touchdown, then display where the ball is and the down and distance
            if (YardLine < 100){
                if (YardLine > 50){ 
                    Console.WriteLine("Yardline: " + this.inactiveTeam.Name + " " + (50 - (YardLine % 50)));
                }
                else{
                    Console.WriteLine("YardLine: Own " + (YardLine));
                }
                Console.WriteLine(DownAndDistance());
            }
        }

        private void AskUser(){
            Console.WriteLine("R: Runplay, P: Pass play, (K: Punt, F: Field Goal)");
            playtype = PlayTransformer.KeyToPlayType(Console.ReadKey().Key);
            Console.WriteLine();
        }

        private bool CheckFirstDown(){
            if (Distance > 0){
                Down++;
            }

            else if (Distance <= 0 && !Touchdown){
                Down = 1;
                Distance = 10;
                return true;
            }

            // Check for turnover, and let the user know
            else if (Down > 4){
                Console.Clear();
                Console.WriteLine("TURNOVER");
                Turnover = true;
                SwitchSides();
                Console.WriteLine(this.activeTeam.Name + " has possession");
                return false;
            }
            return false;
        }

        private bool CheckTouchDown(){
            if (YardLine >= 100){
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Main code for running a game. Runs until max drives has been reached. 
        /// Responsibilities include: getting user input, execute play, and give user feedback 
        /// based on what happened on the play, then repeats.
        /// </summary>
        private void GameRunning(){
            UpdateField();
            while (currentDrive <= MaxDrives){
                if (activeTeam == this.hTeam){
                    AskUser();
                }
                else {
                    Console.ReadKey();
                    SimPlay();
                }

                ExecutePlay();

                FirstDown = CheckFirstDown();
                Touchdown = CheckTouchDown();

                // Check if a touchdown has been scored
                if (Touchdown){
                    Console.Clear();
                    this.Touchdown = true;
                    Console.WriteLine("TOUCHDOWN!");
                    Console.WriteLine(this.activeTeam.Name + " scored");
                    
                    if (this.activeTeam == this.aTeam){
                        this.aTeamScore += 6;
                    }
                    
                    else {
                        this.hTeamScore += 6;
                    }

                    ExtraPoint();
                    SwitchSides();
                }
                else if (FirstDown){
                    Console.WriteLine("FIRST DOWN!");
                }
                UpdateField();
            }

            Console.Clear();

            if (this.aTeamScore != this.hTeamScore){
                Console.Write("The ");
                if (this.aTeamScore < this.hTeamScore){
                    Console.Write(this.hTeam.Name);
                    hTeam.wins ++;
                    aTeam.losses ++;
                }
                else{
                    Console.Write(this.aTeam.Name);
                    aTeam.wins ++;
                    hTeam.losses ++;
                }
                Console.WriteLine(" win!");
            }
            else {
                Console.WriteLine("The game ended in a tie...");
                hTeam.ties ++;
                aTeam.ties ++;
            }

            Console.WriteLine();
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
        }

        /// <summary>Runs extra point after touchdown</summary>
        private void ExtraPoint(){
            if (activeTeam == hTeam){
                Console.WriteLine("Go for 2?");
                playtype = PlayTransformer.KeyToPlayType(Console.ReadKey().Key);
            }
            else {
                playtype = AI.ExtraPoint();
            }

            Console.Clear();
            
            if (playtype == PlayType.OnePoint){
                var kick = rand.Next(100);
                
                if (kick < 92){
                    Console.WriteLine("Extra Point Good");
                    
                    if (this.activeTeam == this.aTeam){
                        this.aTeamScore++;
                    }
                    
                    else {
                        this.hTeamScore++;
                    }
                }
                
                else {
                    Console.WriteLine("Extra Point Missed!");
                }
            }
            
            else {
                Down = 1;
                Distance = 3;
                YardLine = 97;
                UpdateField();
                if (activeTeam == hTeam){
                    playtype = PlayTransformer.KeyToPlayType(Console.ReadKey().Key);
                }
                else{
                    playtype = AI.ExtraPointPlay();
                }
                ExecutePlay();
                
                if (YardLine >= 100){
                    Console.WriteLine("Extra Point Good");
                    
                    if (this.activeTeam == this.aTeam){
                        this.aTeamScore += 2;
                    }
                    
                    else {
                        this.hTeamScore += 2;
                    }
                }
                
                else {
                    Console.WriteLine("No Good!");
                }
            }
            Touchdown = false;
        }

        /// <summary>Pretty-print down and distance</summary>
        /// <returns>String of the down and distance. "(Down) and (Distance)</returns>
        private string DownAndDistance(){
            switch (Down){
                
                case (1) :
                    return "1st & " + Distance;
                
                case (2) :
                    return "2nd & " + Distance;
                
                case (3) :
                    return "3rd & " + Distance;
                
                case (4) :
                    return "4th & " + Distance;
                
                default :
                    return "Down and Distance not found";
            }
        }

        /// <summary>Executes a play call, after user input</summary>
        private void ExecutePlay(){
            Console.Clear();
            // Check playtype
            switch (playtype){
                
                case PlayType.RunPlay :
                    Gain = rand.Next(-2, 10);
                    break;
                
                case PlayType.PassPlay :
                    Gain = rand.Next(-10, 20);
                    break;
                
                case PlayType.Punt :
                    SwitchSides();
                    return;
                default : 
                    Gain = rand.Next(-2, 10);
                    break;
            }

            // Change yardline and distance
            YardLine += Gain;
            Distance -= Gain;

            Touchdown = CheckTouchDown();

            // Change down and check if the team gained a first down
            FirstDown = CheckFirstDown();
        }
    }
}