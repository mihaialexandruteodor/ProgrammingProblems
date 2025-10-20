using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._11
{
    public class ContainerWithMostWater : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Arrays;
        public static readonly string description = "You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).\r\n\r\nFind two lines that together with the x-axis form a container, such that the container contains the most water.\r\n\r\nReturn the maximum amount of water a container can store.\r\n\r\nNotice that you may not slant the container. \r\n\r\n Example 1:\r\nInput: height = [1,8,6,2,5,4,8,3,7]\r\nOutput: 49\r\nExplanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.";
        // https://leetcode.com/problems/container-with-most-water/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[1,8,6,2,5,4,8,3,7], Expected : 49");
            Console.WriteLine("Actual: " + solution.MaxArea([1, 8, 6, 2, 5, 4, 8, 3, 7]));
        }

        public class Solution
        {
            public int MaxArea(int[] height)
            {

                int MostWater = 0;
                int left = 0;
                int right = height.Length - 1;

                while (left < right)
                {
                    int rectangleHeight = Math.Min(height[left], height[right]);
                    int length = right - left;
                    int vol = rectangleHeight * length;

                    if (rectangleHeight * length > MostWater)
                        MostWater = vol;

                    if (height[left] < height[right])
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }

                return MostWater;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}