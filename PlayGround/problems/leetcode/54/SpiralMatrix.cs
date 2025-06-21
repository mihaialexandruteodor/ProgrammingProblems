using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._54
{
    public class SpiralMatrix : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Matrix;
        // https://leetcode.com/problems/spiral-matrix/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[[1,2,3],[4,5,6],[7,8,9]], Expected : [1,2,3,6,9,8,7,4,5]");
            Console.WriteLine("Actual: [" + string.Join(",", solution.SpiralOrder([[1, 2, 3], [4, 5, 6], [7, 8, 9]])) + "]");
        }

        public class Solution
        {

            enum Direction
            {
                Up,
                Down,
                Left,
                Right
            }

            public IList<int> SpiralOrder(int[][] matrix)
            {
                List<int> spiral = new();
                int rows = matrix.Length, cols = matrix[0].Length;
                int count = 0, target = rows * cols;
                int limitLeft = 0, limitRight = cols, limitUp = 0, limitDown = rows;

                void MakeStep(int currX, int currY, Direction prevDir)
                {
                    spiral.Add(matrix[currX][currY]);
                    count++;
                    if (count == target)
                        return;
                    switch (prevDir)
                    {
                        case Direction.Up:
                            if (currX - 1 < limitUp)
                            {
                                // Hit the top boundary, turn right
                                limitLeft++;
                                MakeStep(currX, currY + 1, Direction.Right);
                            }
                            else
                            {
                                // Continue moving up
                                MakeStep(currX - 1, currY, Direction.Up);
                            }
                            break;

                        case Direction.Down:
                            if (currX + 1 >= limitDown)
                            {
                                // Hit the bottom boundary, turn left
                                limitRight--;
                                MakeStep(currX, currY - 1, Direction.Left);
                            }
                            else
                            {
                                // Continue moving down
                                MakeStep(currX + 1, currY, Direction.Down);
                            }
                            break;

                        case Direction.Left:
                            if (currY - 1 < limitLeft)
                            {
                                // Hit the left boundary, turn up
                                limitDown--;
                                MakeStep(currX - 1, currY, Direction.Up);
                            }
                            else
                            {
                                // Continue moving left
                                MakeStep(currX, currY - 1, Direction.Left);
                            }
                            break;

                        case Direction.Right:
                            if (currY + 1 >= limitRight)
                            {
                                // Hit the right boundary, turn down
                                limitUp++;
                                MakeStep(currX + 1, currY, Direction.Down);
                            }
                            else
                            {
                                // Continue moving right
                                MakeStep(currX, currY + 1, Direction.Right);
                            }
                            break;
                    }
                }

                MakeStep(0, 0, Direction.Right);

                return spiral;
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Given an m x n matrix, return all elements of the matrix in spiral order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: matrix = [[1,2,3],[4,5,6],[7,8,9]]\r\nOutput: [1,2,3,6,9,8,7,4,5]\r\n\r\nInput: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]\r\nOutput: [1,2,3,4,8,12,11,10,9,5,6,7]\r\n \r\n\r\nConstraints:\r\n\r\nm == matrix.length\r\nn == matrix[i].length\r\n1 <= m, n <= 10\r\n-100 <= matrix[i][j] <= 100");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}