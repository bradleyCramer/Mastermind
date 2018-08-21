using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class MastermindGame
    {
        private int[] secret;
        private int[] guess;
        private int guessCount;

        public MastermindGame()
        {
            secret = new int[4];
            guess = new int[4];
            guessCount = 1;
        }

        public void initGame()
        {
            Console.WriteLine("Welcome to Mastermind!");

            Console.WriteLine("Guesses should be 4 digits each between 1 and 6.");

            Console.WriteLine("For each guess you will be presented with: " + Environment.NewLine + "+ for each correct digit in the correct place" + Environment.NewLine + "- for every correct digit in the wrong place");

            Console.WriteLine("Press enter to start.");

            createSecret();

            while(guessCount <= 10)
            {
                Console.WriteLine(string.Format("Enter guess {0}.", guessCount));

                initGuess(Console.ReadLine());

                string response = evaluateGuess(guess, secret);

                if(response == "++++")
                {
                    Console.WriteLine("Winner! The secret was " + printSecret());
                    return;
                }
                Console.WriteLine(response);
                Console.WriteLine(string.Format("Guess again! You have {0} guesses remaining", 10 - guessCount));
                guessCount++;
            }

            Console.WriteLine("Sorry. You lose!");
            Console.WriteLine("The Secret Was " + printSecret());
        }

        private string printSecret()
        {
            string response = "";
            
            foreach(int i in secret)
            {
                response += Convert.ToString(i);
            }

            return response;
        }

        private void initGuess(string input)
        {
            int i = 0;

            foreach (char x in input)
            {
  
                guess[i] = Convert.ToInt32(Char.GetNumericValue(x));
                i++;
            }
        }

        public string evaluateGuess(int[] guess, int[] secret)
        {
            string wellPlaced = "";
            string misplaced = "";
            string holder = "";

            for(int i = 0; i < secret.Length; i++)
            {
                if(secret[i] == guess[i])
                {
                    wellPlaced = wellPlaced + "+";
                    holder = holder + secret[i].ToString();
                }
            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (secret.Contains(guess[i]) && !holder.Contains(guess[i].ToString()))
                {
                    misplaced = misplaced + "-";
                    holder = holder + guess[i];
                }
            }

            return wellPlaced + misplaced;
        }

        private void createSecret()
        {
            Random r = new Random();
            for(int i = 0; i < 4; i++)
            {
                secret[i] = r.Next(1, 7);
            }

        }
    }
}
