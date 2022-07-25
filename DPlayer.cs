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
    }
}