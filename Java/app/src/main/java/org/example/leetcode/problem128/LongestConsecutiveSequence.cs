using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._128
{
    public class LongestConsecutiveSequence : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Graphs;
        public static readonly string description = "Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.\r\n\r\nYou must write an algorithm that runs in O(n) time.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [100,4,200,1,3,2]\r\nOutput: 4\r\nExplanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.\r\nExample 2:\r\n\r\nInput: nums = [0,3,7,2,5,8,4,6,0,1]\r\nOutput: 9\r\nExample 3:\r\n\r\nInput: nums = [1,0,1,2]\r\nOutput: 3\r\n \r\n\r\nConstraints:\r\n\r\n0 <= nums.length <= 105\r\n-109 <= nums[i] <= 109";
        // https://leetcode.com/problems/longest-consecutive-sequence/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[100,4,200,1,3,2], Expected : 4");
            Console.WriteLine("Actual: " + solution.LongestConsecutive([100, 4, 200, 1, 3, 2]));
        }

        public class Solution
        {
            public int LongestConsecutive(int[] nums)
            {
                if (nums.Length == 0)
                    return 0;


                SortedSet<int> vals = new SortedSet<int>(nums);

                int maxConsec = 0;
                int currConsec = 1;
                int prevVal = vals.First() - 2;

                foreach (int val in vals)
                {
                    //Console.Write(val);
                    //Console.WriteLine(prevVal + " -> " + val);
                    if (val - prevVal == 1)
                        currConsec++;
                    else
                    {

                        if (currConsec > maxConsec)
                            maxConsec = currConsec;
                        currConsec = 1;
                    }
                    prevVal = val;
                }
                //Console.WriteLine();

                if (currConsec > maxConsec)
                    maxConsec = currConsec;

                return maxConsec;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}