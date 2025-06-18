using System.ComponentModel;

namespace problems.leetcode._200
{
    public class NumberOfIslands : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.\r\n\r\nAn island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: grid = [\r\n  [\"1\",\"1\",\"1\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"0\",\"0\"]\r\n]\r\nOutput: 1\r\nExample 2:\r\n\r\nInput: grid = [\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"1\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"1\",\"1\"]\r\n]\r\nOutput: 3\r\n \r\n\r\nConstraints:\r\n\r\nm == grid.length\r\nn == grid[i].length\r\n1 <= m, n <= 300\r\ngrid[i][j] is '0' or '1'.");
            Console.WriteLine();
        }

        // GRAPH PROBLEM
        // https://leetcode.com/problems/number-of-islands/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("Expected : ");
            Console.WriteLine("Actual: ");
        }

        public class Solution
        {

        }
    }
}