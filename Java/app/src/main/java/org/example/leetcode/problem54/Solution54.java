package org.example.leetcode.problem54;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution54 extends BaseSolution {
    public Solution54() {
        this.name = "54. Spiral Matrix";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.MATRIX;
        this.description = "Given an m x n matrix, return all elements of the matrix in spiral order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: matrix = [[1,2,3],[4,5,6],[7,8,9]]\r\nOutput: [1,2,3,6,9,8,7,4,5]\r\n\r\nInput: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]\r\nOutput: [1,2,3,4,8,12,11,10,9,5,6,7]\r\n \r\n\r\nConstraints:\r\n\r\nm == matrix.length\r\nn == matrix[i].length\r\n1 <= m, n <= 10\r\n-100 <= matrix[i][j] <= 100";
        // https://leetcode.com/problems/spiral-matrix/
    }

    @Override
    public void solve() {

    }

}
