using System;

namespace ManagerGame
{
    public class DPlayer : Player {
        public DPlayer (Position pos) {
            this.fName = "Aaron";
            this.lName = "Watt";
            this.Age = rand.Next(21, 35);
            this.Pos = pos;
            switch(this.Pos){
                case (Position.DE) :
                    this.Number = rand.Next(95, 100);
                    break;
                case (Position.DT) :
                    this.Number = rand.Next(90, 95);
                    break;
                case (Position.CB) :
                    this.Number = rand.Next(1, 5);
                    break;
                case (Position.S) :
                    this.Number = rand.Next(40, 50);
                    break;
                case (Position.LB) : 
                    this.Number = rand.Next(30, 40);
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
        public DPlayer(Position pos, int number){
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
        public DPlayer(Position pos, int number, int age){
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
        public DPlayer(Position pos, int number, int age, int overall){
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
        public DPlayer(int low, int high, Position pos){
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
        public DPlayer(Position pos, int number, int age, int overall, string fname, string lname){
            this.fName = fname;
            this.lName = lname;
            this.Age = age;
            this.Pos = pos;
            this.Number = number;
            this.Overall = overall;
        }
    }
}