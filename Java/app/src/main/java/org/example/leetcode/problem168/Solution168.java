package org.example.leetcode.problem168;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution168 extends BaseSolution {
    public Solution168() {
        this.name = "168. Excel Sheet Column Title";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Problem: Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.\r\n\r\nFor example:\r\n\r\nA -> 1\r\nB -> 2\r\nC -> 3\r\n...\r\nZ -> 26\r\nAA -> 27\r\nAB -> 28 \r\n...\r\n \r\n\r\nExample 1:\r\n\r\nInput: columnNumber = 1\r\nOutput: \"A\"\r\nExample 2:\r\n\r\nInput: columnNumber = 28\r\nOutput: \"AB\"\r\nExample 3:\r\n\r\nInput: columnNumber = 701\r\nOutput: \"ZY\"\r\n \r\n\r\nConstraints:\r\n\r\n1 <= columnNumber <= 231 - 1";
        // https://leetcode.com/problems/excel-sheet-column-title/
    }

    @Override
    public void solve() {

    }

}
