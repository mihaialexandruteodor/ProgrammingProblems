using System;
using System.Collections.Generic;
using System.Reflection;

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
            var dp = new bool[s.Length + 1];        // dp[i] == true means:
                                                    // The substring s[0..i) (from index 0 up to but not including i)
                                                    // can be segmented into words from wordDict.
                        dp[0] = true; // empty string is always "breakable"

            for (int i = 1; i <= s.Length; i++)     // This loop goes through every possible end index i in the string s
            {
                for (int j = 0; j < i; j++)     // This loop goes through every possible split point j between 0 and i.
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