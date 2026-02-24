using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameProject
{
    public class AlgorithmB
    {
        public static int Guess(SecretNumber secretNumber, bool printTrace = false)
        {
            int low = secretNumber.Min;
            int hi = secretNumber.Max - 1; // Max is exclusive, so we need to subtract 1 to get the inclusive upper bound

            while (low <= hi)
            {
                int middle = (low + hi) / 2; // Integer division will round down, which is what we want for the middle index
                int guessResult = secretNumber.Guess(middle);

                if (guessResult == 0)
                {
                    return middle; // Found the secret number
                }
                else if (guessResult < 0)
                {
                    // Guess is too low
                    low = middle + 1; // We can eliminate all numbers less than or equal to middle, so we set low to middle + 1
                }
                else // guessResult > 0
                {
                    // Guess is too high
                    hi = middle - 1; // We can eliminate all numbers greater than or equal to middle, so we set hi to middle - 1
                }
            }

            throw new ApplicationException("Secret number not found within the specified range.");
        }
    }
}
