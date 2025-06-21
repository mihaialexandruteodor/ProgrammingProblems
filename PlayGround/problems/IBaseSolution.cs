public interface IBaseSolution {

    public void printProblem();
    public void solve();

    void printSource();
    public string solve(int val)
    {
        throw new NotImplementedException();
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