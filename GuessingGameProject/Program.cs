// See https://aka.ms/new-console-template for more information

using GuessingGameProject;

/* NOTE:
// Note be careful of issues with computer numbers,
// especially integer division
Console.WriteLine(
        99 / 100
    );

Console.WriteLine(
        (decimal)99/100
    );
*/

/*
SecretNumber secretNumber = new SecretNumber(0, 100);
int guess = AlgorithmA.Guess(secretNumber, printTrace: true);

if (guess == secretNumber.CheckSecretNumber)
{
    Console.WriteLine($"Congratulations! You guessed the secret number {guess} in {secretNumber.NumGuesses} guesses.");
}
else
{
    Console.WriteLine($"Sorry, the secret number was {secretNumber.CheckSecretNumber}. Better luck next time!");
}
*/

int repetitions = 20;
int[] problemSizes = new int[] { 10, 100, 1_000, 10_000, 100_000, 1_000_000 };

List<int> guessesRequired;
foreach (int size in problemSizes)
{
    guessesRequired = new List<int>();

    for (int i = 0; i < repetitions; i++)
    {
        SecretNumber sn = new SecretNumber(0, size);
        int g = AlgorithmA.Guess(sn);

        if (g != sn.CheckSecretNumber)
        {
            throw new ApplicationException($"Algorithm failed to guess the secret number. Guessed: {g}, Actual: {sn.CheckSecretNumber}");
        }

        guessesRequired.Add(sn.NumGuesses);
    }

    Console.WriteLine($"Problem Size: {size}, Mean (Average) Num Guesses: {guessesRequired.Average()}");
}