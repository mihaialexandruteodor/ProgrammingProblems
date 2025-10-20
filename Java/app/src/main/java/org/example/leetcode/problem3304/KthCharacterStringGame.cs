using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._3304
{
    public class KthCharacterStringGame : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.Binary;
        public static readonly string description = "Alice and Bob are playing a game. Initially, Alice has a string word = \"a\".\r\n\r\nYou are given a positive integer k.\r\n\r\nNow Bob will ask Alice to perform the following operation forever:\r\n\r\nGenerate a new string by changing each character in word to its next character in the English alphabet, and append it to the original word.\r\nFor example, performing the operation on \"c\" generates \"cd\" and performing the operation on \"zb\" generates \"zbac\".\r\n\r\nReturn the value of the kth character in word, after enough operations have been done for word to have at least k characters.\r\n\r\nNote that the character 'z' can be changed to 'a' in the operation.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: k = 5\r\n\r\nOutput: \"b\"\r\n\r\nExplanation:\r\n\r\nInitially, word = \"a\". We need to do the operation three times:\r\n\r\nGenerated string is \"b\", word becomes \"ab\".\r\nGenerated string is \"bc\", word becomes \"abbc\".\r\nGenerated string is \"bccd\", word becomes \"abbcbccd\".\r\nExample 2:\r\n\r\nInput: k = 10\r\n\r\nOutput: \"c\"\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= k <= 500";
        // https://leetcode.com/problems/find-the-k-th-character-in-string-game-i/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("k = 5 ,Expected : b");
            Console.WriteLine("Actual: " + solution.KthCharacter(5));
            Console.WriteLine("Explanation:");
            Console.WriteLine("The function computes the k-th character based on the following logic:");
            Console.WriteLine("1. Subtract 1 from the input k to get (k - 1).");
            Console.WriteLine("2. Convert (k - 1) into its binary representation.");
            Console.WriteLine("3. Count the number of 1s in that binary number.");
            Console.WriteLine("4. Starting from the character 'a', move forward by that count.");
            Console.WriteLine("5. The resulting character is returned as the answer.");
            Console.WriteLine("This effectively maps each k to a letter based on the number of bits set to 1 in (k - 1).");
        }

        public class Solution
        {
            public char KthCharacter(int k)
            {
                return (char)('a' + CountBits(k - 1));
            }

            private int CountBits(int n)
            {
                int count = 0;
                while (n != 0)
                {
                    count += n & 1;
                    n >>= 1;
                }
                return count;
            }
        }


        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}