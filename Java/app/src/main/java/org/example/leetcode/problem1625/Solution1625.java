package org.example.leetcode.problem1625;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Set;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution1625 extends BaseSolution {
    public Solution1625() {
        this.name = "1625. Lexicographically Smallest String After Applying Operations";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.STRINGS;
        this.description = "You are given a string s of even length consisting of digits from 0 to 9, and two integers a and b.\n"
                + //
                "\n" + //
                "You can apply either of the following two operations any number of times and in any order on s:\n" + //
                "\n" + //
                "Add a to all odd indices of s (0-indexed). Digits post 9 are cycled back to 0. For example, if s = \"3456\" and a = 5, s becomes \"3951\".\n"
                + //
                "Rotate s to the right by b positions. For example, if s = \"3456\" and b = 1, s becomes \"6345\".\n" + //
                "Return the lexicographically smallest string you can obtain by applying the above operations any number of times on s.\n"
                + //
                "\n" + //
                "A string a is lexicographically smaller than a string b (of the same length) if in the first position where a and b differ, string a has a letter that appears earlier in the alphabet than the corresponding letter in b. For example, \"0158\" is lexicographically smaller than \"0190\" because the first position they differ is at the third letter, and '5' comes before '9'.\n"
                + //
                "\n" + //
                " \n" + //
                "\n" + //
                "Example 1:\n" + //
                "\n" + //
                "Input: s = \"5525\", a = 9, b = 2\n" + //
                "Output: \"2050\"\n" + //
                "Explanation: We can apply the following operations:\n" + //
                "Start:  \"5525\"\n" + //
                "Rotate: \"2555\"\n" + //
                "Add:    \"2454\"\n" + //
                "Add:    \"2353\"\n" + //
                "Rotate: \"5323\"\n" + //
                "Add:    \"5222\"\n" + //
                "Add:    \"5121\"\n" + //
                "Rotate: \"2151\"\n" + //
                "Add:    \"2050\"​​​​​\n" + //
                "There is no way to obtain a string that is lexicographically smaller than \"2050\".\n" + //
                "Example 2:\n" + //
                "\n" + //
                "Input: s = \"74\", a = 5, b = 1\n" + //
                "Output: \"24\"\n" + //
                "Explanation: We can apply the following operations:\n" + //
                "Start:  \"74\"\n" + //
                "Rotate: \"47\"\n" + //
                "​​​​​​​Add:    \"42\"\n" + //
                "​​​​​​​Rotate: \"24\"​​​​​​​​​​​​\n" + //
                "There is no way to obtain a string that is lexicographically smaller than \"24\".\n" + //
                "Example 3:\n" + //
                "\n" + //
                "Input: s = \"0011\", a = 4, b = 2\n" + //
                "Output: \"0011\"\n" + //
                "Explanation: There are no sequence of operations that will give us a lexicographically smaller string than \"0011\".\n"
                + //
                " \n" + //
                "\n" + //
                "Constraints:\n" + //
                "\n" + //
                "2 <= s.length <= 100\n" + //
                "s.length is even.\n" + //
                "s consists of digits from 0 to 9 only.\n" + //
                "1 <= a <= 9\n" + //
                "1 <= b <= s.length - 1";
    }

    public class Solution {
        // BRUTE FORCE + VISITED SET
        // https://leetcode.com/problems/lexicographically-smallest-string-after-applying-operations/description/

        public String findLexSmallestString(String s, int a, int b) {
            Queue<String> q = new LinkedList<>();
            Set<String> visited = new HashSet<>();
            String res = s;

            q.offer(s);
            visited.add(s);

            while (!q.isEmpty()) {
                String curr = q.poll();
                if (curr.compareTo(res) < 0) {
                    res = curr;
                }

                // Operation 1: Add
                char[] chars = curr.toCharArray();
                for (int i = 1; i < chars.length; i += 2) {
                    chars[i] = (char) (((chars[i] - '0' + a) % 10) + '0');
                }
                String addStr = new String(chars);
                if (visited.add(addStr)) {
                    q.offer(addStr);
                }

                // Operation 2: Rotate
                String rotateStr = curr.substring(curr.length() - b) + curr.substring(0, curr.length() - b);
                if (visited.add(rotateStr)) {
                    q.offer(rotateStr);
                }
            }

            return res;
        }
    }

    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("Expected: 2050");
        System.out.println("Actual: " + solution.findLexSmallestString("5525", 9, 2));
    }
}
