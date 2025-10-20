package org.example.leetcode.problem3304;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution3304 extends BaseSolution {
    public Solution3304() {
        this.name = "3304. Find the K-th Character in String Game I";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.BINARY;
        this.description = "Alice and Bob are playing a game. Initially, Alice has a string word = \"a\".\r\n\r\nYou are given a positive integer k.\r\n\r\nNow Bob will ask Alice to perform the following operation forever:\r\n\r\nGenerate a new string by changing each character in word to its next character in the English alphabet, and append it to the original word.\r\nFor example, performing the operation on \"c\" generates \"cd\" and performing the operation on \"zb\" generates \"zbac\".\r\n\r\nReturn the value of the kth character in word, after enough operations have been done for word to have at least k characters.\r\n\r\nNote that the character 'z' can be changed to 'a' in the operation.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: k = 5\r\n\r\nOutput: \"b\"\r\n\r\nExplanation:\r\n\r\nInitially, word = \"a\". We need to do the operation three times:\r\n\r\nGenerated string is \"b\", word becomes \"ab\".\r\nGenerated string is \"bc\", word becomes \"abbc\".\r\nGenerated string is \"bccd\", word becomes \"abbcbccd\".\r\nExample 2:\r\n\r\nInput: k = 10\r\n\r\nOutput: \"c\"\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= k <= 500";
        // https://leetcode.com/problems/find-the-k-th-character-in-string-game-i/
    }

    @Override
    public void solve() {

    }

}
