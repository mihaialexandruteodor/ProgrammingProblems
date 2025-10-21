package org.example.leetcode.base;

import java.io.IOException;
import java.nio.file.*;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SourcePrinter {

    @SuppressWarnings("unused")
    public static void printSource(Class<?> solutionClass) {
        String className = "Solution"; // inner class to locate (if used)
        String pkg = solutionClass.getPackageName();

        if (pkg == null || !pkg.contains(".leetcode.")) {
            System.out.println("Unable to determine source path.");
            return;
        }

        // Extract problem number (handles packages like .leetcode.problem3397)
        Matcher match = Pattern.compile("\\.leetcode\\.(?:problem|_)?(\\d+)").matcher(pkg);
        if (!match.find()) {
            System.out.println("Could not extract problem number from package name.");
            return;
        }

        String problemNumber = match.group(1);
        String outerClassName = solutionClass.getSimpleName();

        // Expected Java project path
        String relativePath = Paths.get(
                "src", "main", "java", "org", "example", "leetcode",
                "problem" + problemNumber,
                outerClassName + ".java").toString();

        Path basePath = Paths.get(System.getProperty("user.dir"));
        Path fullPath = basePath.resolve(relativePath).normalize();

        if (!Files.exists(fullPath)) {
            System.out.println("Source file not found at:\n" + fullPath);
            return;
        }

        try {
            List<String> lines = Files.readAllLines(fullPath);

            boolean inSolutionClass = false;
            int braceDepth = 0;

            System.out.println("\n--- Class `" + outerClassName + "` Body ---\n");

            for (String line : lines) {
                if (!inSolutionClass) {
                    // Look for "public class Solution" or "class Solution3397"
                    if (line.contains("class " + outerClassName)) {
                        inSolutionClass = true;

                        int braceIndex = line.indexOf('{');
                        if (braceIndex >= 0) {
                            braceDepth = 1;
                            String afterBrace = line.substring(braceIndex + 1).trim();
                            if (!afterBrace.isEmpty()) {
                                System.out.println(afterBrace);
                            }
                        }
                    }
                } else {
                    // Track braces to know when the class ends
                    braceDepth += countChar(line, '{');
                    braceDepth -= countChar(line, '}');

                    if (braceDepth <= 0)
                        break;

                    System.out.println(line);
                }
            }

            System.out.println("\n--- End of " + outerClassName + " ---\n");
        } catch (IOException e) {
            System.err.println("Error reading source file: " + e.getMessage());
        }
    }

    private static int countChar(String str, char c) {
        int count = 0;
        for (char ch : str.toCharArray()) {
            if (ch == c)
                count++;
        }
        return count;
    }
}
