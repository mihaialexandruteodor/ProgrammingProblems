using System;
using System.ComponentModel;

namespace problems.leetcode._190
{
    public class ReverseBits : IBaseSolution
    {
        // 
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
            Console.WriteLine("");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}