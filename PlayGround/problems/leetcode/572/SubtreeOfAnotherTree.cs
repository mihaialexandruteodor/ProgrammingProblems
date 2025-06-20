using System;
using System.ComponentModel;

namespace problems.leetcode._
{
    public class SubtreeOfAnotherTree : IBaseSolution
    {
        // 
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

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Easy");
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