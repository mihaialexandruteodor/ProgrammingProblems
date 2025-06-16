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
            Console.WriteLine("[\"i\",\"love\",\"leetcode\",\"i\",\"love\",\"coding\"], Expected : [\"i\",\"love\",\"coding\"]");
            Console.WriteLine("Actual: " + "[" + string.Join(",", solution.TopKFrequent(["i", "love", "leetcode", "i", "love", "coding"], 3)) + "]");
        }

        public class Solution
        {
            // Custom comparer to sort by frequency descending, then lex ascending
            public class WordFreqComparer : IComparer<(int freq, string word)>
            {
                public int Compare((int freq, string word) a, (int freq, string word) b)
                {
                    int freqCompare = b.freq.CompareTo(a.freq); // higher freq first
                    if (freqCompare != 0)
                        return freqCompare;

                    return a.word.CompareTo(b.word); // lex order for tie
                }
            }

            public IList<string> TopKFrequent(string[] words, int k)
            {
                var dict = new Dictionary<string, int>();
                foreach (var word in words)
                {
                    dict[word] = dict.GetValueOrDefault(word, 0) + 1;
                }

                // Priority queue with custom comparer
                var pq = new PriorityQueue<string, (int freq, string word)>(new WordFreqComparer());

                foreach (var kvp in dict)
                {
                    pq.Enqueue(kvp.Key, (kvp.Value, kvp.Key));
                }

                var res = new List<string>();
                for (int i = 0; i < k && pq.Count > 0; i++)
                {
                    res.Add(pq.Dequeue());
                }

                return res;
            }
        }

    }
}