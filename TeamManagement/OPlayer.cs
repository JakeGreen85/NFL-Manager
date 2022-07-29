using System;

namespace ManagerGame
{
    public class OPlayer : Player {
        /// <summary>
        /// Creates an offensive player with the given position.
        /// This constructor randomizes all variables other than position.
        /// </summary>
        public OPlayer (Position pos) {
            this.Age = rand.Next(21, 35);
            this.Pos = pos;
            switch(this.Pos){
                case (Position.QB) :
                    this.fName = QBfNames[rand.Next(QBfNames.Length)];
                    this.lName = QBlNames[rand.Next(QBlNames.Length)];
                    this.Number = rand.Next(5, 10);
                    break;
                case (Position.WR) :
                    this.fName = WRfNames[rand.Next(WRfNames.Length)];
                    this.lName = WRlNames[rand.Next(WRlNames.Length)];
                    this.Number = rand.Next(10, 20);
                    break;
                case (Position.TE) :
                    this.fName = TEfNames[rand.Next(TEfNames.Length)];
                    this.lName = TElNames[rand.Next(TElNames.Length)];
                    this.Number = rand.Next(80, 90);
                    break;
                case (Position.RB) :
                    this.fName = RBfNames[rand.Next(RBfNames.Length)];
                    this.lName = RBlNames[rand.Next(RBlNames.Length)];
                    this.Number = rand.Next(20, 30);
                    break;
                case (Position.OL) : 
                    this.fName = OLfNames[rand.Next(OLfNames.Length)];
                    this.lName = OLlNames[rand.Next(OLlNames.Length)];
                    this.Number = rand.Next(50, 80);
                    break;
                default : 
                    this.Number = rand.Next(1, 100);
                    break;
            }
            this.Overall = rand.Next(50, 100);
        }

        /// <summary>
        /// Creates an offensive player with the given position and number.
        /// Randomizes all other variables
        /// </summary>
        public OPlayer(Position pos, int number){
            this.fName = "Cooper";
            this.lName = "Diggs";
            this.Age = rand.Next(21, 35);
            this.Pos = pos;
            this.Number = number;
            this.Overall = rand.Next(50, 100);
        }

        /// <summary>
        /// Creates an offensive player with the given position, number, and age.
        /// Randomizes all other variables
        /// </summary>
        public OPlayer(Position pos, int number, int age){
            this.fName = "Cooper";
            this.lName = "Diggs";
            this.Age = age;
            this.Pos = pos;
            this.Number = number;
            this.Overall = rand.Next(50, 100);
        }

        /// <summary>
        /// Creates an offensive player with the given position, number, age, and overall.
        /// Randomizes all other variables
        /// </summary>
        public OPlayer(Position pos, int number, int age, int overall){
            this.fName = "Cooper";
            this.lName = "Diggs";
            this.Age = age;
            this.Pos = pos;
            this.Number = number;
            this.Overall = overall;
        }

        /// <summary>
        /// Creates a rookie (21), with an overall between the low and high.
        /// Also with a specified position
        /// </summary>
        public OPlayer(int low, int high, Position pos){
            this.fName = "Justin";
            this.lName = "Allen";
            this.Age = 21;
            this.Pos = pos;
            this.Number = rand.Next(100);
            this.Overall = rand.Next(low, high);
        }

        /// <summary>
        /// Creates an offensive player with the given position, number, age, overall, and name
        /// </summary>
        public OPlayer(string fname, string lname, int age, int number, Position pos, int overall){
            this.fName = fname;
            this.lName = lname;
            this.Age = age;
            this.Pos = pos;
            this.Number = number;
            this.Overall = overall;
        }
    }
}