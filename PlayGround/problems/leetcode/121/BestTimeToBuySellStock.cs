using static IBaseSolution;

namespace problems.leetcode._121
{
    public class BestTimeToBuySellStock : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.Arrays;
        public static readonly string description = "Problem: You are given an array prices where prices[i] is the price of a given stock on the ith day.\r\n\r\nYou want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.\r\n\r\nReturn the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.";

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            int[] prices = [7, 1, 5, 3, 6, 4];
            Solution solution = new Solution();
            Console.WriteLine("[7, 1, 5, 3, 6, 4], Expected : 5");
            Console.WriteLine("Actual: " + solution.MaxProfit(prices));
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

        public class Solution
        {
            public int MaxProfit(int[] prices)
            {

                int buy = 0, sell = 1;

                int maxProfit = 0;

                while (sell < prices.Length)
                {
                    Console.WriteLine(buy + " : " + sell);
                    int currentProfit = prices[sell] - prices[buy]; //our current Profit
                    if (prices[buy] < prices[sell])
                        maxProfit = Math.Max(currentProfit, maxProfit);
                    else
                        buy = sell;
                    sell++;
                }

                return maxProfit;
            }
        }

    }
}