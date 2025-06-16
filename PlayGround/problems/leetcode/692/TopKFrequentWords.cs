using System.ComponentModel;

namespace problems.leetcode._692
{
    public class TopKFrequentWords : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Given an array of strings words and an integer k, return the k most frequent strings.\r\n\r\nReturn the answer sorted by the frequency from highest to lowest. Sort the words with the same frequency by their lexicographical order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: words = [\"i\",\"love\",\"leetcode\",\"i\",\"love\",\"coding\"], k = 2\r\nOutput: [\"i\",\"love\"]\r\nExplanation: \"i\" and \"love\" are the two most frequent words.\r\nNote that \"i\" comes before \"love\" due to a lower alphabetical order.\r\nExample 2:\r\n\r\nInput: words = [\"the\",\"day\",\"is\",\"sunny\",\"the\",\"the\",\"the\",\"sunny\",\"is\",\"is\"], k = 4\r\nOutput: [\"the\",\"is\",\"sunny\",\"day\"]\r\nExplanation: \"the\", \"is\", \"sunny\" and \"day\" are the four most frequent words, with the number of occurrence being 4, 3, 2 and 1 respectively.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= words.length <= 500\r\n1 <= words[i].length <= 10\r\nwords[i] consists of lowercase English letters.\r\nk is in the range [1, The number of unique words[i]]\r\n \r\n\r\nFollow-up: Could you solve it in O(n log(k)) time and O(n) extra space?");
        }

        // https://leetcode.com/problems/top-k-frequent-words/
        public void solve()
        {
                printProblem();
            Solution solution = new Solution();
            Console.WriteLine("Expected : ");
            Console.WriteLine("Actual: ");
        }

    public class Solution
    {

    }
}
}