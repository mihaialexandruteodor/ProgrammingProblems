namespace problems.leetcode._168
{
    public class ExcelSheetColumnTitle : IBaseSolution
    {

        public void solve()
        {
            Console.WriteLine(ConvertToTitle(52));
        }

        public string solve(int val)
        {
            return ConvertToTitle(val);
        }

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