using System;
using System.ComponentModel;
using System.Text;
using static IBaseSolution;

namespace problems.leetcode._1717
{
    public class MaxScoreRemoveSubstrings : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.String;
        public static readonly string description = "You are given a string s and two integers x and y. You can perform two types of operations any number of times.\r\n\r\nRemove substring \"ab\" and gain x points.\r\nFor example, when removing \"ab\" from \"cabxbae\" it becomes \"cxbae\".\r\nRemove substring \"ba\" and gain y points.\r\nFor example, when removing \"ba\" from \"cabxbae\" it becomes \"cabxe\".\r\nReturn the maximum points you can gain after applying the above operations on s.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"cdbcbbaaabab\", x = 4, y = 5\r\nOutput: 19\r\nExplanation:\r\n- Remove the \"ba\" underlined in \"cdbcbbaaabab\". Now, s = \"cdbcbbaaab\" and 5 points are added to the score.\r\n- Remove the \"ab\" underlined in \"cdbcbbaaab\". Now, s = \"cdbcbbaa\" and 4 points are added to the score.\r\n- Remove the \"ba\" underlined in \"cdbcbbaa\". Now, s = \"cdbcba\" and 5 points are added to the score.\r\n- Remove the \"ba\" underlined in \"cdbcba\". Now, s = \"cdbc\" and 5 points are added to the score.\r\nTotal score = 5 + 4 + 5 + 5 = 19.\r\nExample 2:\r\n\r\nInput: s = \"aabbaaxybbaabb\", x = 5, y = 4\r\nOutput: 20\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 105\r\n1 <= x, y <= 104\r\ns consists of lowercase English letters.\r\n";
        // https://leetcode.com/problems/maximum-score-from-removing-substrings/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("s = \"cdbcbbaaabab\", x = 4, y = 5 ,Expected : 19");
            Console.WriteLine("Actual: " + solution.MaximumGain("cdbcbbaaabab", 4, 5));
        }

        public class Solution
        {
            public int MaximumGain(string s, int x, int y)
            {
                if (x < y)
                {
                    // Always handle the higher point first
                    (x, y) = (y, x);
                    s = ReversePairs(s);  // Transform "ab" <=> "ba" while keeping relative structure
                }

                int score = 0;
                Stack<char> stack = new Stack<char>();

                // First pass: remove "ab" and gain x points
                foreach (char c in s)
                {
                    if (stack.Count > 0 && stack.Peek() == 'a' && c == 'b')
                    {
                        stack.Pop();
                        score += x;
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }

                // Reconstruct string for second pass
                var temp = new Stack<char>();
                while (stack.Count > 0)
                {
                    temp.Push(stack.Pop());
                }

                // Second pass: remove "ba" and gain y points
                foreach (char c in temp)
                {
                    if (stack.Count > 0 && stack.Peek() == 'b' && c == 'a')
                    {
                        stack.Pop();
                        score += y;
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }

                return score;
            }

            private string ReversePairs(string s)
            {
                // Swaps all 'a' with 'b' and vice versa
                var sb = new StringBuilder();
                foreach (char c in s)
                {
                    if (c == 'a') sb.Append('b');
                    else if (c == 'b') sb.Append('a');
                    else sb.Append(c);
                }
                return sb.ToString();
            }
        }


        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}