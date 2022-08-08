using System;

namespace ManagerGame
{
    public static class GamePrints{
        public static void UpdateField(PlayType pt, int YardLine, int Distance){
            Console.Clear();
            PrintField(YardLine, Distance);
        }

        private static void PrintField(int YardLine, int Distance){
            string[] field = new string[100];
            for(int j = 0; j < 100; j++){
                if (j % 10 == 0){
                    
                    if (j <= 50){
                        Console.Write(j);
                    }
                    
                    else {
                        Console.Write(50 - (j % 50));
                    }
                }
                
                else if (j % 10 == 1){
                }
                
                else {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("0");

            for(int i = 0; i < field.Length; i++){
                if (i == YardLine){
                    field[i] = "*";
                }
                
                else if (i == YardLine + Distance){
                    field[i] = "|";
                }
                
                else{
                    field[i] = "_";
                }
            }

            // Prints the updated field
            foreach(string s in field){
                if (s == "*"){
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                
                else if (s == "|"){
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write(s);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}