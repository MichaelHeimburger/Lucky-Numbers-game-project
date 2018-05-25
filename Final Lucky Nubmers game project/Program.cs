using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string playCondition = "";
            do
            {
                int jackpot = 69696969;
                int userInput;
                //User input of random number min max

                Console.WriteLine("Welcome to Lucky numbers, the current jackpot is $" + jackpot + ".");
                Console.WriteLine("Please input the lowest value in the range of numbers I will generate.");
                int rndNumLow = int.Parse(Console.ReadLine());
                Console.WriteLine("Alright now please input the max value I will generate.");
                int rndNumHigh = int.Parse(Console.ReadLine());
                
                //User input of guessed numbers
                int[] guessNums = new int[6];
                for (int b = 0; b < guessNums.Length; b++)
                {
                    Console.WriteLine("Alright whats your best guess for number " + (b + 1));
                    userInput= int.Parse(Console.ReadLine());
                    while ((userInput > rndNumHigh) || (userInput < rndNumLow) || (guessNums.Contains(userInput)))
                    {
                            Console.WriteLine("Woah buddy thats not an acceptable number, please choose a differnt number");
                            userInput = int.Parse(Console.ReadLine());
                    } //// while loop checking min max range and comparing to array
                    guessNums[b] = userInput;
                } //// loop of input


                //Generation of random numbers
                int[] rndNums = new int[6];
                Random r = new Random();
                int winCount = 0;
                int rndNumsBuffer;
                Console.WriteLine("Here are the winning numbers!");
                for (int a = 0; a < rndNums.Length; a++) //for loop that assigns random integers to the array
                {
                        rndNumsBuffer = r.Next(rndNumLow, (rndNumHigh + 1)); //buffer to compare to array
                    while (rndNums.Contains(rndNumsBuffer)) //while loop that  compares arry to buffer
                    {
                        rndNumsBuffer = r.Next(rndNumLow, (rndNumHigh + 1));
                    }
                    rndNums[a] = rndNumsBuffer;
                    Console.WriteLine("Lucky Number: " + rndNums[a]);

                    if (guessNums.Contains(rndNums[a])) //// comparing numbers to check win if statement
                    {
                        winCount++;

                    } 

                } 

                // Win check
                if (winCount > 0)
                {
                    Console.WriteLine("WOW CONGRATULATIONS " + "YOU GUESSED " + winCount + " NUMBERS CORRECTLY, YOU HAVE WON " + "$" + (jackpot / (7 - winCount)));
                }
                else
                {
                    Console.WriteLine("No correct matches. Try again!");
                }

                // play again loop
                Console.WriteLine("Thanks for playing!");
                Console.WriteLine("Would you like to play again? Type \"yes\" or \"no\".");
                playCondition = Console.ReadLine();
            }
            while (playCondition == "yes");
            return;






        }
    }
}
