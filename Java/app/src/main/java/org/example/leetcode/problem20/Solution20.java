package org.example.leetcode.problem20;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution20 extends BaseSolution {
    public Solution20() {
        this.name = "20. Valid Parentheses";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Problem: Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.\r\n\r\nAn input string is valid if:\r\n\r\nOpen brackets must be closed by the same type of brackets.\r\nOpen brackets must be closed in the correct order.\r\nEvery close bracket has a corresponding open bracket of the same type.\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"()\"\r\n\r\nOutput: true\r\n\r\nExample 2:\r\n\r\nInput: s = \"()[]{}\"\r\n\r\nOutput: true\r\n\r\nExample 3:\r\n\r\nInput: s = \"(]\"\r\n\r\nOutput: false\r\n\r\nExample 4:\r\n\r\nInput: s = \"([])\"\r\n\r\nOutput: true\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 104\r\ns consists of parentheses only '()[]{}'.";
        // https://leetcode.com/problems/valid-parentheses/
    }

    @Override
    public void solve() {

    }

}
