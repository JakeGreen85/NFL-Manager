using System;

namespace ManagerGame
{
    public static class AI {
        public static PlayType SimPlay(int down, int dist){
            Random rand = new Random();

            // 1st DOWN
            if (down == 1){
                switch(rand.Next(3)){
                    case 0 :
                        return PlayType.RunPlay;
                    case 1 :
                        return PlayType.RunPlay;
                    case 2 : 
                        return PlayType.PassPlay;
                    default :
                        return PlayType.RunPlay;
                }
            }

            // 2nd DOWN
            else if (down == 2 && dist < 8){
                switch(rand.Next(3)){
                    case 0 :
                        return PlayType.RunPlay;
                    case 1 :
                        return PlayType.RunPlay;
                    case 2 : 
                        return PlayType.PassPlay;
                    default :
                        return PlayType.RunPlay;
                }
            }
            else if (down == 2 && dist >= 8){
                switch(rand.Next(3)){
                    case 0 :
                        return PlayType.RunPlay;
                    case 1 :
                        return PlayType.PassPlay;
                    case 2 : 
                        return PlayType.PassPlay;
                    default :
                        return PlayType.RunPlay;
                }
            }

            // 3rd DOWN
            else if (down == 3 && dist < 5){
                switch(rand.Next(3)){
                    case 0 :
                        return PlayType.RunPlay;
                    case 1 :
                        return PlayType.RunPlay;
                    case 2 : 
                        return PlayType.PassPlay;
                    default :
                        return PlayType.RunPlay;
                }
            }
            else if (down == 3 && dist >= 5){
                switch(rand.Next(3)){
                    case 0 :
                        return PlayType.RunPlay;
                    case 1 :
                        return PlayType.PassPlay;
                    case 2 : 
                        return PlayType.PassPlay;
                    default :
                        return PlayType.RunPlay;
                }
            }

            // 4th DOWN
            else if (down == 4 && dist < 4){
                switch(rand.Next(6)){
                    case 0 :
                        return PlayType.RunPlay;
                    case 1 :
                        return PlayType.PassPlay;
                    case 2 :
                        return PlayType.RunPlay;
                    case 3 :
                        return PlayType.Punt;
                    case 4 :
                        return PlayType.Punt;
                    case 5 :
                        return PlayType.Punt;
                    default :
                        return PlayType.Punt;
                }
            }
            else {
                switch(rand.Next(4)){
                    case 0 :
                        return PlayType.PassPlay;
                    case 1 :
                        return PlayType.Punt;
                    case 2 :
                        return PlayType.Punt;
                    case 3 :
                        return PlayType.Punt;
                    default :
                        return PlayType.Punt;
                }
            }
        }

        public static PlayType ExtraPoint(){
            Random rand = new Random();

            switch(rand.Next(3)){
                case 0 :
                    return PlayType.OnePoint;
                case 1 :
                    return PlayType.OnePoint;
                case 2 :
                    return PlayType.TwoPoint;
                default : 
                    return PlayType.OnePoint;
            }
        }

        public static PlayType ExtraPointPlay(){
            Random rand = new Random();

            switch(rand.Next(3)){
                case 0 :
                    return PlayType.RunPlay;
                case 1 :
                    return PlayType.RunPlay;
                case 2 :
                    return PlayType.PassPlay;
                default :
                    return PlayType.RunPlay;
            }
        }
    }
}