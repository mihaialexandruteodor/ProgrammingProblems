package org.example.leetcode.problem200;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution200 extends BaseSolution {
    public Solution200() {
        this.name = "200. Number of Islands";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.GRAPHS;
        this.description = "Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.\r\n\r\nAn island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: grid = [\r\n  [\"1\",\"1\",\"1\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"0\",\"0\"]\r\n]\r\nOutput: 1\r\nExample 2:\r\n\r\nInput: grid = [\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"1\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"1\",\"1\"]\r\n]\r\nOutput: 3\r\n \r\n\r\nConstraints:\r\n\r\nm == grid.length\r\nn == grid[i].length\r\n1 <= m, n <= 300\r\ngrid[i][j] is '0' or '1'.";
        // https://leetcode.com/problems/number-of-islands/
    }

    @Override
    public void solve() {

    }

}
