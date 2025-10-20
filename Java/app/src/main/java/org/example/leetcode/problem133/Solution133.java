package org.example.leetcode.problem133;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution133 extends BaseSolution {
    public Solution133() {
        this.name = "133. Clone Graph";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.GRAPHS;
        this.description = "Problem: Given a reference of a node in a connected undirected graph.\r\n\r\nReturn a deep copy (clone) of the graph.\r\n\r\nEach node in the graph contains a value (int) and a list (List[Node]) of its neighbors.\r\n\r\nclass Node {\r\n    public int val;\r\n    public List<Node> neighbors;\r\n}\r\n \r\n\r\nTest case format:\r\n\r\nFor simplicity, each node's value is the same as the node's index (1-indexed). For example, the first node with val == 1, the second node with val == 2, and so on. The graph is represented in the test case using an adjacency list.\r\n\r\nAn adjacency list is a collection of unordered lists used to represent a finite graph. Each list describes the set of neighbors of a node in the graph.\r\n\r\nThe given node will always be the first node with val = 1. You must return the copy of the given node as a reference to the cloned graph.";
        // https://leetcode.com/problems/clone-graph/
    }

    @Override
    public void solve() {

    }

}
