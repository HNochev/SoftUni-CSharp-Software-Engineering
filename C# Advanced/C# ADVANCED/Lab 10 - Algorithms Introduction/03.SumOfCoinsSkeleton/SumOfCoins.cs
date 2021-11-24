using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        List<int> sortedCoins = coins
             .OrderByDescending(x => x)
             .ToList();

        Dictionary<int, int> chosenCoins = new Dictionary<int, int>();

        int currSum = 0;
        int coinIndex = 0;

        while (currSum != targetSum && coinIndex < sortedCoins.Count)
        {
            int currCoinValue = sortedCoins[coinIndex];

            int remainingSum = targetSum - currSum;

            int numberOfCoinsToTake = remainingSum / currCoinValue;

            if (numberOfCoinsToTake > 0)
            {
                chosenCoins[currCoinValue] = numberOfCoinsToTake;

                currSum += currCoinValue * numberOfCoinsToTake;
            }
            coinIndex++;
        }
        if (currSum == targetSum)
        {
            return chosenCoins;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}