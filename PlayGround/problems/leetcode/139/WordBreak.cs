using System;
using System.Collections.Generic;
using System.Reflection;

namespace problems.leetcode._139
{
    // https://leetcode.com/problems/word-break/
    // DYNAMIC PROGRAMMING
    // https://www.youtube.com/watch?v=Sx9NNgInc3A
    public class WordBreak : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.\r\n\r\nNote that the same word in the dictionary may be reused multiple times in the segmentation.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"leetcode\", wordDict = [\"leet\",\"code\"]\r\nOutput: true\r\nExplanation: Return true because \"leetcode\" can be segmented as \"leet code\".\r\nExample 2:\r\n\r\nInput: s = \"applepenapple\", wordDict = [\"apple\",\"pen\"]\r\nOutput: true\r\nExplanation: Return true because \"applepenapple\" can be segmented as \"apple pen apple\".\r\nNote that you are allowed to reuse a dictionary word.\r\nExample 3:\r\n\r\nInput: s = \"catsandog\", wordDict = [\"cats\",\"dog\",\"sand\",\"and\",\"cat\"]\r\nOutput: false");
            Console.WriteLine();
        }
        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
        public void solve()
        {
            printProblem();
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
                                                        // initally filled with 'False' values only
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
}