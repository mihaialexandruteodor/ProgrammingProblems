package org.example.leetcode.problem54;

import java.util.ArrayList;
import java.util.List;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution54 extends BaseSolution {
    public Solution54() {
        this.name = "54. Spiral Matrix";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.MATRIX;
        this.description = "Given an m x n matrix, return all elements of the matrix in spiral order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: matrix = [[1,2,3],[4,5,6],[7,8,9]]\r\nOutput: [1,2,3,6,9,8,7,4,5]\r\n\r\nInput: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]\r\nOutput: [1,2,3,4,8,12,11,10,9,5,6,7]\r\n \r\n\r\nConstraints:\r\n\r\nm == matrix.length\r\nn == matrix[i].length\r\n1 <= m, n <= 10\r\n-100 <= matrix[i][j] <= 100";
        this.leetcodeurl = "https://leetcode.com/problems/spiral-matrix/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[[1,2,3],[4,5,6],[7,8,9]], Expected : [1,2,3,6,9,8,7,4,5]");
        int[][] matrix = new int[][] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
        };
        System.out.println("Actual: " + Utils.printForConsole(solution.spiralOrder(matrix)));
    }

    public class Solution {

        enum Direction {
            UP, DOWN, LEFT, RIGHT
        }

        public List<Integer> spiralOrder(int[][] matrix) {
            List<Integer> spiral = new ArrayList<>();
            int rows = matrix.length, cols = matrix[0].length;
            int[] count = new int[] { 0 }; // mutable counter
            int target = rows * cols;
            int[] limitLeft = { 0 }, limitRight = { cols }, limitUp = { 0 }, limitDown = { rows };

            class Step {
                void makeStep(int x, int y, Direction dir) {
                    spiral.add(matrix[x][y]);
                    count[0]++;
                    if (count[0] == target)
                        return;

                    switch (dir) {
                        case UP -> {
                            if (x - 1 < limitUp[0]) {
                                limitLeft[0]++;
                                makeStep(x, y + 1, Direction.RIGHT);
                            } else {
                                makeStep(x - 1, y, Direction.UP);
                            }
                        }
                        case DOWN -> {
                            if (x + 1 >= limitDown[0]) {
                                limitRight[0]--;
                                makeStep(x, y - 1, Direction.LEFT);
                            } else {
                                makeStep(x + 1, y, Direction.DOWN);
                            }
                        }
                        case LEFT -> {
                            if (y - 1 < limitLeft[0]) {
                                limitDown[0]--;
                                makeStep(x - 1, y, Direction.UP);
                            } else {
                                makeStep(x, y - 1, Direction.LEFT);
                            }
                        }
                        case RIGHT -> {
                            if (y + 1 >= limitRight[0]) {
                                limitUp[0]++;
                                makeStep(x + 1, y, Direction.DOWN);
                            } else {
                                makeStep(x, y + 1, Direction.RIGHT);
                            }
                        }
                    }
                }
            }

            new Step().makeStep(0, 0, Direction.RIGHT);
            return spiral;
        }
    }

}
