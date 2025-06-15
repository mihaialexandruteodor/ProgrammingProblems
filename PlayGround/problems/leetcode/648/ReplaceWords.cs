using PlayGround.problems.DSA;
namespace problems.leetcode._648
{
    public class ReplaceWords : IBaseSolution
    {
        // https://leetcode.com/problems/replace-words/description/
        public void solve()
        {
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