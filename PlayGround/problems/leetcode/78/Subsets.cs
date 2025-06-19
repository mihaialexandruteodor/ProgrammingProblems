using System;
using System.ComponentModel;

namespace problems.leetcode._78
{
    public class Subsets : IBaseSolution
    {
        // https://leetcode.com/problems/subsets/
        // BACKTRACKING
        public void solve()
        {
            Solution solution = new Solution();
            Console.WriteLine("Expected : ");
            Console.WriteLine("Actual: ");
        }

        public class Solution
        {

        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Given an integer array nums of unique elements, return all possible subsets (the power set).\r\n\r\nThe solution set must not contain duplicate subsets. Return the solution in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3]\r\nOutput: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]\r\nExample 2:\r\n\r\nInput: nums = [0]\r\nOutput: [[],[0]]\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 10\r\n-10 <= nums[i] <= 10\r\nAll the numbers of nums are unique.");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}