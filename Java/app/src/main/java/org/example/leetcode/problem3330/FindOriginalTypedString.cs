using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._3330
{
    public class FindOriginalTypedString : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.String;
        public static readonly string description = "Alice is attempting to type a specific string on her computer. However, she tends to be clumsy and may press a key for too long, resulting in a character being typed multiple times.\r\n\r\nAlthough Alice tried to focus on her typing, she is aware that she may still have done this at most once.\r\n\r\nYou are given a string word, which represents the final output displayed on Alice's screen.\r\n\r\nReturn the total number of possible original strings that Alice might have intended to type.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: word = \"abbcccc\"\r\n\r\nOutput: 5\r\n\r\nExplanation:\r\n\r\nThe possible strings are: \"abbcccc\", \"abbccc\", \"abbcc\", \"abbc\", and \"abcccc\".\r\n\r\nExample 2:\r\n\r\nInput: word = \"abcd\"\r\n\r\nOutput: 1\r\n\r\nExplanation:\r\n\r\nThe only possible string is \"abcd\".\r\n\r\nExample 3:\r\n\r\nInput: word = \"aaaa\"\r\n\r\nOutput: 4\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= word.length <= 100\r\nword consists only of lowercase English letters.";
        // https://leetcode.com/problems/find-the-original-typed-string-i/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("abbcccc ,Expected : 5");
            Console.WriteLine("Actual: " + solution.PossibleStringCount("abbcccc"));
        }

        public class Solution
        {
            public int PossibleStringCount(string word)
            {
                int count = 1;
                char prev = '0';
                Dictionary<char, int> freq = new();
                foreach (char c in word)
                {
                    if (!freq.ContainsKey(c))
                    {
                        freq.Add(c, 1);
                    }
                    else if (c == prev)
                    {
                        freq[c]++;
                    }
                    prev = c;
                }

                foreach (var kvp in freq)
                    if (kvp.Value > 1)
                        count += kvp.Value - 1;

                return count;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}