using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameProject
{
    public class SecretNumber
    {
        private readonly int _min;

        public int Min { get { return _min; } }

        
        private readonly int _max;
        public int Max { get { return _max; } }


        private readonly int _secret;

        
        private int _numGuesses = 0; // Number of guesses made by the player

        public int NumGuesses
        {
            get { return _numGuesses; } // Public property to access the number of guesses
        }

        /// <summary>
        /// Algorithms must not Cheat and read the secret number directly. This property is only for testing purposes to verify that the secret number is generated correctly and is not being accessed by the guessing algorithm.
        /// TODO: Once the secret number is checked, disallow further guessing!
        /// </summary>
        internal int CheckSecretNumber
        {
            get { return _secret; } // Public property to access the secret number (for testing purposes)
        }

        /// <summary>
        /// Create a new secret number with a random value between min (inclusive) and max (exclusive). 
        /// </summary>
        /// <param name="min">The minimum secret number (inclusive)</param>
        /// <param name="max">The maximum secret number (exclusive)</param>
        public SecretNumber(int min = 0, int max = 100)
        {
            if (min > max)
            {
                throw new ArgumentException("min must be less than (or equal to) max", nameof(min));
            }

            _min = min;
            _max = max;

            // Generate a random secret number between min (inclusive) and max (exclusive)
            // Secret number chosen uniformly at random from the range [min, max)
            // Each number has equal probability of being chosen
            _secret = Random.Shared.Next(min, max);
        }

        public int Guess(int guess)
        {
            _numGuesses++; // Increment the number of guesses

            if (guess < _secret)
            {
                return -1; // Guess is too low
            }
            else if (guess > _secret)
            {
                return 1; // Guess is too high
            }
            else
            {
                return 0; // Guess is correct
            }
        }
    }
}
