﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinzer_Hangman_V2.Services
{
    internal class GameServices
    {
        internal void DisplayGameOutcome(string hidden, int incorrect)
        {
            if (hidden.Contains('*') && incorrect == 5)
            {
                Console.WriteLine();
                Console.WriteLine("Game over, ya Jag.");
                Console.WriteLine();
            }

        }
        internal string AskToPlayAgain()
        {
            // This runs after you have guessed the word or have ran out of guesses

            Console.WriteLine("Yinz wanna play again?");
            Console.WriteLine();
            Console.WriteLine("Jus' type in Y or Yes if yinz wanna play again, 'n if yinz had enough, type N or No to exit, y'know");
            Console.WriteLine();
            return Console.ReadLine();
        }
        internal void HandleInvalidPlayAgainInput()
        {
            Console.WriteLine("I'm sorry 'n'at, but could yinz please enter a Y to play again or an N to exit, jagoff");
            Console.WriteLine();
            AskToPlayAgain();
        }
        internal void ResetGameVariables(int correct, int incorrect, bool hasLetter, string answer)
        {
            correct = 0;
            incorrect = 0;
            hasLetter = false;
            answer = "";
        }
    }
}
