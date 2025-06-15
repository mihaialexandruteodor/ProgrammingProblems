using PlayGround.problems.DSA;
using System;
using System.Linq;
using System.Reflection;



public class Program
{
	public static void Main()
	{
        Console.Write("Enter LeetCode problem number: ");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int problemNumber))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        // Construct the expected namespace
        string targetNamespace = $"problems.leetcode._{problemNumber}";

        // Get all loaded types in the current assembly
        var solutionType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => t.Namespace == targetNamespace)
            .FirstOrDefault(t => typeof(IBaseSolution).IsAssignableFrom(t));

        if (solutionType == null)
        {
            Console.WriteLine("Solution class not found or doesn't implement IBaseSolution.");
            return;
        }

        // Instantiate and call solve
        var solution = Activator.CreateInstance(solutionType) as IBaseSolution;
        solution?.solve();
    }
}