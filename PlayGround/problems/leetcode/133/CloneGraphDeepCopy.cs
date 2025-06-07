using System;
using System.Collections.Generic;

public class CloneGraphDeepCopy : IBaseSolution
{
    //https://leetcode.com/problems/clone-graph/
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
        /*int[] nums = new int[] { -1, 1 };
        var res = RearrangeArray(nums);
        foreach (int item in res)
            Console.Write(item + " ");
        Console.WriteLine();*/
    }
    public Node CloneGraph(Node node) {
        

    }
}