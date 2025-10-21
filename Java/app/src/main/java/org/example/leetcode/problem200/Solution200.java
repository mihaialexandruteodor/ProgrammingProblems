package org.example.leetcode.problem200;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution200 extends BaseSolution {
    public Solution200() {
        this.name = "200. Number of Islands";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.GRAPHS;
        this.description = "Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.\r\n\r\nAn island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: grid = [\r\n  [\"1\",\"1\",\"1\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"0\",\"0\"]\r\n]\r\nOutput: 1\r\nExample 2:\r\n\r\nInput: grid = [\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"1\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"1\",\"1\"]\r\n]\r\nOutput: 3\r\n \r\n\r\nConstraints:\r\n\r\nm == grid.length\r\nn == grid[i].length\r\n1 <= m, n <= 300\r\ngrid[i][j] is '0' or '1'.";
        this.leetcodeurl = "https://leetcode.com/problems/number-of-islands/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        char[][] grid = new char[][] {
                { '1', '1', '1', '1', '0' },
                { '1', '1', '0', '1', '0' },
                { '1', '1', '0', '0', '0' },
                { '0', '0', '0', '0', '0' }
        };

        System.out.println("Expected : 1");
        System.out.println("Actual: " + solution.numIslands(grid));
    }

    public class Solution {
        public int numIslands(char[][] grid) {
            if (grid == null || grid.length == 0)
                return 0;

            int rows = grid.length;
            int cols = grid[0].length;
            boolean[][] visited = new boolean[rows][cols];
            int count = 0;

            int[][] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

            // DFS helper
            java.util.function.BiConsumer<Integer, Integer> dfs = new java.util.function.BiConsumer<>() {
                @Override
                public void accept(Integer r, Integer c) {
                    visited[r][c] = true;
                    for (int[] d : directions) {
                        int nr = r + d[0];
                        int nc = c + d[1];
                        if (nr >= 0 && nr < rows && nc >= 0 && nc < cols &&
                                grid[nr][nc] == '1' && !visited[nr][nc]) {
                            this.accept(nr, nc);
                        }
                    }
                }
            };

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    if (grid[r][c] == '1' && !visited[r][c]) {
                        count++;
                        dfs.accept(r, c);
                    }
                }
            }

            return count;
        }
    }

}
