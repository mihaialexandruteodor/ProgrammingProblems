package org.example.leetcode.problem49;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution49 extends BaseSolution {
    public Solution49() {
        this.name = "49. Group Anagrams";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Given an array of strings strs, group the anagrams together. You can return the answer in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: strs = [\"eat\",\"tea\",\"tan\",\"ate\",\"nat\",\"bat\"]\r\n\r\nOutput: [[\"bat\"],[\"nat\",\"tan\"],[\"ate\",\"eat\",\"tea\"]]\r\n\r\nExplanation:\r\n\r\nThere is no string in strs that can be rearranged to form \"bat\".\r\nThe strings \"nat\" and \"tan\" are anagrams as they can be rearranged to form each other.\r\nThe strings \"ate\", \"eat\", and \"tea\" are anagrams as they can be rearranged to form each other.\r\nExample 2:\r\n\r\nInput: strs = [\"\"]\r\n\r\nOutput: [[\"\"]]\r\n\r\nExample 3:\r\n\r\nInput: strs = [\"a\"]\r\n\r\nOutput: [[\"a\"]]\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= strs.length <= 104\r\n0 <= strs[i].length <= 100\r\nstrs[i] consists of lowercase English letters.";
        // https://leetcode.com/problems/group-anagrams/
    }

    @Override
    public void solve() {

    }

}
