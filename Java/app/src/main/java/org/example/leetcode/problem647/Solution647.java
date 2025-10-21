package org.example.leetcode.problem647;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution647 extends BaseSolution {
    public Solution647() {
        this.name = "647. Palindromic Substrings";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Problem: Given a string s, return the number of palindromic substrings in it.\r\n\r\nA string is a palindrome when it reads the same backward as forward.\r\n\r\nA substring is a contiguous sequence of characters within the string.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"abc\"\r\nOutput: 3\r\nExplanation: Three palindromic strings: \"a\", \"b\", \"c\".\r\nExample 2:\r\n\r\nInput: s = \"aaa\"\r\nOutput: 6\r\nExplanation: Six palindromic strings: \"a\", \"a\", \"a\", \"aa\", \"aa\", \"aaa\".\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 1000\r\ns consists of lowercase English letters.";
        this.leetcodeurl = "https://leetcode.com/problems/palindromic-substrings/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        System.out.println("\"abc\", expect 3, actual: " + solution.countSubstrings("abc"));
        System.out.println("\"aaa\", expect 6, actual: " + solution.countSubstrings("aaa"));
    }

    public class Solution {
        public int countSubstrings(String s) {
            int res = 0;
            int n = s.length();

            for (int i = 0; i < n; i++) {
                // Odd-length palindromes
                int l = i, r = i;
                while (l >= 0 && r < n && s.charAt(l) == s.charAt(r)) {
                    res++;
                    l--;
                    r++;
                }

                // Even-length palindromes
                l = i;
                r = i + 1;
                while (l >= 0 && r < n && s.charAt(l) == s.charAt(r)) {
                    res++;
                    l--;
                    r++;
                }
            }

            return res;
        }
    }

}
