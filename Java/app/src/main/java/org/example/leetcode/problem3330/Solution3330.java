package org.example.leetcode.problem3330;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution3330 extends BaseSolution {
    public Solution3330() {
        this.name = "3330. Find the Original Typed String I";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Alice is attempting to type a specific string on her computer. However, she tends to be clumsy and may press a key for too long, resulting in a character being typed multiple times.\r\n\r\nAlthough Alice tried to focus on her typing, she is aware that she may still have done this at most once.\r\n\r\nYou are given a string word, which represents the final output displayed on Alice's screen.\r\n\r\nReturn the total number of possible original strings that Alice might have intended to type.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: word = \"abbcccc\"\r\n\r\nOutput: 5\r\n\r\nExplanation:\r\n\r\nThe possible strings are: \"abbcccc\", \"abbccc\", \"abbcc\", \"abbc\", and \"abcccc\".\r\n\r\nExample 2:\r\n\r\nInput: word = \"abcd\"\r\n\r\nOutput: 1\r\n\r\nExplanation:\r\n\r\nThe only possible string is \"abcd\".\r\n\r\nExample 3:\r\n\r\nInput: word = \"aaaa\"\r\n\r\nOutput: 4\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= word.length <= 100\r\nword consists only of lowercase English letters.";
        // https://leetcode.com/problems/find-the-original-typed-string-i/
    }

    @Override
    public void solve() {

    }

}
