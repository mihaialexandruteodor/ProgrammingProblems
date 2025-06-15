namespace problems.leetcode._121
{
    public class BestTimeToBuySellStock : IBaseSolution
    {

        public void solve()
        {
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

    }
}