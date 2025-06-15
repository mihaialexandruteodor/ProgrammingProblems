namespace problems.leetcode._2149
{
    public class RearrangeArrayElementsBySign : IBaseSolution
    {
        public void solve()
        {
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
    }
}