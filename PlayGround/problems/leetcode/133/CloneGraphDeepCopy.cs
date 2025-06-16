using System;
using System.Collections.Generic;

namespace problems.leetcode._133
{
    public class CloneGraphDeepCopy : IBaseSolution
    {
        //https://leetcode.com/problems/clone-graph/
        //O(n), n = edges + vertices
        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public void solve()
        {
            printProblem();
            int[][] edges = [[2, 4], [1, 3], [2, 4], [1, 3]];
            /*to do - solver*/
        }
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;

            Dictionary<Node, Node> nodes = new();

            Node dfsCopy(Node node)
            {
                if (nodes.ContainsKey(node))
                {
                    return nodes[node];
                }

                Node copy = new Node(node.val);
                nodes.Add(node, copy);
                foreach (Node neighbor in node.neighbors)
                {
                    copy.neighbors.Add(dfsCopy(neighbor));
                }

                return copy;
            }

            return dfsCopy(node);
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: Given a reference of a node in a connected undirected graph.\r\n\r\nReturn a deep copy (clone) of the graph.\r\n\r\nEach node in the graph contains a value (int) and a list (List[Node]) of its neighbors.\r\n\r\nclass Node {\r\n    public int val;\r\n    public List<Node> neighbors;\r\n}\r\n \r\n\r\nTest case format:\r\n\r\nFor simplicity, each node's value is the same as the node's index (1-indexed). For example, the first node with val == 1, the second node with val == 2, and so on. The graph is represented in the test case using an adjacency list.\r\n\r\nAn adjacency list is a collection of unordered lists used to represent a finite graph. Each list describes the set of neighbors of a node in the graph.\r\n\r\nThe given node will always be the first node with val = 1. You must return the copy of the given node as a reference to the cloned graph.");
            Console.WriteLine();
        }
    }
}