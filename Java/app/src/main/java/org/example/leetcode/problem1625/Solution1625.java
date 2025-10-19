package org.example.leetcode.problem1625;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Set;

public class Solution1625 {

    // BRUTE FORCE + VISITED SET
    // https://leetcode.com/problems/lexicographically-smallest-string-after-applying-operations/description/

    public static String findLexSmallestString(String s, int a, int b) {
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

    public static void runProblem() {
        System.out.println("Expected: 2050");
        System.out.println("Actual: " + findLexSmallestString("5525", 9, 2));
    }
}
