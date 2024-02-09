using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinzer_Hangman_V2.Models
{
    public class User
    {
        public int Incorrect { get; set; }
        public int Correct { get; set; }
        public bool HasLetter { get; set; }
        public string Answer { get; set; }
        public string PlayAgain { get; set; }

        public User(int incorrect = 0, int correct = 0, bool hasLetter = false, string answer = "", string playAgain = "")
        {
            Incorrect = incorrect;
            Correct = correct;
            HasLetter = hasLetter;
            Answer = answer;
            PlayAgain = playAgain;
        }

    }
}
