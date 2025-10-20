package org.example.leetcode.problem322;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution322 extends BaseSolution {
    public Solution322() {
        this.name = "322. Coin Change";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.\r\n\r\nReturn the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.\r\n\r\nYou may assume that you have an infinite number of each kind of coin.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: coins = [1,2,5], amount = 11\r\nOutput: 3\r\nExplanation: 11 = 5 + 5 + 1\r\nExample 2:\r\n\r\nInput: coins = [2], amount = 3\r\nOutput: -1\r\nExample 3:\r\n\r\nInput: coins = [1], amount = 0\r\nOutput: 0\r\n \r\n\r\nConstraints:\r\n\r\n1 <= coins.length <= 12\r\n1 <= coins[i] <= 231 - 1\r\n0 <= amount <= 104";
        // https://leetcode.com/problems/coin-change/
    }

    @Override
    public void solve() {

    }

}
