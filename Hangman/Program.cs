using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] words = new String[] {
                "apple",
                "dictionary",
                "television",
                "cushion",
                "smartphone",
                "puzzle"
            };

            Console.WriteLine("Let's play a Hangman Game!\n");

            String chosenWord = "apple";

            int n = 0;

            while(n < chosenWord.Length) {
                Console.Write(" _");
                n++;
            }

            Console.WriteLine("Type the alphabet or the word for a guess: ");
            String guess = Console.ReadLine();

            if (guess.Length > 1) {

            }

            if (chosenWord.Contains(guess)) {
                int index = chosenWord.IndexOf(guess);
            }


            Console.WriteLine("\n");
        }

        static void GameSetting()
        {
            


        }
    }
}
