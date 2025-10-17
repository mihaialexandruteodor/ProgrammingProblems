using static IBaseSolution;

namespace problems.leetcode._168
{
    public class ExcelSheetColumnTitle : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.String;
        public static readonly string description = "Problem: Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.\r\n\r\nFor example:\r\n\r\nA -> 1\r\nB -> 2\r\nC -> 3\r\n...\r\nZ -> 26\r\nAA -> 27\r\nAB -> 28 \r\n...\r\n \r\n\r\nExample 1:\r\n\r\nInput: columnNumber = 1\r\nOutput: \"A\"\r\nExample 2:\r\n\r\nInput: columnNumber = 28\r\nOutput: \"AB\"\r\nExample 3:\r\n\r\nInput: columnNumber = 701\r\nOutput: \"ZY\"\r\n \r\n\r\nConstraints:\r\n\r\n1 <= columnNumber <= 231 - 1";
        // https://leetcode.com/problems/excel-sheet-column-title/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("Expected : AZ");
            Console.WriteLine("Actual: " + solution.ConvertToTitle(52));
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
        public class Solution
        {
            public string ConvertToTitle(int columnNumber)
            {
                string res = "";
                bool remainder = false;

                while (columnNumber > 0)
                {
                    int currDigitBase26 = (columnNumber % 26) - 1;
                    columnNumber /= 26;

                    if (currDigitBase26 == -1)
                    {
                        currDigitBase26 = 25;
                        columnNumber--;
                    }

                    char currentChar = (char)('A' + currDigitBase26);
                    res = currentChar + res;

                }

                return res;
            }
        }
    }
}