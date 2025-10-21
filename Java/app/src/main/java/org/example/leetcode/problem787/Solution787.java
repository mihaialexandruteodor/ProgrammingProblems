package org.example.leetcode.problem787;

import java.util.Arrays;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution787 extends BaseSolution {
    public Solution787() {
        this.name = "787. Cheapest Flights Within K Stops";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.GRAPHS;
        this.description = "Problem: There are n cities connected by some number of flights. You are given an array flights where flights[i] = [fromi, toi, pricei] indicates that there is a flight from city fromi to city toi with cost pricei.\r\n\r\nYou are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k stops. If there is no such route, return -1.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], src = 0, dst = 3, k = 1\r\nOutput: 700\r\nExplanation:\r\nThe graph is shown above.\r\nThe optimal path with at most 1 stop from city 0 to 3 is marked in red and has cost 100 + 600 = 700.\r\nNote that the path through cities [0,1,2,3] is cheaper but is invalid because it uses 2 stops.\r\n\r\nExample 2: Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 1\r\nOutput: 200\r\nExplanation:\r\nThe graph is shown above.\r\nThe optimal path with at most 1 stop from city 0 to 2 is marked in red and has cost 100 + 100 = 200.\r\n\r\nExample 3: Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 0\r\nOutput: 500\r\nExplanation:\r\nThe graph is shown above.\r\nThe optimal path with no stops from city 0 to 2 is marked in red and has cost 500.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= n <= 100\r\n0 <= flights.length <= (n * (n - 1) / 2)\r\nflights[i].length == 3\r\n0 <= fromi, toi < n\r\nfromi != toi\r\n1 <= pricei <= 104\r\nThere will not be any multiple flights between two cities.\r\n0 <= src, dst, k < n\r\nsrc != dst";
        // https://leetcode.com/problems/cheapest-flights-within-k-stops/description/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("Expected : 700");
        System.out.println("Actual: " + solution.findCheapestPrice(4, new int[][] {
                { 0, 1, 100 }, { 1, 2, 100 }, { 2, 0, 100 }, { 1, 3, 600 }, { 2, 3, 200 }
        }, 0, 3, 1));
    }

    public class Solution {
        public int findCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
            int[] prices = new int[n];
            Arrays.fill(prices, Integer.MAX_VALUE);
            prices[src] = 0;

            for (int i = 0; i <= k; i++) {
                int[] temp = prices.clone();
                for (int[] flight : flights) {
                    int cur = flight[0], next = flight[1], price = flight[2];
                    if (prices[cur] == Integer.MAX_VALUE)
                        continue;
                    temp[next] = Math.min(temp[next], prices[cur] + price);
                }
                prices = temp;
            }

            return prices[dst] == Integer.MAX_VALUE ? -1 : prices[dst];
        }
    }

}
