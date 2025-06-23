using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._70
{
    public class ClimbingStairs : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.DynamicProgramming;
        // https://leetcode.com/problems/climbing-stairs/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("n = 3, Expected : 3");
            Console.WriteLine("Actual: " + solution.ClimbStairs(3));
        }

        public class Solution
        {
            public int ClimbStairs(int n)
            {
                if (n <= 2)
                    return n;

                int first = 1, second = 2;
                for (int i = 3; i <= n; i++)
                {
                    int third = first + second;
                    first = second;
                    second = third;
                }

                return second;
            }
        }


        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("You are climbing a staircase. It takes n steps to reach the top.\r\n\r\nEach time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: n = 2\r\nOutput: 2\r\nExplanation: There are two ways to climb to the top.\r\n1. 1 step + 1 step\r\n2. 2 steps\r\nExample 2:\r\n\r\nInput: n = 3\r\nOutput: 3\r\nExplanation: There are three ways to climb to the top.\r\n1. 1 step + 1 step + 1 step\r\n2. 1 step + 2 steps\r\n3. 2 steps + 1 step\r\n \r\n\r\nConstraints:\r\n\r\n1 <= n <= 45");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}