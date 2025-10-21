package org.example.leetcode.problem22;

import java.util.ArrayList;
import java.util.List;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution22 extends BaseSolution {
    public Solution22() {
        this.name = "22. Generate Parentheses";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.BACKTRACKING;
        this.description = "Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.\n"
                + //
                "\n" + //
                " \n" + //
                "\n" + //
                "Example 1:\n" + //
                "\n" + //
                "Input: n = 3\n" + //
                "Output: [\"((()))\",\"(()())\",\"(())()\",\"()(())\",\"()()()\"]\n" + //
                "Example 2:\n" + //
                "\n" + //
                "Input: n = 1\n" + //
                "Output: [\"()\"]\n" + //
                " \n" + //
                "\n" + //
                "Constraints:\n" + //
                "\n" + //
                "1 <= n <= 8";
        this.leetcodeurl = "https://leetcode.com/problems/generate-parentheses/";
    }

    class Solution {
        List<String> res = new ArrayList<>();

        public void backtrack(int openN, int closedN, int n, String cur) {
            if (openN == n && closedN == n) {
                res.add(cur);
                return;
            }

            if (openN < n) {
                backtrack(openN + 1, closedN, n, cur + "(");
            }

            if (closedN < openN) {
                backtrack(openN, closedN + 1, n, cur + ")");
            }
        }

        public List<String> generateParenthesis(int n) {
            backtrack(0, 0, n, "");
            return res;
        }
    }

    @Override
    public void solve() {
        if (!isGuiRun) {
            Utils.getInstance().printProblem(description, difficulty, topic);
        }
        Solution solution = new Solution();
        System.out.println("Expected : [\"((()))\",\"(()())\",\"(())()\",\"()(())\",\"()()()\"]");
        System.out.println("Actual:" + Utils.printForConsole(solution.generateParenthesis(3)));
    }

}
