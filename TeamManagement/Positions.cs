using System;

namespace ManagerGame
{
    public enum Position {
        QB,
        RB,
        WR,
        OL,
        TE,
        DT,
        DE,
        CB,
        LB,
        S
    }

    public class PositionTransformer {
        public static Position stringToPos(string pos){
            switch (pos){
                case "QB" :
                    return Position.QB;
                case "RB" :
                    return Position.RB;
                case "WR" :
                    return Position.WR;
                case "OL" :
                    return Position.OL;
                case "TE" :
                    return Position.TE;
                case "DE" :
                    return Position.DE;
                case "DT" :
                    return Position.DT;
                case "LB" :
                    return Position.LB;
                case "S" :
                    return Position.S;
                case "CB" :
                    return Position.CB;
                default :
                    return Position.QB;
            }
        }
    } 
}