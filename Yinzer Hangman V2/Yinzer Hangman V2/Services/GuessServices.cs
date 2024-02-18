using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinzer_Hangman_V2.Models;
namespace Yinzer_Hangman_V2.Services
{
   
    public class GuessServices
    {
        public string GetUserGuess(string answer, string hidden, User user)
        {
            Console.WriteLine();
            Console.WriteLine("Take a shot at guessin' a letter, 'er if yinz know it, spell out the whole word, 'er whatever");
            return user.Guess = Console.ReadLine();
        }
        public bool IsSingleLetterGuess(string guess)
        {
            return guess.Length == 1;
        }
        public bool IsFullWordGuess(string guess, string answer)
        {
            return guess.Length > 1 || guess.Length == answer.Length;
        }
        public string HandleFullWordGuess(string hidden, User user)
        {
            string filteredGuess = FilterGuess(user);
            string filteredAnswer = FilterAnswer(user);

            if (filteredGuess == filteredAnswer)
            {
                Console.WriteLine();
                Console.WriteLine($"Da answer is {user.Answer}");
                Console.WriteLine();
                Console.WriteLine("You's won the game!");
                Console.WriteLine();
                
            }
            else
            {
                Console.WriteLine("I'm sorry, that was an incorrect guess!");
                Console.WriteLine($"{hidden}");
                user.IncrementIncorrect();
                DrawHangman(user);
            }
            return filteredGuess == filteredAnswer? user.Answer: hidden;
        }
        public string FilterGuess(User user)
        {
            return new string(user.Guess.ToLower().Where(c => Char.IsLetter(c) || c == ' ' || c == '\\' || c == '-' || c == ',' || c == '?' || c == '.' || c == '!').ToArray());
        }
        public string FilterAnswer(User user)
        {
            return new string(user.Answer.ToLower().Where(c => Char.IsLetter(c) || c == ' ' || c == '\\' || c == '-' || c == ',' || c == '?' || c == '.' || c == '!').ToArray());
        }
        public string HandleSingleLetterGuess(string answer, string hidden, bool hasLetter, User user)
        {
            //guess = GetUserGuess(answer, hidden);

            //if they guess incorrectly respond and increment the incorrect variable
            if (!answer.ToLower().Contains(char.ToLower(user.Guess[0])))
            {
                Console.WriteLine();
                Console.WriteLine("The word ain't gat that letter!");
                user.IncrementIncorrect(); // Increment the Incorrect property of the User object
                DrawHangman(user);
                Console.WriteLine();
                Console.WriteLine($"Yinz made {user.Incorrect} tries, 'n'at. Still got {5 - user.Incorrect} tries left, y'know.");
                Console.WriteLine();
                Console.WriteLine($"{hidden}");
                if (user.Incorrect == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Game over.");
                    Console.WriteLine();
                }
            }
            else
            {
                //number of times a letter appears in a word, in case more than once
                int numberOfTimes = 0;

                /* create a CharArray to hold letters asterisk and reveal them 
                    as we loop through the length of answer checking if the guesses are in each index
                    position of answer*/

                char[] reveal = hidden.ToCharArray();

                for (int i = 0; i < answer.Length; i++)
                {
                    // this checks if your guess is in the word
                    // then reveals that letter as many times as it appears in the word
                    if ((char.ToLower(user.Guess[0]) == char.ToLower(answer[i])))
                    {
                        hasLetter = true;
                        numberOfTimes++;

                        if (!hidden.Contains(char.ToLower(user.Guess[0])))
                        {
                            reveal[i] = answer[i];
                        }
                    }
                }
                Console.WriteLine();
                // if you guess correctly and haven't guessed all of the letters
                /* I added the number of times so that if the letter appears multiple
                    in the word, it will only Console.WriteLine one time */
                if (hasLetter)
                {
                    Console.WriteLine("Spot on, n'at!");
                    Console.WriteLine();
                    hidden = new string(reveal);
                    Console.WriteLine($"{hidden}!");
                }
                if (!hidden.Contains("*"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Yinz win!");
                    Console.WriteLine();
                    Console.WriteLine($"Yer word is {answer}");

                }
            }
            return hidden;
        }
        public User DrawHangman(User user)
        {
            Console.WriteLine();

            switch (user.Incorrect)
            {   //Case number = incorrect guess amount
                case 1:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |    | ");
                    break;
                case 2:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |   /|  ");
                    break;
                case 3:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |   /|\\ ");
                    break;
                case 4:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |   /|\\");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |   / ");
                    Console.WriteLine(" |");
                    break;
                case 5:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |   /|\\");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |   / \\");
                    Console.WriteLine(" |");

                    break;
                default:
                    Console.WriteLine("Invalid step number.");
                    break;
            }
            return user;
        }

    }
}

