using System;
using System.Collections.Generic;
using System.Text;

namespace Games
{
    class Program
    {
        static void Main(string[] args)
        {
            string GameChoice;
            do
            {
                Console.WriteLine("Choose your game!!");
                Console.WriteLine("1. Hangman!!");
                Console.WriteLine("2. Rock, Paper, Scissors!!");
                Console.WriteLine("3. Exit Program.");

                GameChoice = Console.ReadLine();

                if (GameChoice == "1")
                {
                    Hangman();
                }else if (GameChoice == "2")
                {
                    RockPaperScissors();
                }else if (GameChoice == "3")
                {
                    System.Environment.Exit(1);
                }
            } while (GameChoice != "3");
        }

        static void Hangman()
        {
            Console.WriteLine("Let's play Hangman!!");

            var Words = new List<string>
                {"bomb",
                "reign",
                "welcome",
                "calculate",
                "country",
                "tendency",
                "kettle",
                "liquid",
                "living",
                "dazzling",
                "signal",
                "form",
                "hand",
                "division",
                "worried",
                "left",
                "warlike",
                "absorbed",
                "cultured",
                "wistful",
                "linen",
                "wipe",
                "detect",
                "listen",
                "blue",
                "efficacious",
                "farflung",
                "playground",
                "stuff",
                "alert",
                "bent",
                "measure",
                "coach",
                "greedy",
                "mighty",
                "expansion",
                "night",
                "staking",
                "cent",
                "press",
                "labored",
                "shake",
                "fool",
                "cow",
                "gamy",
                "bells",
                "line",
                "adorable",
                "admit",
                "song",
                "serve",
                "lace",
                "stream",
                "acrid",
                "birds",
                "trace",
                "explain",
                "replace",
                "trucks",
                "far",
                "certain",
                "temporary",
                "army",
                "clumsy",
                "simple",
                "expand",
                "furtive",
                "functional",
                "ripe",
                "middle",
                "trouble",
                "dead",
                "murky",
                "mailbox",
                "close",
                "watery",
                "unfasten",
                "disagreeable",
                "kind",
                "marvelous",
                "curl",
                "tow",
                "flashy",
                "home",
                "giant",
                "adventurous",
                "clover",
                "time",
                "feeble",
                "end",
                "volleyball",
                "responsible",
                "trade",
                "station",
                "ship",
                "ugliest",
                "shop",
                "thumb",
                "runner",
                "small"};

            Console.WriteLine("RULES");
            Console.WriteLine("You have 7 Guesses.");
            Console.WriteLine("Please enter in a single letter when prompted for a guess.");
            Console.WriteLine("If your guess is in the word, the letter will show up where it is in the word.");
            Console.WriteLine("If your guess is not in the word, you lose one guess.");
            Console.WriteLine("After each guess, you can attempt to solve the word by entering your choice when prompted.");
            Console.WriteLine("If your word guess is correct, you win!!");
            Console.WriteLine("If your word guess is incorrect, you lose 2 guesses.");
            Console.WriteLine("If you run out of guesses, you lose!!");

            int Guesses = 7;
            Random r = new Random();
            string RandWord = Words[r.Next(0, Words.Count)];
            int WordLength = RandWord.Length;
            char[]Word = new char[WordLength];
            char[]GuessWord = new char[WordLength];
            bool WinFlag = false;

            Console.WriteLine("Your word has the following number of blank spaces: ");
            for (int i = 0; i <RandWord.Length; i++)
            {
                Word[i] = RandWord[i];
                GuessWord[i] = '*';
            }

            do
            {
                Console.WriteLine(GuessWord);

                CharacterGuess();

                WordGuess();
            } while (Guesses >= 0 & WinFlag != true);

            void CharacterGuess()
            {
                char CharGuess;
                bool Flag = false;
                Console.WriteLine("Guess a letter: ");
                CharGuess = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                for (int i = 0; i < Word.Length; i++)
                {
                    if (CharGuess == Word[i])
                    {
                        GuessWord[i] = Word[i];
                        Flag = true;
                    }
                }
                if (Flag == false)
                {
                    Guesses = Guesses - 1;
                }

            }
            void WordGuess()
            {
                char Answer;
                string PlayerGuessWord;
                Console.WriteLine("Would you like to guess the word?");
                Console.WriteLine("(Enter Y or y for yes, N or n for no.");
                Answer = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                if (Answer == 'Y' | Answer == 'y')
                {
                    Console.WriteLine("Enter your word guess: ");
                    PlayerGuessWord = Console.ReadLine();

                    Console.WriteLine("\n");

                    if (PlayerGuessWord == RandWord)
                    {
                        Console.WriteLine("You correctly guess the word!");
                        Console.WriteLine(RandWord);
                        Console.WriteLine("That means you win!!");
                        WinFlag = true;

                        
                    }else if(PlayerGuessWord != RandWord)
                    {
                        Console.WriteLine("Incorrect Guess!!");
                        Guesses = Guesses -2;
                    }
                }

            }

        }
        static void RockPaperScissors()
        {

        }
    }
}
