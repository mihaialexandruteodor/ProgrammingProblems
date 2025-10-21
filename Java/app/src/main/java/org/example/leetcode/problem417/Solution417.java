package org.example.leetcode.problem417;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution417 extends BaseSolution {
    public Solution417() {
        this.name = "417. Pacific Atlantic Water Flow";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.GRAPHS;
        this.description = "Problem: There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.\r\n\r\nThe island is partitioned into a grid of square cells. You are given an m x n integer matrix heights where heights[r][c] represents the height above sea level of the cell at coordinate (r, c).\r\n\r\nThe island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and west if the neighboring cell's height is less than or equal to the current cell's height. Water can flow from any cell adjacent to an ocean into the ocean.\r\n\r\nReturn a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow from cell (ri, ci) to both the Pacific and Atlantic oceans.\r\nExample 1: Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]\r\nOutput: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]\r\nExplanation: The following cells can flow to the Pacific and Atlantic oceans, as shown below:\r\n[0,4]: [0,4] -> Pacific Ocean \r\n       [0,4] -> Atlantic Ocean\r\n[1,3]: [1,3] -> [0,3] -> Pacific Ocean \r\n       [1,3] -> [1,4] -> Atlantic Ocean\r\n[1,4]: [1,4] -> [1,3] -> [0,3] -> Pacific Ocean \r\n       [1,4] -> Atlantic Ocean\r\n[2,2]: [2,2] -> [1,2] -> [0,2] -> Pacific Ocean \r\n       [2,2] -> [2,3] -> [2,4] -> Atlantic Ocean\r\n[3,0]: [3,0] -> Pacific Ocean \r\n       [3,0] -> [4,0] -> Atlantic Ocean\r\n[3,1]: [3,1] -> [3,0] -> Pacific Ocean \r\n       [3,1] -> [4,1] -> Atlantic Ocean\r\n[4,0]: [4,0] -> Pacific Ocean \r\n       [4,0] -> Atlantic Ocean\r\nNote that there are other possible paths for these cells to flow to the Pacific and Atlantic oceans.\r\nExample 2:\r\n\r\nInput: heights = [[1]]\r\nOutput: [[0,0]]\r\nExplanation: The water can flow from the only cell to the Pacific and Atlantic oceans.\r\n \r\n\r\nConstraints:\r\n\r\nm == heights.length\r\nn == heights[r].length\r\n1 <= m, n <= 200\r\n0 <= heights[r][c] <= 105";
        this.leetcodeurl = "https://leetcode.com/problems/pacific-atlantic-water-flow/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        int[][] heights = {
                { 1, 2, 2, 3, 5 },
                { 3, 2, 3, 4, 4 },
                { 2, 4, 5, 3, 1 },
                { 6, 7, 1, 4, 5 },
                { 5, 1, 1, 2, 4 }
        };
        System.out.println("Expected : [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]");
        System.out.println("Actual: " + Utils.printForConsole(solution.pacificAtlantic(heights)));
    }

    public class Solution {
        private final int[][] dirs = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

        public List<List<Integer>> pacificAtlantic(int[][] heights) {
            int rows = heights.length, cols = heights[0].length;
            boolean[][] pac = new boolean[rows][cols];
            boolean[][] atl = new boolean[rows][cols];

            for (int c = 0; c < cols; c++) {
                dfs(heights, 0, c, pac);
                dfs(heights, rows - 1, c, atl);
            }
            for (int r = 0; r < rows; r++) {
                dfs(heights, r, 0, pac);
                dfs(heights, r, cols - 1, atl);
            }

            List<List<Integer>> res = new ArrayList<>();
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    if (pac[r][c] && atl[r][c]) {
                        res.add(Arrays.asList(r, c));
                    }
                }
            }
            return res;
        }

        private void dfs(int[][] heights, int r, int c, boolean[][] visited) {
            visited[r][c] = true;
            for (int[] dir : dirs) {
                int nr = r + dir[0], nc = c + dir[1];
                if (nr < 0 || nc < 0 || nr >= heights.length || nc >= heights[0].length)
                    continue;
                if (visited[nr][nc] || heights[nr][nc] < heights[r][c])
                    continue;
                dfs(heights, nr, nc, visited);
            }
        }
    }

}
