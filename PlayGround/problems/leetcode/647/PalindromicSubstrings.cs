﻿using System;
using System.Collections.Generic;

namespace problems.leetcode._647
{
    public class PalindromicSubstrings : IBaseSolution
    {
        //https://leetcode.com/problems/palindromic-substrings/

        public void solve()
        {
            Solution solution = new Solution();
            Console.WriteLine("abc, expect 3, actual: " + solution.CountSubstrings("abc"));
            Console.WriteLine("aaa, expect 6, actual: " + solution.CountSubstrings("aaa"));
        }

        // neetcode solution, waaay more efficient -> O(n^2)
        // https://www.youtube.com/watch?v=4RACzI5-du8
        public class Solution
        {
            public int CountSubstrings(string s)
            {
                int res = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    // Odd-length palindromes
                    int l = i, r = i;
                    while (l >= 0 && r < s.Length && s[l] == s[r])
                    {
                        res++;
                        l--;
                        r++;
                    }

                    // Even-length palindromes
                    l = i;
                    r = i + 1;
                    while (l >= 0 && r < s.Length && s[l] == s[r])
                    {
                        res++;
                        l--;
                        r++;
                    }
                }

                return res;
            }
        }

        // my approach
        /*public class Solution
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
        }*/

    }
}