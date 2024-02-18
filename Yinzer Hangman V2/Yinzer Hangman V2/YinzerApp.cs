using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinzer_Hangman_V2.Models;
using Yinzer_Hangman_V2.Services;

namespace Yinzer_Hangman_V2
{
    public class YinzerApp
    {
        
        WordServices wordServices = new WordServices();
        User user = new User();
        GuessServices guessServices = new GuessServices();
        GameServices gs = new GameServices();

        public void Run()
        {
            Console.WriteLine("Hey yinz, gather 'round! We got ourselves a real n'at hangman game goin' on.");
            Console.WriteLine("It's a proper Pittsburgh puzzler, so grab yer pop, kick back, and let's see if yinz can guess the words.");
            Console.WriteLine("Ready to tackle this Pittsburgh hangman, ya jagoffs?");
            Console.WriteLine();
            Console.WriteLine("Yinz only got five chances to crack the code.Grab yer Terrible Towel, sit back, and let's see if yinz can unravel the mystery.");
            Console.WriteLine();

            Dictionary<string, string> yinzWords = wordServices.IntializeWords();

            do
            {
                user.Answer = wordServices.GetRandomWord(yinzWords);
                //I asked the internet how to do this, a ternary that checks if its a letter and the asterisk to replace the letters or leaves the space/character
                string hidden = wordServices.HideWord(user.Answer);

                wordServices.DisplayWordHint(user.Answer, yinzWords[user.Answer], hidden);
                // makes sure that you haven't guessed the word or run out of guesses
                while (hidden.Contains('*') && user.Incorrect < 5)
                {
                    user.Guess = guessServices.GetUserGuess(user.Answer, hidden, user);

                    if (guessServices.IsFullWordGuess(user.Guess, user.Answer))
                    {
                            hidden = guessServices.HandleFullWordGuess(hidden, user); 
                    }
                    else if (guessServices.IsSingleLetterGuess(user.Guess))
                    {
                        hidden = guessServices.HandleSingleLetterGuess(user.Answer, hidden, user.HasLetter, user);
          
                    }

                }
                gs.DisplayGameOutcome(hidden, user.Incorrect, user);
                user.PlayAgain = gs.AskToPlayAgain();

                // this loop condition is needed to start the game over again after selecting yes to play again
                if (user.PlayAgain.ToLower() == "y" || user.PlayAgain.ToLower() == "yes")
                {
                    gs.ResetGameVariables(user);
                }
                else if (user.PlayAgain.ToLower() == "n" || user.PlayAgain.ToLower() == "no")
                {
                    Console.WriteLine("Thanks for playing, see yinz next time!");
                    break;
                }
                else
                {
                    gs.HandleInvalidPlayAgainInput();
                }

            } while (user.PlayAgain.ToLower() == "y" || user.PlayAgain.ToLower() == "yes");


        }

    }
}
    

