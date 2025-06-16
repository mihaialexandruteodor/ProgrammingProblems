namespace problems.leetcode._2149
{
    public class RearrangeArrayElementsBySign : IBaseSolution
    {
        public void solve()
        {
            printProblem();
            int[] nums = new int[] { -1, 1 };
            var res = RearrangeArray(nums);
            foreach (int item in res)
                Console.Write(item + " ");
            Console.WriteLine();
        }
        public int[] RearrangeArray(int[] nums)
        {
            int pos = 0, neg = 0, ind = 0;

            while (nums[pos] < 0)
                pos++;

            while (nums[neg] >= 0)
                neg++;

            int[] res = new int[nums.Length];

            while (ind < nums.Length)
            {

                //pos for positive number
                if (ind % 2 == 0)
                {
                    res[ind] = nums[pos];
                    pos++;
                }
                else //pos for negative number
                {
                    res[ind] = nums[neg];
                    neg++;
                }
                while (pos < nums.Length && nums[pos] < 0)
                    pos++;

                while (neg < nums.Length && nums[neg] >= 0)
                    neg++;

                ind++;
            }

            return res;

        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: You are given a 0-indexed integer array nums of even length consisting of an equal number of positive and negative integers.\r\n\r\nYou should return the array of nums such that the the array follows the given conditions:\r\n\r\nEvery consecutive pair of integers have opposite signs.\r\nFor all integers with the same sign, the order in which they were present in nums is preserved.\r\nThe rearranged array begins with a positive integer.\r\nReturn the modified array after rearranging the elements to satisfy the aforementioned conditions.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [3,1,-2,-5,2,-4]\r\nOutput: [3,-2,1,-5,2,-4]\r\nExplanation:\r\nThe positive integers in nums are [3,1,2]. The negative integers are [-2,-5,-4].\r\nThe only possible way to rearrange them such that they satisfy all conditions is [3,-2,1,-5,2,-4].\r\nOther ways such as [1,-2,2,-5,3,-4], [3,1,2,-2,-5,-4], [-2,3,-5,1,-4,2] are incorrect because they do not satisfy one or more conditions.  \r\nExample 2:\r\n\r\nInput: nums = [-1,1]\r\nOutput: [1,-1]\r\nExplanation:\r\n1 is the only positive integer and -1 the only negative integer in nums.\r\nSo nums is rearranged to [1,-1].\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 2 * 105\r\nnums.length is even\r\n1 <= |nums[i]| <= 105\r\nnums consists of equal number of positive and negative integers.\r\n \r\n\r\nIt is not required to do the modifications in-place.");
            Console.WriteLine();
        }
    }
}