﻿using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._   //add the problem number here, ex: problems.leetcode._102
{
    // use a descriptive class name
    public class TEMPLATE_LEETCODE : IBaseSolution
    {
        // set acordingly, will be used on the selector screen
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.String;
        public static readonly string description = "";
        // 
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("Expected : ");
            //you can call the Solution class here, ex: Console.WriteLine("Actual: " + solution.IsSubtree(BuildTree([3, 4, 5, 1, 2]), BuildTree([4, 1, 2])));
            Console.WriteLine("Actual: ");
        }

        //paste Solution class here from leetcode
        public class Solution
        {
            // code here
        }

        // this will print the Solution class as text
        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}