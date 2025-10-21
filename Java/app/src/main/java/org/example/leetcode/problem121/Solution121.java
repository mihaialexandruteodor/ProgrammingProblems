package org.example.leetcode.problem121;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution121 extends BaseSolution {
    public Solution121() {
        this.name = "121. Best Time to Buy and Sell Stock";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.ARRAYS;
        this.description = "Problem: You are given an array prices where prices[i] is the price of a given stock on the ith day.\r\n\r\nYou want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.\r\n\r\nReturn the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.";
        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[7,1,5,3,6,4], Expected : 5");
        System.out.println("Actual: " + solution.maxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
    }

    public class Solution {
        public int maxProfit(int[] prices) {
            int buy = 0, sell = 1;
            int maxProfit = 0;

            while (sell < prices.length) {
                int currentProfit = prices[sell] - prices[buy];
                if (prices[buy] < prices[sell]) {
                    maxProfit = Math.max(maxProfit, currentProfit);
                } else {
                    buy = sell;
                }
                sell++;
            }

            return maxProfit;
        }
    }

}
