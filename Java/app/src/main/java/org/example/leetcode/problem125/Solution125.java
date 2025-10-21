package org.example.leetcode.problem125;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution125 extends BaseSolution {
    public Solution125() {
        this.name = "125. Valid Palindrome";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.STRINGS;
        this.description = "A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.\r\n\r\nGiven a string s, return true if it is a palindrome, or false otherwise.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"A man, a plan, a canal: Panama\"\r\nOutput: true\r\nExplanation: \"amanaplanacanalpanama\" is a palindrome.\r\nExample 2:\r\n\r\nInput: s = \"race a car\"\r\nOutput: false\r\nExplanation: \"raceacar\" is not a palindrome.\r\nExample 3:\r\n\r\nInput: s = \" \"\r\nOutput: true\r\nExplanation: s is an empty string \"\" after removing non-alphanumeric characters.\r\nSince an empty string reads the same forward and backward, it is a palindrome.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 2 * 105\r\ns consists only of printable ASCII characters.";
        // https://leetcode.com/problems/valid-palindrome/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("\"A man, a plan, a canal: Panama\", Expected : True");
        System.out.println("Actual: " + solution.isPalindrome("A man, a plan, a canal: Panama"));
    }

    public class Solution {
        public boolean isPalindrome(String s) {
            int l = 0, r = s.length() - 1;

            while (l < r) {
                while (l < r && !Character.isLetterOrDigit(s.charAt(l)))
                    l++;
                while (l < r && !Character.isLetterOrDigit(s.charAt(r)))
                    r--;

                if (Character.toLowerCase(s.charAt(l)) != Character.toLowerCase(s.charAt(r)))
                    return false;

                l++;
                r--;
            }

            return true;
        }
    }

}
