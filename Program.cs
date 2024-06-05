using System;
using System.Collections.Generic;
using System.Linq;

class ShuffleGame
{
    static void Main()
    {
        // Create a deck of cards represented as integers
        List<int> deck = Enumerable.Range(1, 52).ToList();

        char playAgain = 'y';
        while (playAgain == 'y' || playAgain == 'Y')
        {
            PlayGame(deck);
            Console.Write("Do you want to play again? (y/n): ");
            playAgain = Console.ReadLine()[0];
        }

        Console.WriteLine("Thanks for playing!");
    }

    static void PlayGame(List<int> deck)
    {
        Console.Write("Enter the position of the target card (1-" + deck.Count + "): ");
        int targetCardPosition = int.Parse(Console.ReadLine());

        if (targetCardPosition < 1 || targetCardPosition > deck.Count)
        {
            Console.WriteLine("Invalid position. Please enter a number between 1 and " + deck.Count + ".");
            return;
        }

        int targetValue = deck[targetCardPosition - 1];

        Console.WriteLine("Now, let's shuffle the deck...");
        List<int> shuffledDeck = new List<int>(deck);
        ShuffleDeck(shuffledDeck);

        int position = shuffledDeck.IndexOf(targetValue) + 1;

        Console.WriteLine("The target card was found at position: " + position);

        if (position == targetCardPosition)
        {
            Console.WriteLine("Congratulations! You guessed correctly!");
        }
        else
        {
            Console.WriteLine("Sorry, you guessed incorrectly. Better luck next time!");
        }
    }

    static void ShuffleDeck<T>(List<T> deck)
    {
        Random rng = new Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }
}
