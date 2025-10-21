package org.example.leetcode.problem5;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution5 extends BaseSolution {
    public Solution5() {
        this.name = "5. Longest Palindromic Substring";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Given a string s, return the longest palindromic substring in s.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"babad\"\r\nOutput: \"bab\"\r\nExplanation: \"aba\" is also a valid answer.\r\nExample 2:\r\n\r\nInput: s = \"cbbd\"\r\nOutput: \"bb\"\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 1000\r\ns consist of only digits and English letters.";
        // https://leetcode.com/problems/longest-palindromic-substring/

    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("\"babad\", Expected : bab or aba");
        System.out.println("Actual: " + solution.longestPalindrome("babad"));
    }

    public class Solution {

        public boolean checkPal(String str) {
            char[] arr = str.toCharArray();
            for (int i = 0, j = arr.length - 1; i < j; i++, j--) {
                if (arr[i] != arr[j])
                    return false;
            }
            return true;
        }

        public String longestPalindrome(String s) {
            if (s.length() == 1)
                return s;

            int maxLenPal = 0;
            String maxPal = "";

            for (int st = 0; st < s.length() - 1; st++) {
                for (int ed = s.length() - 1; ed > st; ed--) {
                    if (s.charAt(st) == s.charAt(ed)) {
                        String substr = s.substring(st, ed + 1);
                        if (checkPal(substr)) {
                            if (substr.length() > maxLenPal) {
                                maxPal = substr;
                                maxLenPal = substr.length();
                            }
                        }
                    }
                }
            }

            if (s.length() > 1 && maxLenPal == 0)
                return s.substring(0, 1);

            return maxPal;
        }
    }

}
