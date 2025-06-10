using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.problems.DSA
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEndOfWord = false;
    }

    public class Trie
    {
        private readonly TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        // Insert a word into the trie
        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                    node.Children[c] = new TrieNode();
                node = node.Children[c];
            }
            node.IsEndOfWord = true;
        }

        // Search for a whole word in the trie
        public bool Search(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                    return false;
                node = node.Children[c];
            }
            return node.IsEndOfWord;
        }

        // Search for a prefix in the trie
        public bool StartsWith(string prefix)
        {
            TrieNode node = root;
            foreach (char c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                    return false;
                node = node.Children[c];
            }
            return true;
        }
    }
    /*
     * example of use
        Trie trie = new Trie();
        trie.Insert("apple");
        Console.WriteLine(trie.Search("apple"));   // true
        Console.WriteLine(trie.Search("app"));     // false
        Console.WriteLine(trie.StartsWith("app")); // true
        trie.Insert("app");
        Console.WriteLine(trie.Search("app"));     // true
     */

}
