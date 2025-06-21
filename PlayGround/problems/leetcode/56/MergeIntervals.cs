using System;
using System.ComponentModel;
using System.Text;
using static IBaseSolution;

namespace problems.leetcode._56
{
    public class MergeIntervals : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Interval;
        // https://leetcode.com/problems/merge-intervals/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[[1,3],[2,6],[8,10],[15,18]], Expected : [[1,6],[8,10],[15,18]]");
            Console.Write("Actual: ");
            PrintListOfLists(solution.Merge([[1, 3], [2, 6], [8, 10], [15, 18]]));
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
            public int[][] Merge(int[][] intervals)
            {

                if (intervals.Length == 1)
                    return intervals;

                Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

                List<int[]> newIntervals = new List<int[]>();
                newIntervals.Add(intervals[0]);

                for (int i = 1; i < intervals.Length; ++i)
                {
                    int start = intervals[i][0];
                    int end = intervals[i][1];
                    int lastEnd = newIntervals.Last()[1];

                    if (start <= lastEnd)
                        newIntervals.Last()[1] = Math.Max(lastEnd, end);
                    else
                        newIntervals.Add(intervals[i]);
                }


                return newIntervals.ToArray();
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: intervals = [[1,3],[2,6],[8,10],[15,18]]\r\nOutput: [[1,6],[8,10],[15,18]]\r\nExplanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].\r\nExample 2:\r\n\r\nInput: intervals = [[1,4],[4,5]]\r\nOutput: [[1,5]]\r\nExplanation: Intervals [1,4] and [4,5] are considered overlapping.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= intervals.length <= 104\r\nintervals[i].length == 2\r\n0 <= starti <= endi <= 104");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}