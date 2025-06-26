using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._3592
{
    public class InverseCoinChange : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.String;
        public static readonly string description = "You are given a 1-indexed integer array numWays, where numWays[i] represents the number of ways to select a total amount i using an infinite supply of some fixed coin denominations. Each denomination is a positive integer with value at most numWays.length.\r\n\r\nHowever, the exact coin denominations have been lost. Your task is to recover the set of denominations that could have resulted in the given numWays array.\r\n\r\nReturn a sorted array containing unique integers which represents this set of denominations.\r\n\r\nIf no such set exists, return an empty array.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: numWays = [0,1,0,2,0,3,0,4,0,5]\r\n\r\nOutput: [2,4,6]\r\n\r\nExample 2:\r\nInput: numWays = [1,2,2,3,4]\r\n\r\nOutput: [1,2,5]\r\n\r\nExample 3:\r\n\r\nInput: numWays = [1,2,3,4,15]\r\n\r\nOutput: []\r\n\r\nExplanation:\r\n\r\nNo set of denomination satisfies this array.\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= numWays.length <= 100\r\n0 <= numWays[i] <= 2 * 108";
        // https://leetcode.com/problems/inverse-coin-change/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[0,1,0,2,0,3,0,4,0,5] ,Expected : [2,4,6]");
            Console.WriteLine("Actual: " + Utils.PrintForConsole(solution.FindCoins([0, 1, 0, 2, 0, 3, 0, 4, 0, 5])));
        }

        public class Solution
        {
            public IList<int> FindCoins(int[] numWays)
            {
                int n = numWays.Length;
                int[] dp = new int[n + 1];
                dp[0] = 1;
                List<int> result = new();

                for (int i = 1; i <= n; i++)
                {
                    if (dp[i] == numWays[i - 1])
                        continue;

                    if (dp[i] > numWays[i - 1])
                        return new List<int>();

                    // Try adding coin of value i
                    result.Add(i);

                    // Recompute dp from scratch
                    Array.Fill(dp, 0);
                    dp[0] = 1;

                    foreach (int coin in result)
                    {
                        for (int j = coin; j <= n; j++)
                        {
                            dp[j] += dp[j - coin];
                        }
                    }

                    // Check consistency so far
                    for (int k = 1; k <= i; k++)
                    {
                        if (dp[k] != numWays[k - 1])
                            return new List<int>();
                    }
                }

                return result;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}