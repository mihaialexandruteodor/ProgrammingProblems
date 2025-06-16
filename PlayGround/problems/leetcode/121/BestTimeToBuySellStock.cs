namespace problems.leetcode._121
{
    public class BestTimeToBuySellStock : IBaseSolution
    {

        public void solve()
        {
            printProblem();
            int[] prices = [7, 1, 5, 3, 6, 4];
            Console.WriteLine(MaxProfit(prices));
        }


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

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("Problem: You are given an array prices where prices[i] is the price of a given stock on the ith day.\r\n\r\nYou want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.\r\n\r\nReturn the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.");
            Console.WriteLine();
        }
    }
}