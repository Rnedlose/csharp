using System;
using System.Collections.Generic;
using System.Text;

namespace Games
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Variable for which game to play.
                string GameChoice;
                
                // Do While Loop to keep game running until option 3 is chosen.
                do
                {

                    // Our Game Menu.
                    Console.WriteLine("Choose your game!!");
                    Console.WriteLine("1. Hangman!!");
                    Console.WriteLine("2. Rock, Paper, Scissors!!");
                    Console.WriteLine("3. Exit Program.");

                    // Get Input from Player.
                    GameChoice = Console.ReadLine();

                    // Using If Else Decision Structure.
                    if (GameChoice == "1")
                    {
                        // Hangman game function call.
                        Hangman();
                    }else if (GameChoice == "2")
                    {
                        // RockPaperScissors game function call.
                        RockPaperScissors();
                    }else if (GameChoice == "3")
                    {
                        // Exit the application.
                        System.Environment.Exit(1);
                    }
                } while (GameChoice != "3");
            }catch(Exception E)
            {
                Console.WriteLine("Exception caught {0}", E);
            }
        }

                // Hangman game function.
                static void Hangman()
                {
                    Console.WriteLine("Let's play Hangman!!");

                    // Word Bank for Hangman game.
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

                    // Game Rules.
                    Console.WriteLine("RULES");
                    Console.WriteLine("You have 7 Guesses.");
                    Console.WriteLine("Please enter in a single letter when prompted for a guess.");
                    Console.WriteLine("If your guess is in the word, the letter will show up where it is in the word.");
                    Console.WriteLine("If your guess is not in the word, you lose one guess.");
                    Console.WriteLine("After each guess, you can attempt to solve the word by entering your choice when prompted.");
                    Console.WriteLine("If your word guess is correct, you win!!");
                    Console.WriteLine("If your word guess is incorrect, you lose 2 guesses.");
                    Console.WriteLine("If you run out of guesses, you lose!!");

                    // Game variables needed.
                    int Guesses = 7;
                    Random r = new Random();
                    string RandWord = Words[r.Next(0, Words.Count)];
                    int WordLength = RandWord.Length;
                    char[]Word = new char[WordLength];
                    char[]GuessWord = new char[WordLength];
                    bool WinFlag = false;

                    // Game logic.  The game checks if the players guess letter
                    // is in the hidden word.  Correct guesses show up each loop.
                    // Player given option to guess the word after each letter guess.
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

                    // CharacterGuess function.
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

                    // WordGuess function.
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

                // RockPaperScissors game function.
                static void RockPaperScissors()
            {
                Console.WriteLine("Lets play Rock, Paper, Scissors!!");

                // Game Rules.
                Console.WriteLine("RULES");
                Console.WriteLine("You choose Rock, Paper, or Scissors.");
                Console.WriteLine("The Program will choose as well at random.");
                Console.WriteLine("Rock beats Scissors, Scissors beats Paper, and Paper beats Rock.");
                Console.WriteLine("Best out of 5 rounds wins!!");

                // Game variables needed.
                int Rounds = 5;
                int PlayerWins = 0;
                int PlayerLosses = 0;
                int PlayerChoice;
                string ProgramChoice;
                string[] ProgramChoices = {"Rock", "Paper", "Scissors"};

                // Game Logic.  Each loop Player makes choice and Program is assigned
                // a random option.  Options are compared, and round winner declared.
                // Each loop increments the rounds.  After 5 rounds, game is over and
                // overall winner declared.
                do
                {
                    Console.WriteLine("Begin!!");
                    Console.WriteLine("Enter your choice from the options: ");
                    Console.WriteLine("1. Rock");
                    Console.WriteLine("2. Paper");
                    Console.WriteLine("3. Scissors");

                    PlayerChoice = int.Parse(Console.ReadLine());

                    Random rand = new Random();

                    ProgramChoice = ProgramChoices[rand.Next(0, ProgramChoices.Length)];
                    
                    if(PlayerChoice == 1)
                    {
                        if(ProgramChoice == "Rock")
                        {
                            Console.WriteLine("Program chose Rock as well so it is a Draw.");
                        }else if(ProgramChoice == "Paper")
                        {
                            Console.WriteLine("Program chose Paper, so you lose this round!!");
                            PlayerLosses = PlayerLosses + 1;
                        }else if(ProgramChoice == "Scissors")
                        {
                            Console.WriteLine("Program chose Scissors, so you win this round!!");
                            PlayerWins = PlayerWins + 1;
                        }
                    }else if(PlayerChoice == 2)
                    {
                        if(ProgramChoice == "Rock")
                        {
                            Console.WriteLine("Program chose Rock, so you win this round!!");
                            PlayerWins = PlayerWins + 1;
                        }else if(ProgramChoice == "Paper")
                        {
                            Console.WriteLine("Program chose Paper as well so it is a Draw.");
                        }else if(ProgramChoice == "Scissors")
                        {
                            Console.WriteLine("Program chose Scissors, so you lose this round!!");
                            PlayerLosses = PlayerLosses + 1;
                        }
                    }else if(PlayerChoice == 3)
                    {
                        if(ProgramChoice == "Rock")
                        {
                            Console.WriteLine("Program chose Rock, so you lose this round!!");
                            PlayerLosses = PlayerLosses + 1;
                        }else if(ProgramChoice == "Paper")
                        {
                            Console.WriteLine("Program chose Paper, so you win this round!!");
                            PlayerWins = PlayerWins + 1;
                        }else if(ProgramChoice == "Scissors")
                        {
                            Console.WriteLine("Program chose Scissors as well so it is a Draw.");
                        }
                    }else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                    Rounds = Rounds - 1;

                }while (Rounds != 0);

                Console.WriteLine("Game over.  Let's see who won?");
                Console.WriteLine("Player Wins: " , PlayerWins);
                Console.WriteLine("Player Losses: " , PlayerLosses);
                if(PlayerWins > PlayerLosses)
                {
                    Console.WriteLine("You won!!");
                }else if(PlayerWins < PlayerLosses)
                {
                    Console.WriteLine("You lost!!");
                }else
                {
                    Console.WriteLine("This game ended in a draw!!");
                }
            }

    }
}
