namespace problems.leetcode._198
{
    public class HouseRobber : IBaseSolution
    {

        public void solve()
        {
            printProblem();
            int[] houses = [2, 1, 1, 2];
            Solution solution = new Solution();
            Console.WriteLine("Expected : 4");
            Console.WriteLine("Actual: " + solution.Rob(houses));
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

        public class Solution
        {
            public int Rob(int[] nums)
            {

                int[] DP = new int[nums.Length];

                if (nums.Length <= 0)
                    return 0;

                if (nums.Length == 1)
                    return nums[0];

                if (nums.Length == 2)
                    return Math.Max(nums[0], nums[1]);

                DP[0] = nums[0];
                DP[1] = nums[1];

                int max = Math.Max(nums[0], nums[1]);
                int maxOneBack = nums[0];

                for (int i = 2; i < nums.Length; ++i)
                {

                    maxOneBack = Math.Max(DP[i - 2], maxOneBack);
                    DP[i] = nums[i] + maxOneBack;

                    if (DP[i] > max)
                        max = DP[i];
                }

                return max;
            }
        }
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.\r\n\r\nGiven an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3,1]\r\nOutput: 4\r\nExplanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).\r\nTotal amount you can rob = 1 + 3 = 4.\r\nExample 2:\r\n\r\nInput: nums = [2,7,9,3,1]\r\nOutput: 12\r\nExplanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).\r\nTotal amount you can rob = 2 + 9 + 1 = 12.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 100\r\n0 <= nums[i] <= 400");
            Console.WriteLine();
        }
    }
}