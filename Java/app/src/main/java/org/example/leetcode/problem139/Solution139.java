package org.example.leetcode.problem139;

import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution139 extends BaseSolution {
    public Solution139() {
        this.name = "139. Word Break";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "Problem: Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.\r\n\r\nNote that the same word in the dictionary may be reused multiple times in the segmentation.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"leetcode\", wordDict = [\"leet\",\"code\"]\r\nOutput: true\r\nExplanation: Return true because \"leetcode\" can be segmented as \"leet code\".\r\nExample 2:\r\n\r\nInput: s = \"applepenapple\", wordDict = [\"apple\",\"pen\"]\r\nOutput: true\r\nExplanation: Return true because \"applepenapple\" can be segmented as \"apple pen apple\".\r\nNote that you are allowed to reuse a dictionary word.\r\nExample 3:\r\n\r\nInput: s = \"catsandog\", wordDict = [\"cats\",\"dog\",\"sand\",\"and\",\"cat\"]\r\nOutput: false";
        // https://leetcode.com/problems/word-break/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("Expected True, got: " + solution.wordBreak("aaaaaaa", Arrays.asList("aaaa", "aaa")));
        System.out.println("Expected True, got: " + solution.wordBreak("leetcode", Arrays.asList("leet", "code")));
        System.out.println("Expected True, got: " + solution.wordBreak("applepenapple", Arrays.asList("apple", "pen")));
        System.out.println("Expected False, got: "
                + solution.wordBreak("catsandog", Arrays.asList("cats", "dog", "sand", "and", "cat")));
    }

    public class Solution {
        public boolean wordBreak(String s, List<String> wordDict) {
            Set<String> wordSet = new HashSet<>(wordDict);
            boolean[] dp = new boolean[s.length() + 1];
            dp[0] = true;

            for (int i = 1; i <= s.length(); i++) {
                for (int j = 0; j < i; j++) {
                    if (dp[j] && wordSet.contains(s.substring(j, i))) {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.length()];
        }
    }

}
