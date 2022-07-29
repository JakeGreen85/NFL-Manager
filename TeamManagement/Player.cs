using System;
using System.Collections.Generic;

namespace ManagerGame
{
    public abstract class Player {
        protected Random rand = new Random();
        protected string[] QBfNames = new string[] {"Tom", "Russell", "Aaron", "Matt", "Matthew", "Kirk", "Ryan", "Ben", "Andy", "Patrick", "Justin", "Jared", "Drew", "Zach", "Cam", "Sam"};
        protected string[] QBlNames = new string[] {"Brady", "Wilson", "Rodgers", "Ryan", "Stafford", "Cousins", "Tannehill", "Roethlisberger", "Dalton", "Mahomes", "Fields", "Goff", "Brees", "Wilson", "Newton", "Darnold"};
        protected string[] RBfNames = new string[] {"Joe", "David", "Alvin", "Saquon", "Christian", "Cam", "Raheem", "Samaje"};
        protected string[] RBlNames = new string[] {"Mixon", "Montgomery", "Kamara", "Barkley", "McCaffrey", "Akers", "Mostert", "Perine"};
        protected string[] WRfNames = new string[] {"Davante", "Tavon", "Ja'marr", "Corey", "Stefon", "Tyreek", "Jerry"};
        protected string[] WRlNames = new string[] {"Adams", "Austin", "Chase", "Davis", "Diggs", "Hill", "Jeudy"};
        protected string[] OLfNames = new string[] {"David", "Terron", "Larry", "Taylor", "Trent", "Tristan", "Tyron", "Lane"};
        protected string[] OLlNames = new string[] {"Bakhtiari", "Armstead", "Borom", "Lewan", "Williams", "Wirfs", "Smith", "Johnson"};
        protected string[] TEfNames = new string[] {"Zach", "Dalton", "Mike", "Dallas", "Kyle", "Darren", "Mark", "Travis"};
        protected string[] TElNames = new string[] {"Ertz", "Schultz", "Gesicki", "Goedert", "Pitts", "Waller", "Andrews", "Kelce"};
        protected string[] DEfNames = new string[] {"Joey", "Nick", "JJ", "Shaq", "Lawrence", "Chase", "Samson", "Robert"};
        protected string[] DElNames = new string[] {"Bosa", "Watt", "Lawson", "Guy", "Young", "Ebukam", "Quinn"};
        protected string[] DTfNames = new string[] {"Calais", "Kenny", "Fletcher", "Aaron", "Cameron", "Javon"};
        protected string[] DTlNames = new string[] {"Campbell", "Clark", "Cox", "Donald", "Heyward", "Kinlaw"};
        protected string[] CBfNames = new string[] {"Jaylon", "Jaylen", "Marshon", "Jaire", "Xavien"};
        protected string[] CBlNames = new string[] {"Johnson", "Ramsey", "Lattimore", "Alexander", "Howard"};
        protected string[] SfNames = new string[] {"Eddie", "Kevin", "Marcus", "Justin", "Minkah"};
        protected string[] SlNames = new string[] {"Jackson", "Byard", "Williams", "Simmons", "Fitzpatrick"};
        protected string[] LBfNames = new string[] {"Roquan", "Fred", "Darius", "Eric", "Bobby", "Micah"};
        protected string[] LBlNames = new string[] {"Smith", "Warner", "Leonard", "Kendricks", "Wagner", "Parsons"};
        public string fName {get; protected set;} = default!;
        public string lName {get; protected set;} = default!;
        public int Age {get; protected set;} = default!;
        public int Number {get; protected set;} = default!;
        public Position Pos {get; protected set;} = default!;
        public int Overall {get; protected set;} = default!;

        /// <summary>Increase player overall by the given amount</summary>
        protected void LevelUp(int increase){
            this.Overall += increase;
        }

        public override string ToString()
        {
            var str1 = fName + " " + lName;
            for(int i = 0; i < (30-(fName.Length+lName.Length)); i++){
                str1 += " ";
            }
            str1 += Age + "      ";
            if (Number <= 9){
                str1 +="0";
            }
            str1 += Number + "    " + Pos;
            if (Pos == Position.S){
                str1 += " ";
            }
            str1 += "      " + Overall;
            return str1;
        }

    }
}