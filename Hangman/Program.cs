using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[] {
                "apple",
                "dictionary",
                "television",
                "cushion",
                "smartphone",
                "puzzle"
            };

            Console.WriteLine("Let's play a Hangman Game!\n");

            string chosenWord = "apple";

            bool play = true;

            while (play) {
                play = HangmanGame(chosenWord);
            }

            Console.WriteLine("\n\nThank you for playing! Bye Bye");
        }

        static bool HangmanGame(string chosenWord)
        {
            string[] wordDisplay = new string[chosenWord.Length];

            for (int i = 0; i < chosenWord.Length; i++) {
                wordDisplay[i] = "_";
            }

            bool guessed = false;
            int attempt = 0;

            while(!guessed && attempt < 8) {
                for (int i = 0; i < chosenWord.Length; i++) {
                    Console.Write(" " + wordDisplay[i]);
                }

                Console.Write("\n\nType an alphabet or the word for a guess: ");
                string guess = getInput();

                if (guess.Length > 1 && chosenWord == guess) {
                    guessed = true;
                } else if (guess.Length == 1 && chosenWord.Contains(guess)) {
                    for (int i = 0; i < chosenWord.Length; i++) {
                        if (chosenWord[i] == Convert.ToChar(guess)) {
                            wordDisplay[i] = " " + guess;
                        }
                    }
                } else {
                    Console.WriteLine(DrawHangman(attempt));
                    attempt++;
                    // draw hangman
                }
            }

            if(guessed) {
                Console.WriteLine("Correct!");
            } else {
                Console.WriteLine("Game Over! The man is hanged!");
                Console.WriteLine("The answer was " + chosenWord);
            }

            Console.Write("\nDo you want to play the game again? (Y/N): ");
            string restart = "";
            while (true) {
                restart = Console.ReadLine().ToLower();
                if (restart == "y") {
                    return true;
                } else if (restart == "n") {
                    return false;
                } else {
                    Console.Write("Invalid input, please type Y or N: ");
                }
            }

        }

        static string getInput()
        {
            string input = "";

            do {
                input = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(input)) {
                    Console.Write("Empty input, please type something: ");
                }
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        static string DrawHangman(int attempt)
        {
            string[] hangman = new string[]
            {
                " ___________\n" +
                "           |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n",

                " ___________\n" +
                "           |\n" +
                " O         |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n",

                " ___________\n" +
                "           |\n" +
                " O         |\n" +
                " |         |\n" +
                " |         |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n",

                " ___________\n" +
                "           |\n" +
                " O         |\n" +
                "/|         |\n" +
                " |         |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n",

                " ___________\n" +
                "           |\n" +
                " O         |\n" +
                "/|\\        |\n" +
                " |         |\n" +
                "           |\n" +
                "           |\n" +
                "           |\n",

                " ___________\n" +
                "           |\n" +
                " O         |\n" +
                "/|\\        |\n" +
                " |         |\n" +
                "/          |\n" +
                "           |\n" +
                "           |\n",

                " ___________\n" +
                "           |\n" +
                " O         |\n" +
                "/|\\        |\n" +
                " |         |\n" +
                "/ \\        |\n" +
                "           |\n" +
                "           |\n",

                " ___________\n" +
                " |         |\n" +
                " O         |\n" +
                "/|\\        |\n" +
                " |         |\n" +
                "/ \\        |\n" +
                "           |\n" +
                "           |\n"
            };

            return hangman[attempt];
        }
    }
}
