package org.example.leetcode.problem3592;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution3592 extends BaseSolution {
    public Solution3592() {
        this.name = "3592. Inverse Coin Change";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "You are given a 1-indexed integer array numWays, where numWays[i] represents the number of ways to select a total amount i using an infinite supply of some fixed coin denominations. Each denomination is a positive integer with value at most numWays.length.\r\n\r\nHowever, the exact coin denominations have been lost. Your task is to recover the set of denominations that could have resulted in the given numWays array.\r\n\r\nReturn a sorted array containing unique integers which represents this set of denominations.\r\n\r\nIf no such set exists, return an empty array.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: numWays = [0,1,0,2,0,3,0,4,0,5]\r\n\r\nOutput: [2,4,6]\r\n\r\nExample 2:\r\nInput: numWays = [1,2,2,3,4]\r\n\r\nOutput: [1,2,5]\r\n\r\nExample 3:\r\n\r\nInput: numWays = [1,2,3,4,15]\r\n\r\nOutput: []\r\n\r\nExplanation:\r\n\r\nNo set of denomination satisfies this array.\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= numWays.length <= 100\r\n0 <= numWays[i] <= 2 * 108";
        // https://leetcode.com/problems/inverse-coin-change/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[0,1,0,2,0,3,0,4,0,5] ,Expected : [2,4,6]");
        System.out.println(
                "Actual: " + Utils.printForConsole(solution.findCoins(new int[] { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5 })));
    }

    public class Solution {
        public List<Integer> findCoins(int[] numWays) {
            int n = numWays.length;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            List<Integer> result = new ArrayList<>();

            for (int i = 1; i <= n; i++) {
                if (dp[i] == numWays[i - 1])
                    continue;

                if (dp[i] > numWays[i - 1])
                    return new ArrayList<>();

                // Try adding coin of value i
                result.add(i);

                // Recompute dp from scratch
                Arrays.fill(dp, 0);
                dp[0] = 1;

                for (int coin : result) {
                    for (int j = coin; j <= n; j++) {
                        dp[j] += dp[j - coin];
                    }
                }

                // Check consistency so far
                for (int k = 1; k <= i; k++) {
                    if (dp[k] != numWays[k - 1])
                        return new ArrayList<>();
                }
            }

            return result;
        }
    }

}
