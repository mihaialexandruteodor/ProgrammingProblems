using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._787
{
    public class CheapestFlightsKStops : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Graphs;
        // https://leetcode.com/problems/cheapest-flights-within-k-stops/description/
        // https://www.youtube.com/watch?v=5eIK3zUdYmE
        // got this at a Booking Holdings interview, ridiculously hard to figure on the spot...
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: There are n cities connected by some number of flights. You are given an array flights where flights[i] = [fromi, toi, pricei] indicates that there is a flight from city fromi to city toi with cost pricei.\r\n\r\nYou are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k stops. If there is no such route, return -1.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], src = 0, dst = 3, k = 1\r\nOutput: 700\r\nExplanation:\r\nThe graph is shown above.\r\nThe optimal path with at most 1 stop from city 0 to 3 is marked in red and has cost 100 + 600 = 700.\r\nNote that the path through cities [0,1,2,3] is cheaper but is invalid because it uses 2 stops.\r\n\r\nExample 2: Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 1\r\nOutput: 200\r\nExplanation:\r\nThe graph is shown above.\r\nThe optimal path with at most 1 stop from city 0 to 2 is marked in red and has cost 100 + 100 = 200.\r\n\r\nExample 3: Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 0\r\nOutput: 500\r\nExplanation:\r\nThe graph is shown above.\r\nThe optimal path with no stops from city 0 to 2 is marked in red and has cost 500.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= n <= 100\r\n0 <= flights.length <= (n * (n - 1) / 2)\r\nflights[i].length == 3\r\n0 <= fromi, toi < n\r\nfromi != toi\r\n1 <= pricei <= 104\r\nThere will not be any multiple flights between two cities.\r\n0 <= src, dst, k < n\r\nsrc != dst");
            Console.WriteLine();
        }
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("Expected : 700");
            Console.WriteLine("Actual: " + solution.FindCheapestPrice(4, [[0, 1, 100], [1, 2, 100],
        [2, 0, 100], [1, 3, 600], [2, 3, 200]], 0, 3, 1));
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
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
