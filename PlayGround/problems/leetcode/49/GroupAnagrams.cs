using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._49
{
    public class GroupAnagrams : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.String;
        // https://leetcode.com/problems/group-anagrams/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[\"eat\",\"tea\",\"tan\",\"ate\",\"nat\",\"bat\"], Expected : [[\"bat\"],[\"nat\",\"tan\"],[\"ate\",\"eat\",\"tea\"]]");
            Console.WriteLine("Actual: [" + string.Join(",", solution.GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]).Select(inner =>
    "[" + string.Join(",", inner.Select(s => $"\"{s}\"")) + "]")) + "]");
        }

        public class Solution
        {

            private string SortString(string s)
            {
                return String.Concat(s.OrderBy(c => c));
            }

            public class MultiDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
            {
                public void Add(TKey key, TValue value)
                {
                    if (TryGetValue(key, out List<TValue> valueList))
                    {
                        valueList.Add(value);
                    }
                    else
                    {
                        Add(key, new List<TValue> { value });
                    }
                }
            }

            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                List<string[]> res = new List<string[]>();
                MultiDictionary<string, string> orderMappings = new MultiDictionary<string, string>();
                foreach (string s in strs)
                    orderMappings.Add(SortString(s), s);

                foreach (var item in orderMappings)
                {
                    res.Add(item.Value.ToArray());
                }

                return res.ToArray();

            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Given an array of strings strs, group the anagrams together. You can return the answer in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: strs = [\"eat\",\"tea\",\"tan\",\"ate\",\"nat\",\"bat\"]\r\n\r\nOutput: [[\"bat\"],[\"nat\",\"tan\"],[\"ate\",\"eat\",\"tea\"]]\r\n\r\nExplanation:\r\n\r\nThere is no string in strs that can be rearranged to form \"bat\".\r\nThe strings \"nat\" and \"tan\" are anagrams as they can be rearranged to form each other.\r\nThe strings \"ate\", \"eat\", and \"tea\" are anagrams as they can be rearranged to form each other.\r\nExample 2:\r\n\r\nInput: strs = [\"\"]\r\n\r\nOutput: [[\"\"]]\r\n\r\nExample 3:\r\n\r\nInput: strs = [\"a\"]\r\n\r\nOutput: [[\"a\"]]\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= strs.length <= 104\r\n0 <= strs[i].length <= 100\r\nstrs[i] consists of lowercase English letters.");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}