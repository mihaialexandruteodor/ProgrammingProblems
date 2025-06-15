using System.ComponentModel;

namespace problems.leetcode._787
{
    public class CheapestFlightsKStops : IBaseSolution
    {
        // https://leetcode.com/problems/cheapest-flights-within-k-stops/description/
        // https://www.youtube.com/watch?v=5eIK3zUdYmE
        // got this at a Booking Holdings interview, ridiculously hard to figure on the spot...
        public void solve()
        {
            Solution solution = new Solution();
            Console.WriteLine("Expected : 700");
            Console.WriteLine("Actual: " + solution.FindCheapestPrice(4, [[0, 1, 100], [1, 2, 100],
        [2, 0, 100], [1, 3, 600], [2, 3, 200]], 0, 3, 1));
        }

        public class Solution
        {
            public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
            {
                int[] prices = Enumerable.Repeat(Int32.MaxValue, n).ToArray();

                prices[src] = 0;
                for (int i = 0; i <= k; i++)
                {
                    int[] temp = (int[])prices.Clone();
                    foreach (int[] flight in flights)
                    {
                        int cur = flight[0], next = flight[1], price = flight[2];
                        if (prices[cur] == Int32.MaxValue) continue;
                        temp[next] = Math.Min(temp[next], prices[cur] + price);
                    }
                    prices = temp;
                }
                return prices[dst] == Int32.MaxValue ? -1 : prices[dst];
            }
        }
    }
}
