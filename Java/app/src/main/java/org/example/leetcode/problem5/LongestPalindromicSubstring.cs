using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._5
{
    public class LongestPalindromicSubstring : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.String;
        public static readonly string description = "Given a string s, return the longest palindromic substring in s.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"babad\"\r\nOutput: \"bab\"\r\nExplanation: \"aba\" is also a valid answer.\r\nExample 2:\r\n\r\nInput: s = \"cbbd\"\r\nOutput: \"bb\"\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 1000\r\ns consist of only digits and English letters.";
        // https://leetcode.com/problems/longest-palindromic-substring/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("\"babad\", Expected : bab or aba");
            Console.WriteLine("Actual: " + solution.LongestPalindrome("babad"));
        }

        public class Solution
        {
            public bool CheckPal(string str)
            {
                char[] arr = str.ToCharArray();
                Array.Reverse(arr);
                return str.Equals(new string(arr));
            }

            public string LongestPalindrome(string s)
            {
                if (s.Length == 1)
                    return s;

                int maxLenPal = 0;
                string maxPal = "";

                for (int st = 0; st < s.Length - 1; ++st)
                {
                    for (int ed = s.Length - 1; ed > st; --ed)
                    {
                        if (s[st] == s[ed])
                        {
                            string substr = s.Substring(st, ed - st + 1);
                            if (CheckPal(substr))
                            {
                                if (ed - st + 1 > maxLenPal)
                                {
                                    maxPal = substr;
                                    maxLenPal = ed - st + 1;
                                }
                            }
                        }
                    }
                }

                if (s.Length > 1 && maxLenPal == 0)
                    return s[0].ToString();

                return maxPal;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}