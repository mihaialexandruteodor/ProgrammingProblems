using System.ComponentModel;

[Description("SearchRotatedArray")]
public class SearchRotatedArray : IBaseSolution
{
    // https://leetcode.com/problems/search-in-rotated-sorted-array/
    public void solve()
    {
        Solution solution = new Solution();
        Console.WriteLine("[4,5,6,7,0,1,2], t=0, Expected : 4");
        Console.WriteLine("Actual: " + solution.Search([4, 5, 6, 7, 0, 1, 2], 0));
    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            return 0;
        }
    }
}