using System.ComponentModel;
using System.Text;

namespace problems.leetcode._417
{
    public class PacificAtlanticWaterFlow : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.\r\n\r\nThe island is partitioned into a grid of square cells. You are given an m x n integer matrix heights where heights[r][c] represents the height above sea level of the cell at coordinate (r, c).\r\n\r\nThe island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and west if the neighboring cell's height is less than or equal to the current cell's height. Water can flow from any cell adjacent to an ocean into the ocean.\r\n\r\nReturn a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow from cell (ri, ci) to both the Pacific and Atlantic oceans.\r\nExample 1: Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]\r\nOutput: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]\r\nExplanation: The following cells can flow to the Pacific and Atlantic oceans, as shown below:\r\n[0,4]: [0,4] -> Pacific Ocean \r\n       [0,4] -> Atlantic Ocean\r\n[1,3]: [1,3] -> [0,3] -> Pacific Ocean \r\n       [1,3] -> [1,4] -> Atlantic Ocean\r\n[1,4]: [1,4] -> [1,3] -> [0,3] -> Pacific Ocean \r\n       [1,4] -> Atlantic Ocean\r\n[2,2]: [2,2] -> [1,2] -> [0,2] -> Pacific Ocean \r\n       [2,2] -> [2,3] -> [2,4] -> Atlantic Ocean\r\n[3,0]: [3,0] -> Pacific Ocean \r\n       [3,0] -> [4,0] -> Atlantic Ocean\r\n[3,1]: [3,1] -> [3,0] -> Pacific Ocean \r\n       [3,1] -> [4,1] -> Atlantic Ocean\r\n[4,0]: [4,0] -> Pacific Ocean \r\n       [4,0] -> Atlantic Ocean\r\nNote that there are other possible paths for these cells to flow to the Pacific and Atlantic oceans.\r\nExample 2:\r\n\r\nInput: heights = [[1]]\r\nOutput: [[0,0]]\r\nExplanation: The water can flow from the only cell to the Pacific and Atlantic oceans.\r\n \r\n\r\nConstraints:\r\n\r\nm == heights.length\r\nn == heights[r].length\r\n1 <= m, n <= 200\r\n0 <= heights[r][c] <= 105");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

        // https://leetcode.com/problems/pacific-atlantic-water-flow/
        // 
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]], Expected : [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]");
            Console.Write("Actual: ");
            PrintListOfLists(solution.PacificAtlantic([[1, 2, 2, 3, 5], [3, 2, 3, 4, 4], [2, 4, 5, 3, 1], [6, 7, 1, 4, 5], [5, 1, 1, 2, 4]]));
        }

        static void PrintListOfLists(IList<IList<int>> list)
        {
            var sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append("[");
                sb.Append(string.Join(",", list[i]));
                sb.Append("]");
                if (i < list.Count - 1)
                    sb.Append(",");
            }

            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }

        public class Solution
        {
            public IList<IList<int>> PacificAtlantic(int[][] heights)
            {
                int rows = heights.Length;
                int cols = heights[0].Length;
                List<List<int>> res = new();

                void dfs(int r, int c, HashSet<(int, int)> visit, int prevHeight)
                {
                    if (visit.Contains((r, c)) ||
                        r < 0 || c < 0 || r == rows || c == cols ||
                        heights[r][c] < prevHeight)
                        return;
                    visit.Add((r, c));
                    dfs(r + 1, c, visit, heights[r][c]);
                    dfs(r - 1, c, visit, heights[r][c]);
                    dfs(r, c + 1, visit, heights[r][c]);
                    dfs(r, c - 1, visit, heights[r][c]);
                }

                var pac = new HashSet<(int, int)>();
                var atl = new HashSet<(int, int)>();
                for (int c = 0; c < cols; ++c)
                {     //rows
                    dfs(0, c, pac, heights[0][c]);
                    dfs(rows - 1, c, atl, heights[rows - 1][c]);
                }

                for (int r = 0; r < rows; ++r)
                {     //cols
                    dfs(r, 0, pac, heights[r][0]);
                    dfs(r, cols - 1, atl, heights[r][cols - 1]);
                }

                for (int r = 0; r < rows; ++r)
                {
                    for (int c = 0; c < cols; ++c)
                    {
                        if (pac.Contains((r, c)) && atl.Contains((r, c)))
                        {
                            res.Add([r, c]);
                        }
                    }
                }

                return res.Cast<IList<int>>().ToList(); ;
            }
        }
    }
}