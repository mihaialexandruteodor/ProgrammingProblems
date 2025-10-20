package org.example.leetcode.problem1717;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution1717 extends BaseSolution {
    public Solution1717() {
        this.name = "1717. Maximum Score From Removing Substrings";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "You are given a string s and two integers x and y. You can perform two types of operations any number of times.\r\n\r\nRemove substring \"ab\" and gain x points.\r\nFor example, when removing \"ab\" from \"cabxbae\" it becomes \"cxbae\".\r\nRemove substring \"ba\" and gain y points.\r\nFor example, when removing \"ba\" from \"cabxbae\" it becomes \"cabxe\".\r\nReturn the maximum points you can gain after applying the above operations on s.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"cdbcbbaaabab\", x = 4, y = 5\r\nOutput: 19\r\nExplanation:\r\n- Remove the \"ba\" underlined in \"cdbcbbaaabab\". Now, s = \"cdbcbbaaab\" and 5 points are added to the score.\r\n- Remove the \"ab\" underlined in \"cdbcbbaaab\". Now, s = \"cdbcbbaa\" and 4 points are added to the score.\r\n- Remove the \"ba\" underlined in \"cdbcbbaa\". Now, s = \"cdbcba\" and 5 points are added to the score.\r\n- Remove the \"ba\" underlined in \"cdbcba\". Now, s = \"cdbc\" and 5 points are added to the score.\r\nTotal score = 5 + 4 + 5 + 5 = 19.\r\nExample 2:\r\n\r\nInput: s = \"aabbaaxybbaabb\", x = 5, y = 4\r\nOutput: 20\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 105\r\n1 <= x, y <= 104\r\ns consists of lowercase English letters.\r\n";
        // https://leetcode.com/problems/maximum-score-from-removing-substrings/
    }

    @Override
    public void solve() {

    }

}
