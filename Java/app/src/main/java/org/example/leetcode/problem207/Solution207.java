package org.example.leetcode.problem207;

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

    }

}
