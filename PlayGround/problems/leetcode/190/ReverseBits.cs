using System;
using System.ComponentModel;

namespace problems.leetcode._190
{
    public class ReverseBits : IBaseSolution
    {
        // https://leetcode.com/problems/reverse-bits/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            uint big = 0b00000010100101000001111010011100;
            Console.WriteLine("n = 00000010100101000001111010011100, Expected : 964176192 (00111001011110000010100101000000)");
            Console.WriteLine("Actual: " + solution.reverseBits(big));
        }

        public class Solution
        {
            public uint reverseBits(uint n)
            {
                uint result = 0;

                for (int i = 0; i < 32; i++)
                {
                    result <<= 1;          // shift result left
                    result |= (n & 1);     // copy the last bit of n into result
                    n >>= 1;               // shift n right
                }

                return result;
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("Reverse bits of a given 32 bits unsigned integer.\r\n\r\nNote:\r\n\r\nNote that in some languages, such as Java, there is no unsigned integer type. In this case, both input and output will be given as a signed integer type. They should not affect your implementation, as the integer's internal binary representation is the same, whether it is signed or unsigned.\r\nIn Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 2 above, the input represents the signed integer -3 and the output represents the signed integer -1073741825.\r\n \r\n\r\nExample 1:\r\n\r\nInput: n = 00000010100101000001111010011100\r\nOutput:    964176192 (00111001011110000010100101000000)\r\nExplanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596, so return 964176192 which its binary representation is 00111001011110000010100101000000.\r\nExample 2:\r\n\r\nInput: n = 11111111111111111111111111111101\r\nOutput:   3221225471 (10111111111111111111111111111111)\r\nExplanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293, so return 3221225471 which its binary representation is 10111111111111111111111111111111.\r\n \r\n\r\nConstraints:\r\n\r\nThe input must be a binary string of length 32\r\n \r\n\r\nFollow up: If this function is called many times, how would you optimize it?");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}