using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.problems.DSA
{
    //https://leetcode.com/explore/learn/card/hash-table/182/practical-applications/1139/
    internal class MyHashSet
    {
        private bool[] values;
        private const int SIZE = 1000001; // As keys are in range [0, 10^6]

        public MyHashSet()
        {
            values = new bool[SIZE];
        }

        public void Add(int key)
        {
            if (key >= 0 && key < SIZE)
            {
                values[key] = true;
            }
        }

        public void Remove(int key)
        {
            if (key >= 0 && key < SIZE)
            {
                values[key] = false;
            }
        }

        public bool Contains(int key)
        {
            if (key >= 0 && key < SIZE)
            {
                return values[key];
            }
            return false;
        }
    }
}
