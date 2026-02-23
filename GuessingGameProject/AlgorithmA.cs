using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameProject
{
    public class AlgorithmA
    {
        public static int Guess(SecretNumber secretNumber, bool printTrace = false)
        {
            for (int i = secretNumber.Min; i < secretNumber.Max; i++)
            {
                if (printTrace)
                {
                    Console.WriteLine($"Guessing: {i}");
                }

                int result = secretNumber.Guess(i);
                if (result == 0)
                {
                    if (printTrace)
                    {
                        Console.WriteLine($"Found the secret number: {i} in {secretNumber.NumGuesses} guesses.");
                    }

                    return i; // Found the secret number
                }
            }

            throw new ApplicationException("Secret number not found within the specified range.");
        }
    }
}
