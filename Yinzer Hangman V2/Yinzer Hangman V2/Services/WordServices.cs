using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinzer_Hangman_V2.Services
{
    public class WordServices
    {
        // Originally had an array, I decided on the dictionary so that the key could hold the hints for the word
        public Dictionary<string, string> IntializeWords()
        {

            Dictionary<string, string> yinzWords = new Dictionary<string, string>
            {
            {"Yinz", "Pittsburghese pronoun"},
            {"Clahdy", "Weather-related term"},
            {"Jagoff", "Pittsburgh insult"},
            {"Dahntahn", "Downtown"},
            {"Grahnd bees", "Yellow jacket bees in the ground"},
            {"Rahn-da-baht", "Song by the group yes or slang for a long way of getting to your destination"},
            {"Slippy", "Icy"},
            {"Gumband", "Rubber band"},
            {"Seent", "Seen it"},
            {"Cousint", "Cousin"},
            {"Friggin", "Vulgar slang"},
            {"Crick", "Small stream or creek"},
            {"Irn", "Short for Iron City Beer"},
            {"Worsh", "Wash"},
            {"Sweeper", "Vacuum cleaner"},
            {"Spickett", "Outdoor water faucet"},
            {"Prolly", "Probably"},
            {"Zak same", "Exactly the same"},
            {"Lahsy", "Lousy"},
            {"Jagger bush", "Thorny bush or plant"},
            {"Up air", "Up there"},
            {"Da-Boat-a-ya", "The both of you"},
            {"Nebby", "Nosy"},
            {"N'at", "And that"},
            {"Gutchies", "Underwear"},
            {"Buggy", "Shopping cart"},
            {"Jumbo", "Bologna"},
            {"Chipped-Chopped ham", "Isaly's was famous for this!"},
            {"Red Up", "Clean up"},
            {"Jeet Jet?", "Did you eat yet?"},
            {"Dippy Eggs", "Sunny-side-up eggs"},
            {"Pop", "Soda"},
            {"Canipshun", "Conniption"},
            {"Sammitches", "Sandwiches"},
            {"Ahnno-dat", "I don't know that"},
            {"A whole nother", "A whole other"},
            { "Airyago", "There you go"},
            {"Apost tu", "Supposed too"},
            {"Back'air", "Back there"},
            {"Bo fuss", "Both of us"},
            {"Bowchyins", "Both of you"},
            {"Buy Sam a drink and get his dog one too!", "Mike Lang Slang"},
            {"Can a corn", "Easy catch in baseball"},
            {"Choobinuptoo", "What have you been up to?"},
            {"Cole-daht-dare", "It's cold outside"},
            {"Come mere", "Come here"},
            {"Dahn nair", "Down there"},
            {"Daht'et", "That it"},
            {"Don't go err wit me", "Don't argue with me"},
            {"Dooder Jobs", "Do their jobs"},
            {"Elvis has left the building", "The show is over"},
            {"Hafta", "Have to"},
            {"Hauscome", "How has it come"},
            {"Hay Bir Here", "Hey beer here"},
            {"How's come?", "Why is that?"},
            {"Ize", "I am"},
            {"Ja Wanna", "Do you want to"},
            {"Jano?", "Do you know?"},
            {"Jeez-o-man", "Expression of surprise"},
            {"Kennywood's Open", "The zipper on your pants is open"},
            {"Lassnite", "Last night"},
            {"Like iss", "Like this"},
            {"Like 'at", "Like that"},
            {"Nuh-uh!!", "No"},
            {"Oh call Arnold Slick from Turtle Crick!", "Expression of surprise"},
            {"Oh mah gersh!", "Oh my gosh!"},
            {"Ovaderr", "Over there"},
            {"Same difference", "No difference"},
            {"Scratch my back with a hacksaw!", "Mike Lang Slang"},
            {"Sick'n tard", "Sick and tired"},
            {"Sposda", "Supposed to"},
            {"bungals", "Slang for Cincinatti's football team"},
            {"brahns", "Brown shoes"},
            {"Ya Gatta Regatta!", "You have to attend the regatta"}
            };
            return yinzWords;
        }
        internal string GetRandomWord(Dictionary<string, string> wordDictionary)
        {
            //Selects random KVP from our Dictionary and take the key and turn it into string answer
            var random = new Random();
            var selectedWord = wordDictionary.ElementAt(random.Next(wordDictionary.Count));
            return selectedWord.Key;
        }
        internal string HideWord(string word)
        {
            return new string(word.Select(c => Char.IsLetter(c) ? '*' : c == ' ' || c == '\'' || c == '-' || c == ',' || c == '?' || c == '.' ? c : ' ').ToArray());
        }
        internal void DisplayWordHint(string word, string hidden, string hint)
        {
            Console.WriteLine($"Hint: {hint}: {hidden}");
            Console.WriteLine($"The word is {word.Length} letters");
        }
    }
}
