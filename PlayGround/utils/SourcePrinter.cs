public static class SourcePrinter
{
    public static void PrintSource(Type solutionType)
    {
        string className = "Solution";
        string? ns = solutionType.Namespace;

        if (ns == null || !ns.Contains(".leetcode."))
        {
            Console.WriteLine("Unable to determine source path.");
            return;
        }

        var match = System.Text.RegularExpressions.Regex.Match(ns, @"\.leetcode\.(?:_)?(\d+)");
        if (!match.Success)
        {
            Console.WriteLine("Could not extract problem number from namespace.");
            return;
        }

        string problemNumber = match.Groups[1].Value;

        string outerClassName = solutionType.Name;
        string relativePath = Path.Combine("problems", "leetcode", problemNumber, $"{outerClassName}.cs");
        string basePath = AppContext.BaseDirectory;
        string fullPath = Path.GetFullPath(Path.Combine(basePath, "..", "..", "..", relativePath));

        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"Source file not found at:\n{fullPath}");
            return;
        }

        var lines = File.ReadAllLines(fullPath);

        bool inSolutionClass = false;
        int braceDepth = 0;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n--- Nested Class `{className}` Body ---\n");

        foreach (var line in lines)
        {
            if (!inSolutionClass)
            {
                if (line.Contains($"public class {className}"))
                {
                    inSolutionClass = true;

                    int braceIndex = line.IndexOf('{');
                    if (braceIndex >= 0)
                    {
                        braceDepth = 1;
                        string afterBrace = line.Substring(braceIndex + 1);
                        if (!string.IsNullOrWhiteSpace(afterBrace))
                            Console.WriteLine(afterBrace);
                    }
                }
            }
            else
            {
                braceDepth += line.Count(c => c == '{');
                braceDepth -= line.Count(c => c == '}');

                if (braceDepth <= 0)
                    break;

                Console.WriteLine(line);
            }
        }

        Console.ResetColor();
    }
}
