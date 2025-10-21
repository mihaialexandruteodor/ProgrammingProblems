package org.example.leetcode.problem62;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution62 extends BaseSolution {
    public Solution62() {
        this.name = "62. Unique Paths";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.\n"
                + //
                "\n" + //
                "Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.\n"
                + //
                "\n" + //
                "The test cases are generated so that the answer will be less than or equal to 2 * 109.\n" + //
                "\n" + //
                " \n" + //
                "\n" + //
                "Example 1:Input: m = 3, n = 7\n" + //
                "Output: 28\n" + //
                "Example 2:\n" + //
                "\n" + //
                "Input: m = 3, n = 2\n" + //
                "Output: 3\n" + //
                "Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:\n"
                + //
                "1. Right -> Down -> Down\n" + //
                "2. Down -> Down -> Right\n" + //
                "3. Down -> Right -> Down\n" + //
                " \n" + //
                "\n" + //
                "Constraints:\n" + //
                "\n" + //
                "1 <= m, n <= 100";
        this.leetcodeurl = "https://leetcode.com/problems/unique-paths/";
    }

    class Solution {
        /**
         * Calculate the number of unique paths from top-left to bottom-right in an m x
         * n grid.
         * Movement is restricted to either right or down at any point.
         * 
         * @param m number of rows in the grid
         * @param n number of columns in the grid
         * @return total number of unique paths
         */
        public int uniquePaths(int m, int n) {
            // Create a 2D DP array to store the number of paths to each cell
            int[][] dp = new int[m][n];

            // Initialize the starting position with 1 path (base case)
            dp[0][0] = 1;

            // Fill the DP table by iterating through each cell
            for (int row = 0; row < m; row++) {
                for (int col = 0; col < n; col++) {
                    // Add paths from the cell above (if exists)
                    if (row > 0) {
                        dp[row][col] += dp[row - 1][col];
                    }

                    // Add paths from the cell to the left (if exists)
                    if (col > 0) {
                        dp[row][col] += dp[row][col - 1];
                    }
                }
            }

            // Return the number of paths to reach the bottom-right corner
            return dp[m - 1][n - 1];
        }
    }

    @Override
    public void solve() {
        if (!isGuiRun) {
            Utils.getInstance().printProblem(description, difficulty, topic);
        }
        Solution solution = new Solution();
        System.out.println("Expected : 28");
        System.out.println("Actual:" + solution.uniquePaths(3, 7));
    }

}
