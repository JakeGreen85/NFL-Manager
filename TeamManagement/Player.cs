using System;
using System.Collections.Generic;

namespace ManagerGame
{
    public abstract class Player {
        protected Random rand = new Random();
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

    }
}