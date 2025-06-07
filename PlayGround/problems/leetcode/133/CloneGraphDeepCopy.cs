using System;
using System.Collections.Generic;

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

    public void solve() {
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
            foreach (Node neighbor in node.neighbors) { 
                copy.neighbors.Add(dfsCopy(neighbor));
            }

            return copy;
        }

        return dfsCopy(node);
    }
}