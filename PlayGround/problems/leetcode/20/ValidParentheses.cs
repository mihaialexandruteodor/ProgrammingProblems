namespace problems.leetcode._20
{
    public class ValidParentheses : IBaseSolution
    {
        // https://leetcode.com/problems/valid-parentheses/
        // STACK PROBLEM
        public void solve()
        {
            Solution solution = new Solution();
            Console.WriteLine("() , Expected : True");
            Console.WriteLine("Actual: " + solution.IsValid("()"));
            Console.WriteLine("()[]{} , Expected : True");
            Console.WriteLine("Actual: " + solution.IsValid("()[]{}"));
            Console.WriteLine("(] , Expected : False");
            Console.WriteLine("Actual: " + solution.IsValid("(]"));
            Console.WriteLine("([]) , Expected : True");
            Console.WriteLine("Actual: " + solution.IsValid("([])"));
        }

        public class Solution
        {
            public bool IsValid(string s)
            {

                Dictionary<char, char> closedOpen = new();
                closedOpen.Add(')', '(');
                closedOpen.Add(']', '[');
                closedOpen.Add('}', '{');
                Stack<char> st = new();
                foreach (char ch in s)
                {
                    if (ch == ')' || ch == ']' || ch == '}')
                    {
                        if (st.Count > 0 && closedOpen[ch] == st.Peek())
                            st.Pop();
                        else
                            return false;
                    }
                    else
                    {
                        st.Push(ch);
                    }
                }
                return st.Count == 0 ? true : false;
            }
        }
    }
}