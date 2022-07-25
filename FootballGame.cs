using System;

namespace ManagerGame
{
    public class FootballGame {
        private Random rand = new Random();
        private Team hTeam = default!;
        private Team aTeam = default!;
        private int MaxDrives = default!;
        private int currentDrive = 0;
        private int Down = default!;
        private int Distance = default!;
        private int YardLine = default!;
        private int Gain = default!;
        private PlayType playtype = default!;
        private Team activeTeam = default!;
        private int hTeamScore = default!;
        private int aTeamScore = default!;

        /// <summary>Creates a game with two teams and the number of drives the game will last</summary>
        /// <returns>An instance of the football game class</returns>
        public FootballGame (Team t1, Team t2, int maxDrives) {
            this.hTeam = t1;
            this.aTeam = t2;
            this.MaxDrives = maxDrives * 2;
            this.activeTeam = this.aTeam; // Away team starts with the ball
            NewDrive();
        }

        /// <summary>Resets global variables for a new drive to start </summary>
        private void NewDrive(){
            currentDrive++;
            Down = 1;
            Distance = 10;
            YardLine = 25;
            Gain = 0;
        }

        /// <summary>Starts the flow of the game</summary>
        public void StartGame(){
            GameRunning();
        }

        /// <summary>Switches the active team after a touchdown or turnover, usually</summary>
        private void SwitchSides(){
            if (this.activeTeam == this.aTeam){
                this.activeTeam = this.hTeam;
            }
            else {
                this.activeTeam = this.aTeam;
            }
            NewDrive();
        }

        /// <summary>
        ///Main code for running a game. Runs until max drives has been reached. 
        /// Responsibilities include: getting user input, execute play, and give user feedback 
        /// based on what happened on the play, then repeats.
        /// </summary>
        private void GameRunning(){
            while (currentDrive <= MaxDrives){
                playtype = PlayTransformer.KeyToPlayType(Console.ReadKey().Key);
                Console.Clear();
                Console.WriteLine();
                ExecutePlay();
                Console.WriteLine("Gain: " + Gain);
                Console.WriteLine();
                if (YardLine < 100){
                    if (YardLine > 50){ 
                        Console.WriteLine("Yardline: " + (50 - (YardLine % 50)));
                    }
                    else{
                        Console.WriteLine("YardLine: " + (-YardLine));
                    }
                    Console.WriteLine(DownAndDistance());
                }
                if (YardLine >= 100){
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
                    NewDrive();
                }
            }
        }

        /// <summary>Runs extra point after touchdown</summary>
        private void ExtraPoint(){
            Console.WriteLine("Go for 2?");
            playtype = PlayTransformer.KeyToPlayType(Console.ReadKey().Key);
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
                playtype = PlayTransformer.KeyToPlayType(Console.ReadKey().Key);
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
            // Check playtype
            switch (playtype){
                case PlayType.RunPlay :
                    Gain = rand.Next(-2, 10);
                    break;
                case PlayType.PassPlay :
                    Gain = rand.Next(-10, 20);
                    break;
                case PlayType.Punt :
                    Down = 5;
                    break;
                default : 
                    Gain = rand.Next(-2, 10);
                    break;
            }

            // Change yardline and distance
            YardLine += Gain;
            Distance -= Gain;

            // Change down and check if the team gained a first down
            if (Distance > 0){
                Down++;
            }
            else {
                Console.WriteLine("FIRST DOWN!");
                Down = 1;
                Distance = 10;
            }

            // Check for turnover, and let the user know
            if (Down > 4){
                Console.WriteLine("TURNOVER");
                SwitchSides();
                Console.WriteLine(this.activeTeam.Name + " has possession");
            }
        }
    }
}