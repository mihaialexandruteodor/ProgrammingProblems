using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._200
{
    public class NumberOfIslands : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Graphs;
        public static readonly string description = "Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.\r\n\r\nAn island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: grid = [\r\n  [\"1\",\"1\",\"1\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"0\",\"0\"]\r\n]\r\nOutput: 1\r\nExample 2:\r\n\r\nInput: grid = [\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"1\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"1\",\"1\"]\r\n]\r\nOutput: 3\r\n \r\n\r\nConstraints:\r\n\r\nm == grid.length\r\nn == grid[i].length\r\n1 <= m, n <= 300\r\ngrid[i][j] is '0' or '1'.";
        // https://leetcode.com/problems/number-of-islands/

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

        // GRAPH PROBLEM

        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[[\"1\",\"1\",\"1\",\"1\",\"0\"],[\"1\",\"1\",\"0\",\"1\",\"0\"],[\"1\",\"1\",\"0\",\"0\",\"0\"],[\"0\",\"0\",\"0\",\"0\",\"0\"]]\r\n\r\nExpected : 1");
            Console.WriteLine("Actual: " + solution.NumIslands([['1', '1', '1', '1', '0'], ['1', '1', '0', '1', '0'], ['1', '1', '0', '0', '0'], ['0', '0', '0', '0', '0']]));
        }

        public class Solution
        {
            public int NumIslands(char[][] grid)
            {
                HashSet<(int, int)> visited = new();
                int rows = grid.Length;
                int cols = grid[0].Length;
                int count = 0;
                List<(int r, int c)> getNeighbors(int row, int col)
                {
                    List<(int r, int c)> neighbors = new();
                    (int r, int c)[] directions = [(0, 1), (1, 0), (0, -1), (-1, 0)];
                    foreach (var d in directions)
                    {
                        int newRow = row + d.r;
                        int newCol = col + d.c;
                        if (0 <= newRow &&
                            newRow < rows &&
                            0 <= newCol &&
                            newCol < cols &&
                            grid[newRow][newCol] == '1'
                        )
                        {
                            neighbors.Add((newRow, newCol));
                        }
                    }

                    return neighbors;
                }


                void dfs(int row, int col)
                {
                    visited.Add((row, col));
                    var neighbors = getNeighbors(row, col);
                    foreach (var neighbor in neighbors)
                    {
                        if (visited.Contains(neighbor))
                            continue;
                        dfs(neighbor.r, neighbor.c);
                    }
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (grid[r][c] == '1' && !visited.Contains((r, c)))
                        {
                            count++;
                            dfs(r, c);
                        }
                    }
                }

                return count;
            }
        }
    }
}