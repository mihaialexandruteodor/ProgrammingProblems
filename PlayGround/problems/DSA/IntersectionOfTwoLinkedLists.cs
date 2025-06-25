using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IBaseSolution;

namespace PlayGround.problems.DSA
{
    // https://leetcode.com/explore/learn/card/linked-list/214/two-pointer-technique/1215/

    /*
      After switching heads, both pointers traverse equal total length:
        pointerA: A -> B
        pointerB: B -> A
        If lists intersect, they meet at the intersection node.

        If not, both pointers reach null at the same time.
     */
    public class IntersectionOfTwoLinkedLists : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.LinkedList;
        public static readonly string description = "";

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            // to do
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public class Solution
        {
            public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {
                if (headA == null || headB == null) return null;

                ListNode pointerA = headA;
                ListNode pointerB = headB;

                // Traverse until they meet or both are null
                while (pointerA != pointerB)
                {
                    pointerA = (pointerA != null) ? pointerA.next : headB;
                    pointerB = (pointerB != null) ? pointerB.next : headA;
                }

                // Either intersection node or null
                return pointerA;
            }
        }
    }
}
