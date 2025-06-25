using System;
using static IBaseSolution;

public sealed class Utils
{
    private static readonly Utils _instance = new Utils();

    // Private constructor ensures no outside instantiation
    private Utils() { }

    // Public accessor
    public static Utils Instance => _instance;

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
}
