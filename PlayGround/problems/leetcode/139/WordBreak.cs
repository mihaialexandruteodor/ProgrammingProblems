using System;
using System.Collections.Generic;

// https://leetcode.com/problems/word-break/
// DYNAMIC PROGRAMMING
// https://www.youtube.com/watch?v=Sx9NNgInc3A
public class WordBreak : IBaseSolution
{
    public void solve()
    {
        Solution solution = new Solution();
        Console.WriteLine("Expected True, got: " + solution.WordBreak("aaaaaaa", ["aaaa", "aaa"]));
        Console.WriteLine("Expected True, got: " + solution.WordBreak("leetcode", ["leet", "code"]));
        Console.WriteLine("Expected True, got: " + solution.WordBreak("applepenapple", ["apple", "pen"]));
        Console.WriteLine("Expected False, got: " + solution.WordBreak("catsandog", ["cats", "dog", "sand", "and", "cat"]));
    }
    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var wordSet = new HashSet<string>(wordDict);
            var dp = new bool[s.Length + 1];
            dp[0] = true; // empty string is always "breakable"

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }
    }

}