namespace problems.leetcode._207
{
    public class CourseSchedule : IBaseSolution
    {

        public void solve()
        {
            int[][] prereq = [[0, 1]];
            Console.WriteLine(CanFinish(2, prereq));
        }

        public class MultiDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
        {
            public void Add(TKey key, TValue value)
            {
                if (TryGetValue(key, out List<TValue> valueList))
                {
                    valueList.Add(value);
                }
                else
                {
                    Add(key, new List<TValue> { value });
                }
            }

            public void Remove(TKey key, TValue value)
            {
                if (TryGetValue(key, out List<TValue> valueList))
                    valueList.Remove(value);
            }

            public void SetEmptyVal(TKey key)
            {
                if (TryGetValue(key, out List<TValue> valueList))
                    valueList.Clear();
            }

            public bool Contains(TKey key)
            {
                return TryGetValue(key, out List<TValue> valueList);
            }
        }

        public bool DFS(MultiDictionary<int, int> prereqMap, HashSet<int> visited, int currentCourse)
        {
            if (visited.Contains(currentCourse))
                return false;

            if (prereqMap.Contains(currentCourse) == false || prereqMap[currentCourse].Count == 0)
                return true;

            visited.Add(currentCourse);

            foreach (int preReq in prereqMap[currentCourse])
                if (DFS(prereqMap, visited, preReq) == false)
                    return false;

            visited.Remove(currentCourse);
            prereqMap.SetEmptyVal(currentCourse);
            return true;
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            HashSet<int> visited = new HashSet<int>();
            MultiDictionary<int, int> prereqMap = new MultiDictionary<int, int>();

            foreach (int[] prereq in prerequisites)
                prereqMap.Add(prereq[0], prereq[1]);

            for (int crs = 0; crs < numCourses; ++crs)
                if (DFS(prereqMap, visited, crs) == false)
                    return false;

            return true;

        }
    }
}