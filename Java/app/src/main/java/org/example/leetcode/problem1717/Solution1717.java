package org.example.leetcode.problem1717;

import java.util.ArrayDeque;
import java.util.Deque;

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
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("s = \"cdbcbbaaabab\", x = 4, y = 5 ,Expected : 19");
        System.out.println("Actual: " + solution.maximumGain("cdbcbbaaabab", 4, 5));
    }

    public class Solution {
        public int maximumGain(String s, int x, int y) {
            if (x < y) {
                // Always handle the higher point first
                int temp = x;
                x = y;
                y = temp;
                s = reversePairs(s); // Transform "ab" <=> "ba"
            }

            int score = 0;
            Deque<Character> stack = new ArrayDeque<>();

            // First pass: remove "ab" and gain x points
            for (char c : s.toCharArray()) {
                if (!stack.isEmpty() && stack.peek() == 'a' && c == 'b') {
                    stack.pop();
                    score += x;
                } else {
                    stack.push(c);
                }
            }

            // Reconstruct string for second pass
            Deque<Character> tempStack = new ArrayDeque<>();
            while (!stack.isEmpty()) {
                tempStack.push(stack.pop());
            }
            stack.clear();

            // Second pass: remove "ba" and gain y points
            for (char c : tempStack) {
                if (!stack.isEmpty() && stack.peek() == 'b' && c == 'a') {
                    stack.pop();
                    score += y;
                } else {
                    stack.push(c);
                }
            }

            return score;
        }

        private String reversePairs(String s) {
            StringBuilder sb = new StringBuilder();
            for (char c : s.toCharArray()) {
                if (c == 'a')
                    sb.append('b');
                else if (c == 'b')
                    sb.append('a');
                else
                    sb.append(c);
            }
            return sb.toString();
        }
    }

}
