package org.example.leetcode.problem3;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution3 extends BaseSolution {
    public Solution3() {
        this.name = "3. Longest Substring Without Repeating Characters";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Given a string s, find the length of the longest substring without duplicate characters.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"abcabcbb\"\r\nOutput: 3\r\nExplanation: The answer is \"abc\", with the length of 3.\r\nExample 2:\r\n\r\nInput: s = \"bbbbb\"\r\nOutput: 1\r\nExplanation: The answer is \"b\", with the length of 1.\r\nExample 3:\r\n\r\nInput: s = \"pwwkew\"\r\nOutput: 3\r\nExplanation: The answer is \"wke\", with the length of 3.\r\nNotice that the answer must be a substring, \"pwke\" is a subsequence and not a substring.\r\n \r\n\r\nConstraints:\r\n\r\n0 <= s.length <= 5 * 104\r\ns consists of English letters, digits, symbols and spaces.";
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/

    }

    @Override
    public void solve() {

    }

}
