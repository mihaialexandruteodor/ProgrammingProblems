namespace problems.leetcode._20
{
    public class ValidParentheses : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("Problem: Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.\r\n\r\nAn input string is valid if:\r\n\r\nOpen brackets must be closed by the same type of brackets.\r\nOpen brackets must be closed in the correct order.\r\nEvery close bracket has a corresponding open bracket of the same type.\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"()\"\r\n\r\nOutput: true\r\n\r\nExample 2:\r\n\r\nInput: s = \"()[]{}\"\r\n\r\nOutput: true\r\n\r\nExample 3:\r\n\r\nInput: s = \"(]\"\r\n\r\nOutput: false\r\n\r\nExample 4:\r\n\r\nInput: s = \"([])\"\r\n\r\nOutput: true\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 104\r\ns consists of parentheses only '()[]{}'.");
            Console.WriteLine();
        }

        // https://leetcode.com/problems/valid-parentheses/
        // STACK PROBLEM
        public void solve()
        {
            printProblem();
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