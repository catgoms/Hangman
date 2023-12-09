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

            HangmanGame(chosenWord);


            Console.WriteLine("\n");
        }

        static void HangmanGame(String chosenWord)
        {
            String[] wordDisplay = new string[] { };

            for(int i = 0; i < chosenWord.Length; i++) {
                wordDisplay[i] = " _";
                Console.Write(wordDisplay[i]);
            }

            bool guessed = false;

            while(!guessed) {
                Console.WriteLine("\nType the alphabet or the word for a guess: ");
                String guess = Console.ReadLine();

                if (guess.Length > 1 && chosenWord == guess) {
                    Console.WriteLine("Correct!");
                    Console.WriteLine("Do you want to play the game again? (Y/N): ");
                    String restart = Console.ReadLine();
                    guessed = true;
                } else if (guess.Length == 1 && chosenWord.Contains(guess)) {
                    int index = chosenWord.IndexOf(guess);
                    wordDisplay[index] = " " + guess;
                } else {
                    // draw hangman
                }
            }

            


        }
    }
}
