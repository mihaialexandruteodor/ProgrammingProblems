using System;
using System.ComponentModel;

namespace problems.leetcode._125
{
    public class ValidPalindrome : IBaseSolution
    {
        // https://leetcode.com/problems/valid-palindrome/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("\"A man, a plan, a canal: Panama\", Expected : True");
            Console.WriteLine("Actual: " + solution.IsPalindrome("A man, a plan, a canal: Panama"));
        }

        public class Solution
        {
            public bool IsPalindrome(string s)
            {
                int l = 0, r = s.Length - 1;

                while (l < r)
                {
                    // Skip non-alphanumeric characters from the left
                    while (l < r && !char.IsLetterOrDigit(s[l])) l++;

                    // Skip non-alphanumeric characters from the right
                    while (l < r && !char.IsLetterOrDigit(s[r])) r--;

                    // Compare lowercase versions of both characters
                    if (char.ToLower(s[l]) != char.ToLower(s[r]))
                        return false;

                    l++;
                    r--;
                }

                return true;
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.\r\n\r\nGiven a string s, return true if it is a palindrome, or false otherwise.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"A man, a plan, a canal: Panama\"\r\nOutput: true\r\nExplanation: \"amanaplanacanalpanama\" is a palindrome.\r\nExample 2:\r\n\r\nInput: s = \"race a car\"\r\nOutput: false\r\nExplanation: \"raceacar\" is not a palindrome.\r\nExample 3:\r\n\r\nInput: s = \" \"\r\nOutput: true\r\nExplanation: s is an empty string \"\" after removing non-alphanumeric characters.\r\nSince an empty string reads the same forward and backward, it is a palindrome.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 2 * 105\r\ns consists only of printable ASCII characters.");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}