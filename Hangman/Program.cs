using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            // word list for users to guess
            string[] wordList = new string[] {
                "APPLE",
                "DICTIONARY",
                "TELEVISION",
                "CUSHION",
                "SMARTPHONE",
                "PUZZLE"
            };

            Console.WriteLine("Let's play a Hangman Game!\n");

            // game starts and restarts until user wants to stop
            bool play = true;

            while (play) {
                // picks random word from the list
                Random random = new Random();
                int n = random.Next(wordList.Length);

                string chosenWord = wordList[n];

                // main hangman code
                play = HangmanGame(chosenWord);
            }

            // game finishes
            Console.WriteLine("\n\nThank you for playing! Bye Bye");
        }

        // The main game code
        static bool HangmanGame(string chosenWord)
        {
            // array to keep guessed and missing alphabets
            string[] wordDisplay = new string[chosenWord.Length];

            for (int i = 0; i < chosenWord.Length; i++) {
                wordDisplay[i] = "_";
            }

            // display on console, showing the length of the word
            Console.WriteLine();
            for (int i = 0; i < chosenWord.Length; i++) {
                Console.Write(" " + wordDisplay[i]);
            }

            // repeat the guessing until correct or fail
            bool correct = false;
            int attempt = 0;

            while(!correct && attempt < 8) {
                // variable to see how many alphabets guessed correctly
                int match = 0;

                // get user input
                Console.Write("\n\nType an alphabet or the word for a guess: ");
                string guess = getInput();

                // check the user input
                if (chosenWord == guess) {
                    // if guessed the whole word
                    correct = true;
                } else if (guess.Length == 1 && chosenWord.Contains(guess)) {
                    // if guessed an alphabet from the word

                    // check for multiple occurences of the alphabet in the word
                    for (int i = 0; i < chosenWord.Length; i++) {
                        if (chosenWord[i] == Convert.ToChar(guess)) {
                            wordDisplay[i] = guess;
                        }
                        // count how many of alphabets are guessed correctly
                        if (Convert.ToString(chosenWord[i]) == wordDisplay[i]) {
                            match++;
                        }
                    }

                    // check if all the alphabets are guessed correctly
                    if (match == chosenWord.Length) {
                        correct = true;
                    }
                } else {
                    // if guessed wrong, draw hangman and count attempt
                    Console.WriteLine(DrawHangman(attempt));
                    attempt++;
                }

                // display on console, showing the correctly guessed parts
                Console.WriteLine();
                for (int i = 0; i < chosenWord.Length; i++) {
                    Console.Write(" " + wordDisplay[i]);
                }
            }

            // if game won or game over
            if(correct) {
                Console.WriteLine("\n\nCorrect!");
            } else {
                Console.WriteLine("Game Over! The man is hanged!");
                Console.WriteLine("The answer was " + chosenWord);
            }

            // if want to play again
            Console.Write("\nDo you want to play the game again? (Y/N): ");
            string restart = "";

            // check that user input is either y or n and return boolean
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

        // Checks if user guess input is empty and returns user input
        static string getInput()
        {
            string input = "";

            // repeats asking for user input until not empty
            do {
                input = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(input)) {
                    Console.Write("Empty input, please type something: ");
                }
            } while (string.IsNullOrEmpty(input));
            
            return input;
        }

        // Returns the hangman drawing according to how many guesses made by user
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
