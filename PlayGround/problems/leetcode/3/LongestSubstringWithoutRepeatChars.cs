using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._3
{
    public class LongestSubstringWithoutRepeatChars : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.String;
        public static readonly string description = "Given a string s, find the length of the longest substring without duplicate characters.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"abcabcbb\"\r\nOutput: 3\r\nExplanation: The answer is \"abc\", with the length of 3.\r\nExample 2:\r\n\r\nInput: s = \"bbbbb\"\r\nOutput: 1\r\nExplanation: The answer is \"b\", with the length of 1.\r\nExample 3:\r\n\r\nInput: s = \"pwwkew\"\r\nOutput: 3\r\nExplanation: The answer is \"wke\", with the length of 3.\r\nNotice that the answer must be a substring, \"pwke\" is a subsequence and not a substring.\r\n \r\n\r\nConstraints:\r\n\r\n0 <= s.length <= 5 * 104\r\ns consists of English letters, digits, symbols and spaces.";
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("\"abcabcbb\", Expected : 3");
            Console.WriteLine("Actual: " + solution.LengthOfLongestSubstring("abcabcbb"));
        }

        public class Solution
        {
            public int LengthOfLongestSubstringSubfunction(string s)
            {
                int maxLen = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i + 1; j <= s.Length; j++)
                    {
                        string substr = s.Substring(i, j - i);
                        if (substr.Length == substr.Distinct().Count())
                        {
                            if (substr.Length > maxLen)
                                maxLen = substr.Length;
                        }
                    }
                }

                return maxLen;
            }

            private bool CheckIfStringContainsNewLineCharacters(string str)
            {
                if (str.Length != 0)
                {
                    if (str.Contains(" "))
                        return true;

                    using (var reader = new System.IO.StringReader(str))
                    {
                        reader.ReadLine();
                        return reader.Peek() != -1;
                    }
                }
                return false;
            }

            public int LengthOfLongestSubstring(string s)
            {
                if (s.Length == 0)
                    return 0;

                if (string.IsNullOrWhiteSpace(s))
                    return 1;

                int maxLen = 0;

                if (CheckIfStringContainsNewLineCharacters(s))
                {
                    string[] linesArray = null;
                    bool whiteSpaceSeparator = false;

                    if (s.Contains("\\r?\\n|\\r"))
                    {
                        linesArray = System.Text.RegularExpressions.Regex.Split(s, "\\r?\\n|\\r");
                    }
                    else if (s.Contains(" "))
                    {
                        linesArray = s.Split(' ');
                        whiteSpaceSeparator = true;
                    }

                    HashSet<string> lines = new HashSet<string>(linesArray);

                    foreach (var line in lines)
                    {
                        int len = LengthOfLongestSubstringSubfunction(line);
                        if (len > maxLen)
                        {
                            maxLen = len;
                            if (whiteSpaceSeparator)
                                maxLen++; // +1 on account of the whitespace separator
                        }
                    }

                    return maxLen;
                }

                return LengthOfLongestSubstringSubfunction(s);
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}