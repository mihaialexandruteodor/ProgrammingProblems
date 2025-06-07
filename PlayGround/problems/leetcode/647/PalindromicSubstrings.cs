using System;
using System.Collections.Generic;

public class PalindromicSubstrings: IBaseSolution
{
    //https://leetcode.com/problems/palindromic-substrings/

    public void solve()
    {
        Solution solution = new Solution();
        Console.WriteLine("abc, expect 3, actual: " + solution.CountSubstrings("abc"));
        Console.WriteLine("aaa, expect 6, actual: " + solution.CountSubstrings("aaa"));
    }
    public class Solution
    {
        public bool checkIfStringIsPalindrome(int stIndex, int edIndex, string s)
        {
            if (string.IsNullOrEmpty(s) || stIndex < 0 || edIndex >= s.Length || stIndex > edIndex)
                return false;

            while (stIndex < edIndex)
            {
                if (s[stIndex] != s[edIndex])
                    return false;
                stIndex++;
                edIndex--;
            }

            return true;
        }

        public int CountSubstrings(string s)
        {
            int count = s.Length;
            for (int i = 0; i < s.Length - 1; ++i)
                for (int j = i + 1; j < s.Length; ++j)
                    if (checkIfStringIsPalindrome(i, j, s))
                        count++;

            return count;
        }
    }
}