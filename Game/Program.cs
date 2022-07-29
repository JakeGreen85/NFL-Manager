using System;

namespace ManagerGame
{
    class Program
    {
        /// <summary>
        /// Main function for the program
        /// </summary>
        static void Main(string[] args)
        {
            Console.Clear();
            
            // Creates an instance of the game
            Game game = new Game();  

            // Runs the game
            game.Run();     
              
        }
    }
}