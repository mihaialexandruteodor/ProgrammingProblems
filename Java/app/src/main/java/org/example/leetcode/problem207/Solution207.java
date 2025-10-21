package org.example.leetcode.problem207;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution207 extends BaseSolution {
    public Solution207() {
        this.name = "207. Course Schedule";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.GRAPHS;
        this.description = "Problem: There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.\r\n\r\nFor example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.\r\nReturn true if you can finish all courses. Otherwise, return false.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: numCourses = 2, prerequisites = [[1,0]]\r\nOutput: true\r\nExplanation: There are a total of 2 courses to take. \r\nTo take course 1 you should have finished course 0. So it is possible.\r\nExample 2:\r\n\r\nInput: numCourses = 2, prerequisites = [[1,0],[0,1]]\r\nOutput: false\r\nExplanation: There are a total of 2 courses to take. \r\nTo take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= numCourses <= 2000\r\n0 <= prerequisites.length <= 5000\r\nprerequisites[i].length == 2\r\n0 <= ai, bi < numCourses\r\nAll the pairs prerequisites[i] are unique.";
        // https://leetcode.com/problems/course-schedule/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        int[][] prereq = { { 0, 1 } };
        Solution solution = new Solution();

        System.out.println("Expected : True");
        System.out.println("Actual: " + solution.canFinish(2, prereq));
    }

    public class Solution {

        public static class MultiMap {
            private final Map<Integer, List<Integer>> map = new HashMap<>();

            public void add(int key, int value) {
                map.computeIfAbsent(key, k -> new ArrayList<>()).add(value);
            }

            public void clear(int key) {
                map.getOrDefault(key, new ArrayList<>()).clear();
            }

            public boolean contains(int key) {
                return map.containsKey(key);
            }

            public List<Integer> get(int key) {
                return map.getOrDefault(key, new ArrayList<>());
            }
        }

        private boolean dfs(MultiMap prereqMap, Set<Integer> visited, int course) {
            if (visited.contains(course))
                return false;
            if (!prereqMap.contains(course) || prereqMap.get(course).isEmpty())
                return true;

            visited.add(course);
            for (int pre : prereqMap.get(course)) {
                if (!dfs(prereqMap, visited, pre))
                    return false;
            }
            visited.remove(course);
            prereqMap.clear(course);
            return true;
        }

        public boolean canFinish(int numCourses, int[][] prerequisites) {
            MultiMap prereqMap = new MultiMap();
            for (int[] pair : prerequisites) {
                prereqMap.add(pair[0], pair[1]);
            }

            Set<Integer> visited = new HashSet<>();
            for (int crs = 0; crs < numCourses; crs++) {
                if (!dfs(prereqMap, visited, crs))
                    return false;
            }
            return true;
        }
    }

}
