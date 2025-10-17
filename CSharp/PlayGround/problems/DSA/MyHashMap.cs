using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.problems.DSA
{
    //https://leetcode.com/explore/learn/card/hash-table/182/practical-applications/1140/
    internal class MyHashMap
    {
        private const int SIZE = 1000;
        private List<(int key, int value)>[] buckets;

        public MyHashMap()
        {
            buckets = new List<(int, int)>[SIZE];
        }

        private int Hash(int key)
        {
            return key % SIZE;
        }

        public void Put(int key, int value)
        {
            int index = Hash(key);
            if (buckets[index] == null)
                buckets[index] = new List<(int, int)>();

            // Check if the key already exists
            for (int i = 0; i < buckets[index].Count; i++)
            {
                if (buckets[index][i].key == key)
                {
                    buckets[index][i] = (key, value); // Update
                    return;
                }
            }

            buckets[index].Add((key, value)); // Insert
        }

        public int Get(int key)
        {
            int index = Hash(key);
            if (buckets[index] == null)
                return -1;

            foreach (var pair in buckets[index])
            {
                if (pair.key == key)
                    return pair.value;
            }

            return -1;
        }

        public void Remove(int key)
        {
            int index = Hash(key);
            if (buckets[index] == null)
                return;

            // Remove the key-value pair if it exists
            for (int i = 0; i < buckets[index].Count; i++)
            {
                if (buckets[index][i].key == key)
                {
                    buckets[index].RemoveAt(i);
                    return;
                }
            }
        }
    }
}
