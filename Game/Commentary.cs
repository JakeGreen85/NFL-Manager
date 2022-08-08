using System;

namespace ManagerGame {
    public static class Commentary {

        /// <summary>
        /// Comments on the previous play, based on the playtype and how many yards were gained
        /// </summary>
        public static void ExPlay(PlayType pt, int gain, Team at){
            switch(pt){
                case PlayType.RunPlay :
                    Console.WriteLine(at.Name + " run the ball.");
                    switch (gain){
                        case (<0) :
                            Console.WriteLine("But the runningback is caught in the backfield for a loss of " + Math.Abs(gain) + " yards.");
                            break;
                        case (>0) :
                            Console.WriteLine("Good blocking by the offensive line. The runningback finds a hole for a gain of " + Math.Abs(gain) + " yards.");
                            break;
                        default :
                            Console.WriteLine("They barely make it back to the line of scrimmage. No gain on the play.");
                            break;
                    }
                    break;
                case PlayType.PassPlay :
                    Console.WriteLine(at.oPlayers[0].lName + " drops back to pass.");
                    switch (gain){
                        case (<0) :
                            Console.WriteLine("The defensive line gets through for a sack. Loss of " + Math.Abs(gain) + " yards.");
                            break;
                        case (>0) :
                            Console.WriteLine("He gets the throw off and finds a receiver for a gain of " + Math.Abs(gain) + " yards.");
                            break;
                        default :
                            Console.WriteLine("He throws the ball, but could not connect with the receiver. Incomplete.");
                            break;
                    }
                    break;
                case PlayType.Punt :
                    Console.WriteLine(at.Name + " punt the ball");
                    break;
                default :
                    Console.WriteLine("The " + at.Name + " offense comes out to start their drive.");
                    break;
            }
        }
    }
}