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
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("k = 5 ,Expected : b");
        System.out.println("Actual: " + solution.kthCharacter(5));
        System.out.println("Explanation:");
        System.out.println("The function computes the k-th character based on the following logic:");
        System.out.println("1. Subtract 1 from the input k to get (k - 1).");
        System.out.println("2. Convert (k - 1) into its binary representation.");
        System.out.println("3. Count the number of 1s in that binary number.");
        System.out.println("4. Starting from the character 'a', move forward by that count.");
        System.out.println("5. The resulting character is returned as the answer.");
        System.out.println("This effectively maps each k to a letter based on the number of bits set to 1 in (k - 1).");
    }

    public class Solution {
        public char kthCharacter(int k) {
            return (char) ('a' + countBits(k - 1));
        }

        private int countBits(int n) {
            int count = 0;
            while (n != 0) {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
    }

}
