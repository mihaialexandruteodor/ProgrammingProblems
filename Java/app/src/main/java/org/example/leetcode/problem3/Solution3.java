package org.example.leetcode.problem3;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution3 extends BaseSolution {
    public Solution3() {
        this.name = "3. Longest Substring Without Repeating Characters";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "Given a string s, find the length of the longest substring without duplicate characters.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"abcabcbb\"\r\nOutput: 3\r\nExplanation: The answer is \"abc\", with the length of 3.\r\nExample 2:\r\n\r\nInput: s = \"bbbbb\"\r\nOutput: 1\r\nExplanation: The answer is \"b\", with the length of 1.\r\nExample 3:\r\n\r\nInput: s = \"pwwkew\"\r\nOutput: 3\r\nExplanation: The answer is \"wke\", with the length of 3.\r\nNotice that the answer must be a substring, \"pwke\" is a subsequence and not a substring.\r\n \r\n\r\nConstraints:\r\n\r\n0 <= s.length <= 5 * 104\r\ns consists of English letters, digits, symbols and spaces.";
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/

    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("\"abcabcbb\", Expected : 3");
        System.out.println("Actual: " + solution.lengthOfLongestSubstring("abcabcbb"));
    }

    public class Solution {

        public int lengthOfLongestSubstringSubfunction(String s) {
            int maxLen = 0;

            for (int i = 0; i < s.length(); i++) {
                for (int j = i + 1; j <= s.length(); j++) {
                    String substr = s.substring(i, j);
                    if (isUnique(substr)) {
                        if (substr.length() > maxLen)
                            maxLen = substr.length();
                    }
                }
            }

            return maxLen;
        }

        private boolean isUnique(String s) {
            java.util.HashSet<Character> chars = new java.util.HashSet<>();
            for (char c : s.toCharArray()) {
                if (!chars.add(c))
                    return false;
            }
            return true;
        }

        private boolean checkIfStringContainsNewLineCharacters(String str) {
            if (str.isEmpty())
                return false;

            if (str.contains(" "))
                return true;

            try (java.io.BufferedReader reader = new java.io.BufferedReader(new java.io.StringReader(str))) {
                reader.readLine();
                return reader.read() != -1;
            } catch (Exception e) {
                return false;
            }
        }

        public int lengthOfLongestSubstring(String s) {
            if (s.isEmpty())
                return 0;

            if (s.trim().isEmpty())
                return 1;

            int maxLen = 0;

            if (checkIfStringContainsNewLineCharacters(s)) {
                String[] linesArray = null;
                boolean whiteSpaceSeparator = false;

                if (s.contains("\\r?\\n|\\r")) {
                    linesArray = java.util.regex.Pattern.compile("\\r?\\n|\\r").split(s);
                } else if (s.contains(" ")) {
                    linesArray = s.split(" ");
                    whiteSpaceSeparator = true;
                }

                java.util.HashSet<String> lines = new java.util.HashSet<>(java.util.Arrays.asList(linesArray));

                for (String line : lines) {
                    int len = lengthOfLongestSubstringSubfunction(line);
                    if (len > maxLen) {
                        maxLen = len;
                        if (whiteSpaceSeparator)
                            maxLen++; // +1 on account of the whitespace separator
                    }
                }

                return maxLen;
            }

            return lengthOfLongestSubstringSubfunction(s);
        }
    }

}
