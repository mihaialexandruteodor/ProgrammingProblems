using System;
using System.ComponentModel;

namespace problems.leetcode._322
{
    public class CoinChange : IBaseSolution
    {
        // https://leetcode.com/problems/coin-change/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("coins = [1,2,5], amount = 11, Expected : 3");
            Console.WriteLine("Explanation: 11 = 5 + 5 + 1");
            Console.WriteLine("Actual: " + solution.CoinChange([1, 2, 5], 11));
        }

        public class Solution
        {
            public int CoinChange(int[] coins, int amount)
            {

                var DP = Enumerable.Repeat(amount + 1, amount + 1).ToArray();
                DP[0] = 0;

                for (int target = 1; target <= amount; ++target)
                    foreach (int coin in coins)
                        if (target - coin >= 0)
                            DP[target] = Math.Min(DP[target], 1 + DP[target - coin]);

                return DP[amount] == amount + 1 ? -1 : DP[amount];
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.\r\n\r\nReturn the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.\r\n\r\nYou may assume that you have an infinite number of each kind of coin.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: coins = [1,2,5], amount = 11\r\nOutput: 3\r\nExplanation: 11 = 5 + 5 + 1\r\nExample 2:\r\n\r\nInput: coins = [2], amount = 3\r\nOutput: -1\r\nExample 3:\r\n\r\nInput: coins = [1], amount = 0\r\nOutput: 0\r\n \r\n\r\nConstraints:\r\n\r\n1 <= coins.length <= 12\r\n1 <= coins[i] <= 231 - 1\r\n0 <= amount <= 104");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}