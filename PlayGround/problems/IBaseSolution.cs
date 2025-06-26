public interface IBaseSolution
{

    public void solve();

    void printSource();
    public string solve(int val)
    {
        throw new NotImplementedException();
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    enum Topic
    {
        Arrays,
        Binary,
        DynamicProgramming,
        Graphs,
        Interval,
        LinkedList,
        Matrix,
        String,
        Tree,
        Heap
    }
}