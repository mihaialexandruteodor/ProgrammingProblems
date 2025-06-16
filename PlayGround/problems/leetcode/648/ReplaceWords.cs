using PlayGround.problems.DSA;
namespace problems.leetcode._648
{
    public class ReplaceWords : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: In English, we have a concept called root, which can be followed by some other word to form another longer word - let's call this word derivative. For example, when the root \"help\" is followed by the word \"ful\", we can form a derivative \"helpful\".\r\n\r\nGiven a dictionary consisting of many roots and a sentence consisting of words separated by spaces, replace all the derivatives in the sentence with the root forming it. If a derivative can be replaced by more than one root, replace it with the root that has the shortest length.\r\n\r\nReturn the sentence after the replacement.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: dictionary = [\"cat\",\"bat\",\"rat\"], sentence = \"the cattle was rattled by the battery\"\r\nOutput: \"the cat was rat by the bat\"\r\nExample 2:\r\n\r\nInput: dictionary = [\"a\",\"b\",\"c\"], sentence = \"aadsfasf absbs bbab cadsfafs\"\r\nOutput: \"a a b c\"\r\n \r\n\r\nConstraints:\r\n\r\n1 <= dictionary.length <= 1000\r\n1 <= dictionary[i].length <= 100\r\ndictionary[i] consists of only lower-case letters.\r\n1 <= sentence.length <= 106\r\nsentence consists of only lower-case letters and spaces.\r\nThe number of words in sentence is in the range [1, 1000]\r\nThe length of each word in sentence is in the range [1, 1000]\r\nEvery two consecutive words in sentence will be separated by exactly one space.\r\nsentence does not have leading or trailing spaces.");
            Console.WriteLine();
        }

        // https://leetcode.com/problems/replace-words/description/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("Expected : the cat was rat by the bat");
            Console.WriteLine("Actual: " + solution.ReplaceWords(["cat", "bat", "rat"], "the cattle was rattled by the battery"));
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
            public string Word = null;
        }

        public class Solution
        {
            private TrieNode BuildTrie(IList<string> dictionary)
            {
                var root = new TrieNode();

                foreach (var word in dictionary)
                {
                    var node = root;
                    foreach (var c in word)
                    {
                        if (!node.Children.ContainsKey(c))
                            node.Children[c] = new TrieNode();
                        node = node.Children[c];
                    }
                    node.Word = word; // mark the end of a root word
                }

                return root;
            }

            public string ReplaceWords(IList<string> dictionary, string sentence)
            {
                TrieNode trie = BuildTrie(dictionary);
                string[] words = sentence.Split(' ');
                List<string> result = new List<string>();

                foreach (string word in words)
                {
                    TrieNode node = trie;
                    string replacement = "";

                    foreach (char c in word)
                    {
                        if (!node.Children.ContainsKey(c) || node.Word != null)
                            break;

                        node = node.Children[c];
                    }

                    replacement = node.Word ?? word;
                    result.Add(replacement);
                }

                return string.Join(" ", result);
            }
        }
    }
}