using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Game();
            Console.ReadLine();
        }
        static void Game()
        {
            // declare counters for the guesses the player has left and times they were right
            int guessesLeft = 5;
            int timesPlayerWasRight = 0;
            //random number generator
            Random rng = new Random();
            //declares empty strings for wrong and right guesses and a variable for the player guess
            //and boolean which will be used for while condition
            char playerGuess;
            string wrongGuesses = "";
            string rightGuesses = "";
            bool isPlaying = true;
            //The words the player will have to guess
            string[] wordBank = { "freedom", "totality", "fatality", "bravery" };
            //chooses a random word from the bank
           string wordToBeGuessed = wordBank[int.Parse(rng.Next(wordBank.Length).ToString())];
            //creates an array the size of whatever the word is
            char[] dashes = new char[wordToBeGuessed.Length];

            for (int i = 0; i < wordToBeGuessed.Length; i++)
            {
                //fills dashes with..dashes!
                dashes[i] = '_';
                //puts a space between the dashes
                Console.Write(dashes[i] + " ");

            }
            //so long as the boolean remains true or the guesses left are more than 0, it'll keep going
            while (isPlaying == true || guessesLeft == 0)
            {

                Console.Write("Welcome to hangman. You will guessing letters to a word until you all the letters have been guessed. Good luck!");
                    Console.Write("Guess a letter: ");
                //converts player response to lowercase
                playerGuess = Console.ReadLine().ToLower()[0];
                //this if loop  checks to see if you've guessed the letter before
                // if you have, it adds a guess so it doesn't penalize you
                    if (rightGuesses.ToString().Contains(playerGuess) || wrongGuesses.ToString().Contains(playerGuess)) 
                        {
                            Console.WriteLine("Sorry You already guessed " + playerGuess);
                            guessesLeft = guessesLeft + 1;
                        }
                //loop for if the players guess was in the word to guess
                    if (wordToBeGuessed.ToString().Contains(playerGuess))
                    {
                        //this will loop through the entire word to see if
                        for (int i = 0; i < wordToBeGuessed.Length; i++)
                        {//there's a spot where the player's guess is included
                            if (wordToBeGuessed[i] == playerGuess)
                            {
                                //if the player's guess is included, it replaces the indexed dash with the letter
                                dashes[i] = playerGuess;
                                //adds the letter to right guesses
                                rightGuesses = rightGuesses + playerGuess;
                                //increments the times player was right
                                timesPlayerWasRight = timesPlayerWasRight + 1;
                                //writes the new line with the amount of wrong guesses and guesses left
                                Console.WriteLine(dashes);
                                Console.WriteLine("Letters Guessed Wrong: " + wrongGuesses);
                                Console.WriteLine("Guesses Left: " + guessesLeft);
                            }
                        }
                        //if the player was right for the entire word , it lets you know you won.
                        if (timesPlayerWasRight == wordToBeGuessed.Length)
                        {

                            Console.WriteLine("You won!");
                                Console.ReadKey();
                            isPlaying = false;

                        }
                    }
                        //otherwise, it will take away from guesses
                        //and add whatever the guess was to wrong guesses
                    else
                    {
                        wrongGuesses = wrongGuesses + playerGuess;
                        guessesLeft = guessesLeft - 1;
                        Console.WriteLine(dashes);
                        Console.WriteLine("Letters Guessed Wrong: " + wrongGuesses);
                        Console.WriteLine("Guesses Left: " + guessesLeft);

                    }
                    
                
            } //after the player wins or loses, it displays the word that was to be guessed
            //in all its awesome glory
            Console.Write("The word was: " + wordToBeGuessed);

        }
      
    }

}

