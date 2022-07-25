using System;

namespace ManagerGame
{
    public enum PlayType {
        RunPlay,
        PassPlay,
        Punt,
        OnePoint,
        TwoPoint
    }

    public class PlayTransformer {
        /// <summary>
        /// Converts user input key to PlayType
        /// </summary>
        /// <returns>
        /// The user input as type PlayType
        /// </returns>
        public static PlayType KeyToPlayType(ConsoleKey input){
            switch (input){
                case ConsoleKey.R :
                    return PlayType.RunPlay;
                case ConsoleKey.P :
                    return PlayType.PassPlay;
                case ConsoleKey.K :
                    return PlayType.Punt;
                case ConsoleKey.Y :
                    return PlayType.TwoPoint;
                case ConsoleKey.N :
                    return PlayType.OnePoint;
                default : 
                    return PlayType.RunPlay;
            }
        }
    }
}