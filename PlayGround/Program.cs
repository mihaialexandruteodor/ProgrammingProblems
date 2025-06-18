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
                Name = t.Name
            })
            .Where(x => x.Num != null)
            .OrderBy(x => x.Num)
            .ToList();

        if (!solutions.Any())
        {
            Console.WriteLine("No LeetCode solutions found.");
            return;
        }

        while (true) // <-- LOOP to repeat selection
        {
            int selected = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("Select a LeetCode problem:\n");

                for (int i = 0; i < solutions.Count; i++)
                {
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"{solutions[i].Num} {solutions[i].Name}");

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selected = (selected == 0) ? solutions.Count - 1 : selected - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selected = (selected + 1) % solutions.Count;
                        break;
                }

            } while (key != ConsoleKey.Enter);

            var chosen = solutions[selected];
            var instance = Activator.CreateInstance(chosen.Type) as IBaseSolution;

            if (instance == null)
            {
                Console.WriteLine("Failed to instantiate solution.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Running problem #{chosen.Num}: {chosen.Name}\n");
                instance.solve();
            }

            Console.WriteLine("\nPress Enter to return to the problem selector...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        }
    }

    static int? ExtractProblemNumber(string ns)
    {
        var idx = ns.IndexOf(".leetcode._");
        if (idx == -1) return null;
        var part = ns.Substring(idx + ".leetcode._".Length);
        var digits = new string(part.TakeWhile(char.IsDigit).ToArray());
        return int.TryParse(digits, out int num) ? num : null;
    }
}
