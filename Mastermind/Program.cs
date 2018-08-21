using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        private static string[] code = new string[4];
        static void Main(string[] args)
        {
            MastermindGame game = new MastermindGame();
            string play = "y";
            
            while(play == "y")
            {
                game.initGame();

                Console.WriteLine("Play Again? y/n");
                play = Console.ReadLine();
            }

        }
    }
}
