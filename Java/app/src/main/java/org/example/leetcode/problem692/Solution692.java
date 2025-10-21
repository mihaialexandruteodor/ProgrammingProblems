package org.example.leetcode.problem692;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.PriorityQueue;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution692 extends BaseSolution {
    public Solution692() {
        this.name = "692. Top K Frequent Words";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Given an array of strings words and an integer k, return the k most frequent strings.\r\n\r\nReturn the answer sorted by the frequency from highest to lowest. Sort the words with the same frequency by their lexicographical order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: words = [\"i\",\"love\",\"leetcode\",\"i\",\"love\",\"coding\"], k = 2\r\nOutput: [\"i\",\"love\"]\r\nExplanation: \"i\" and \"love\" are the two most frequent words.\r\nNote that \"i\" comes before \"love\" due to a lower alphabetical order.\r\nExample 2:\r\n\r\nInput: words = [\"the\",\"day\",\"is\",\"sunny\",\"the\",\"the\",\"the\",\"sunny\",\"is\",\"is\"], k = 4\r\nOutput: [\"the\",\"is\",\"sunny\",\"day\"]\r\nExplanation: \"the\", \"is\", \"sunny\" and \"day\" are the four most frequent words, with the number of occurrence being 4, 3, 2 and 1 respectively.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= words.length <= 500\r\n1 <= words[i].length <= 10\r\nwords[i] consists of lowercase English letters.\r\nk is in the range [1, The number of unique words[i]]\r\n \r\n\r\nFollow-up: Could you solve it in O(n log(k)) time and O(n) extra space?";
        // https://leetcode.com/problems/top-k-frequent-words/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        System.out.println("Expected : [i, love, coding]");
        System.out.println("Actual: " + solution.topKFrequent(
                new String[] { "i", "love", "leetcode", "i", "love", "coding" }, 3));
    }

    public class Solution {
        public List<String> topKFrequent(String[] words, int k) {
            Map<String, Integer> freqMap = new HashMap<>();
            for (String word : words)
                freqMap.put(word, freqMap.getOrDefault(word, 0) + 1);

            PriorityQueue<String> pq = new PriorityQueue<>((a, b) -> {
                int freqCompare = freqMap.get(b).compareTo(freqMap.get(a));
                if (freqCompare != 0)
                    return freqCompare;
                return a.compareTo(b);
            });

            pq.addAll(freqMap.keySet());

            List<String> result = new ArrayList<>();
            for (int i = 0; i < k; i++)
                result.add(pq.poll());

            return result;
        }
    }

}
