using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._242
{
    public class ValidAnagram : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.String;
        public static readonly string description = "Given two strings s and t, return true if t is an anagram of s, and false otherwise.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"anagram\", t = \"nagaram\"\r\n\r\nOutput: true\r\n\r\nExample 2:\r\n\r\nInput: s = \"rat\", t = \"car\"\r\n\r\nOutput: false\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length, t.length <= 5 * 104\r\ns and t consist of lowercase English letters.\r\n \r\n\r\nFollow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?";
        // https://leetcode.com/problems/valid-anagram/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("s = \"anagram\", t = \"nagaram\", Expected : True");
            Console.WriteLine("Actual: " + solution.IsAnagram("anagram", "nagaram"));
        }

        public class Solution
        {
            public bool IsAnagram(string s, string t)
            {
                Dictionary<char, int> freqS = new();
                Dictionary<char, int> freqT = new();
                if (s.Length != t.Length)
                    return false;
                for (int i = 0; i < s.Length; ++i)
                {
                    char c = s[i];
                    if (freqS.ContainsKey(c))
                    {
                        freqS[c]++;
                    }
                    else
                    {
                        freqS[c] = 1;
                    }

                    c = t[i];
                    if (freqT.ContainsKey(c))
                    {
                        freqT[c]++;
                    }
                    else
                    {
                        freqT[c] = 1;
                    }
                }

                if (freqS.Count() != freqT.Count())
                    return false;
                else
                {
                    foreach (var kvp in freqS)
                    {
                        if (freqT.ContainsKey(kvp.Key) == false || kvp.Value != freqT[kvp.Key])
                            return false;
                    }
                }

                return true;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}