using System;
using System.Collections;
using static IBaseSolution;

public sealed class Utils
{
    private static readonly Utils _instance = new Utils();

    // Private constructor ensures no outside instantiation
    private Utils() { }

    // Public accessor
    public static Utils Instance => _instance;

    public static string PrintForConsole<T>(IEnumerable<T> array)
    {
        if (array == null)
            return "null";

        IEnumerator<T> enumerator = array.GetEnumerator();

        if (enumerator.MoveNext())
        {
            var first = enumerator.Current;
            if (first != null && first is IEnumerable && !(first is string))
            {
                // first is IEnumerable (nested collection), handle as IEnumerable
                var nested = array.Cast<object>()  // Cast each T to object first
                                  .Select(obj =>
                                  {
                                      var innerEnum = obj as IEnumerable;
                                      // Convert IEnumerable to IEnumerable<object> for recursion
                                      var innerList = new List<object>();
                                      foreach (var item in innerEnum)
                                          innerList.Add(item);

                                      // Recursively print inner list
                                      return PrintForConsole(innerList);
                                  });
                return "[" + string.Join(",", nested) + "]";
            }
            else
            {
                // T is simple type, just print flat list
                return "[" + string.Join(",", array) + "]";
            }
        }
        else
        {
            // empty list
            return "[]";
        }
    }

    public void PrintProblem(string description, Difficulty difficulty, Topic topic)
    {
        Console.Write("Level: ");
        switch (difficulty)
        {
            case Difficulty.Easy:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case Difficulty.Medium:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case Difficulty.Hard:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }
        Console.WriteLine(difficulty);
        Console.ResetColor();

        Console.Write("Topic: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(topic);
        Console.ResetColor();

        Console.WriteLine(description);
        Console.WriteLine();
    }

    public static ListNode CreateLinkedList(int[] values)
    {
        if (values == null || values.Length == 0) return null;

        ListNode head = new ListNode(values[0]);
        ListNode current = head;

        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        return head;
    }

    public static string PrintForConsole(ListNode head)
    {
        var values = new List<int>();
        while (head != null)
        {
            values.Add(head.val);
            head = head.next;
        }
        return "[" + string.Join(",", values) + "]";
    }
}
