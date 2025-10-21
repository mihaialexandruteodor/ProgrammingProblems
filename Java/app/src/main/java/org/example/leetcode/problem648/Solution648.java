package org.example.leetcode.problem648;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution648 extends BaseSolution {
    public Solution648() {
        this.name = "648. Replace Words";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Problem: In English, we have a concept called root, which can be followed by some other word to form another longer word - let's call this word derivative. For example, when the root \"help\" is followed by the word \"ful\", we can form a derivative \"helpful\".\r\n\r\nGiven a dictionary consisting of many roots and a sentence consisting of words separated by spaces, replace all the derivatives in the sentence with the root forming it. If a derivative can be replaced by more than one root, replace it with the root that has the shortest length.\r\n\r\nReturn the sentence after the replacement.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: dictionary = [\"cat\",\"bat\",\"rat\"], sentence = \"the cattle was rattled by the battery\"\r\nOutput: \"the cat was rat by the bat\"\r\nExample 2:\r\n\r\nInput: dictionary = [\"a\",\"b\",\"c\"], sentence = \"aadsfasf absbs bbab cadsfafs\"\r\nOutput: \"a a b c\"\r\n \r\n\r\nConstraints:\r\n\r\n1 <= dictionary.length <= 1000\r\n1 <= dictionary[i].length <= 100\r\ndictionary[i] consists of only lower-case letters.\r\n1 <= sentence.length <= 106\r\nsentence consists of only lower-case letters and spaces.\r\nThe number of words in sentence is in the range [1, 1000]\r\nThe length of each word in sentence is in the range [1, 1000]\r\nEvery two consecutive words in sentence will be separated by exactly one space.\r\nsentence does not have leading or trailing spaces.";
        // https://leetcode.com/problems/replace-words/description/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        System.out.println("Expected : the cat was rat by the bat");
        System.out.println("Actual: " + solution.replaceWords(
                Arrays.asList("cat", "bat", "rat"),
                "the cattle was rattled by the battery"));
    }

    public class TrieNode {
        public Map<Character, TrieNode> children = new HashMap<>();
        public String word = null;
    }

    public class Solution {
        private TrieNode buildTrie(List<String> dictionary) {
            TrieNode root = new TrieNode();

            for (String word : dictionary) {
                TrieNode node = root;
                for (char c : word.toCharArray()) {
                    node.children.putIfAbsent(c, new TrieNode());
                    node = node.children.get(c);
                }
                node.word = word; // mark the end of a root word
            }

            return root;
        }

        public String replaceWords(List<String> dictionary, String sentence) {
            TrieNode trie = buildTrie(dictionary);
            String[] words = sentence.split(" ");
            List<String> result = new ArrayList<>();

            for (String word : words) {
                TrieNode node = trie;
                String replacement = "";

                for (char c : word.toCharArray()) {
                    if (!node.children.containsKey(c) || node.word != null)
                        break;
                    node = node.children.get(c);
                }

                replacement = node.word != null ? node.word : word;
                result.add(replacement);
            }

            return String.join(" ", result);
        }
    }

}
