using System;
using System.Collections.Generic;

namespace problems.leetcode._647
{
    public class PalindromicSubstrings : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: Given a string s, return the number of palindromic substrings in it.\r\n\r\nA string is a palindrome when it reads the same backward as forward.\r\n\r\nA substring is a contiguous sequence of characters within the string.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"abc\"\r\nOutput: 3\r\nExplanation: Three palindromic strings: \"a\", \"b\", \"c\".\r\nExample 2:\r\n\r\nInput: s = \"aaa\"\r\nOutput: 6\r\nExplanation: Six palindromic strings: \"a\", \"a\", \"a\", \"aa\", \"aa\", \"aaa\".\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 1000\r\ns consists of lowercase English letters.");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

        //https://leetcode.com/problems/palindromic-substrings/

        public void solve()
        {
            printProblem();
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