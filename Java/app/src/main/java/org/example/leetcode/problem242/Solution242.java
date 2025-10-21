package org.example.leetcode.problem242;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution242 extends BaseSolution {
    public Solution242() {
        this.name = "242. Valid Anagram";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Given two strings s and t, return true if t is an anagram of s, and false otherwise.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"anagram\", t = \"nagaram\"\r\n\r\nOutput: true\r\n\r\nExample 2:\r\n\r\nInput: s = \"rat\", t = \"car\"\r\n\r\nOutput: false\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length, t.length <= 5 * 104\r\ns and t consist of lowercase English letters.\r\n \r\n\r\nFollow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?";
        this.leetcodeurl = "https://leetcode.com/problems/valid-anagram/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        System.out.println("s = \"anagram\", t = \"nagaram\", Expected : True");
        System.out.println("Actual: " + solution.isAnagram("anagram", "nagaram"));
    }

    public class Solution {
        public boolean isAnagram(String s, String t) {
            if (s.length() != t.length())
                return false;

            int[] count = new int[26];
            for (int i = 0; i < s.length(); i++) {
                count[s.charAt(i) - 'a']++;
                count[t.charAt(i) - 'a']--;
            }

            for (int c : count) {
                if (c != 0)
                    return false;
            }
            return true;
        }
    }

}
