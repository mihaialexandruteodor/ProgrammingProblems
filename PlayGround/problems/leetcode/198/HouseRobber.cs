public class HouseRobber : IBaseSolution
{

    public void solve()
    {
        int[] houses = [2, 1, 1, 2];
        Console.WriteLine(Rob(houses));
    }


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