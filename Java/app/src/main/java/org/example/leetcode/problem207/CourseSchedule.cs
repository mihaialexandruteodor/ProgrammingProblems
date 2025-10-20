using static IBaseSolution;

namespace problems.leetcode._207
{
    public class CourseSchedule : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Graphs;
        public static readonly string description = "Problem: There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.\r\n\r\nFor example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.\r\nReturn true if you can finish all courses. Otherwise, return false.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: numCourses = 2, prerequisites = [[1,0]]\r\nOutput: true\r\nExplanation: There are a total of 2 courses to take. \r\nTo take course 1 you should have finished course 0. So it is possible.\r\nExample 2:\r\n\r\nInput: numCourses = 2, prerequisites = [[1,0],[0,1]]\r\nOutput: false\r\nExplanation: There are a total of 2 courses to take. \r\nTo take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= numCourses <= 2000\r\n0 <= prerequisites.length <= 5000\r\nprerequisites[i].length == 2\r\n0 <= ai, bi < numCourses\r\nAll the pairs prerequisites[i] are unique.";
        // https://leetcode.com/problems/course-schedule/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            int[][] prereq = [[0, 1]];
            Solution solution = new Solution();
            Console.WriteLine("Expected : True");
            Console.WriteLine("Actual: " + solution.CanFinish(2, prereq));
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

        public class Solution
        {
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
}