using PlayGround.problems.DSA;
using System;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();

        var solutions = allTypes
            .Where(t => typeof(IBaseSolution).IsAssignableFrom(t)
                        && t.IsClass && !t.IsAbstract
                        && t.Namespace != null
                        && t.Namespace.Contains(".leetcode._"))
            .Select(t => new
            {
                Type = t,
                Num = ExtractProblemNumber(t.Namespace!),
                Name = t.Name,
                Difficulty = GetEnumField<IBaseSolution.Difficulty>(t, "difficulty"),
                Topic = GetEnumField<IBaseSolution.Topic>(t, "topic")
            })
            .Where(x => x.Num != null)
            .OrderBy(x => x.Topic)  // Group by Topic
            .ThenBy(x => x.Num)
            .ToList();

        if (!solutions.Any())
        {
            Console.WriteLine("No LeetCode solutions found.");
            return;
        }

        while (true)
        {
            int selected = 0;
            ConsoleKey key;

            do
            {
                ClearConsoleFully();
                Console.WriteLine("Select a LeetCode problem:\n");

                if (selected == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("🔢 Enter problem number manually");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("🔢 Enter problem number manually");
                }

                // Prepare aligned output
                const int numWidth = 6;
                const int nameWidth = 30;
                const int topicWidth = 18;
                const int difficultyWidth = 10;

                string? currentTopic = null;
                for (int i = 0; i < solutions.Count; i++)
                {
                    var s = solutions[i];

                    // Add group header for topic
                    if (s.Topic?.ToString() != currentTopic)
                    {
                        currentTopic = s.Topic?.ToString();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\n=== {currentTopic} ===\n");
                        Console.ResetColor();
                    }

                    if (i + 1 == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write(
                        $"{s.Num.ToString().PadRight(numWidth)}" +
                        $"{s.Name.PadRight(nameWidth)}");

                    // Topic
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{s.Topic?.ToString().PadRight(topicWidth)}");

                    // Difficulty
                    Console.ForegroundColor = s.Difficulty switch
                    {
                        IBaseSolution.Difficulty.Easy => ConsoleColor.Cyan,
                        IBaseSolution.Difficulty.Medium => ConsoleColor.Yellow,
                        IBaseSolution.Difficulty.Hard => ConsoleColor.Red,
                        _ => ConsoleColor.Gray
                    };
                    Console.Write($"{s.Difficulty?.ToString().PadRight(difficultyWidth)}");

                    Console.ResetColor();
                    Console.WriteLine();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selected = (selected == 0) ? solutions.Count : selected - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selected = (selected + 1) % (solutions.Count + 1);
                        break;
                }

            } while (key != ConsoleKey.Enter);

            if (selected == 0)
            {
                Console.Write("\nEnter LeetCode problem number: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int target))
                {
                    var manual = solutions.FirstOrDefault(x => x.Num == target);
                    if (manual != null)
                    {
                        RunProblem(manual);
                    }
                    else
                    {
                        Console.WriteLine("Problem not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                Console.WriteLine("\nPress Enter to return...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                ClearConsoleFully();
                continue;
            }

            RunProblem(solutions[selected - 1]);
        }
    }

    static void RunProblem(dynamic chosen)
    {
        var instance = Activator.CreateInstance(chosen.Type) as IBaseSolution;

        if (instance == null)
        {
            Console.WriteLine("Failed to instantiate solution.");
        }
        else
        {
            ClearConsoleFully();
            Console.WriteLine($"Running problem #{chosen.Num}: {chosen.Name}\n");
            instance.solve();
            Console.WriteLine("\n--- Source Code ---");
            instance.printSource();
        }

        Console.WriteLine("\nPress Enter to return to the problem selector...");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        ClearConsoleFully();
    }

    static TEnum? GetEnumField<TEnum>(Type t, string fieldName) where TEnum : struct
    {
        var field = t.GetField(fieldName, BindingFlags.Static | BindingFlags.Public);
        if (field != null && field.FieldType == typeof(TEnum))
        {
            return (TEnum?)field.GetValue(null);
        }
        return null;
    }

    static int? ExtractProblemNumber(string ns)
    {
        var idx = ns.IndexOf(".leetcode._");
        if (idx == -1) return null;
        var part = ns.Substring(idx + ".leetcode._".Length);
        var digits = new string(part.TakeWhile(char.IsDigit).ToArray());
        return int.TryParse(digits, out int num) ? num : null;
    }

    public static void ClearConsoleFully()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            Console.Write("\x1b[H");
            Console.Write("\x1b[2J");
        }
        else
        {
            Console.Write("\x1b[3J");
            Console.Write("\x1b[H");
            Console.Write("\x1b[2J");
        }
    }
}
