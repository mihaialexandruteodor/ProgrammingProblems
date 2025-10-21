package org.example.leetcode.base;

import java.util.*;

public final class Utils {

    public static boolean GUI_MODE = false;

    // Singleton instance
    private static final Utils INSTANCE = new Utils();

    private Utils() {
    }

    public static Utils getInstance() {
        return INSTANCE;
    }

    // -----------------------------
    // Generic Array Printer (Lists, Arrays, etc.)
    // -----------------------------
    public static <T> String printForConsole(Iterable<T> array) {
        if (array == null)
            return "null";

        Iterator<T> iterator = array.iterator();
        if (!iterator.hasNext())
            return "[]";

        T first = iterator.next();
        if (first instanceof Iterable<?> && !(first instanceof String)) {
            // Nested collection
            List<String> nested = new ArrayList<>();
            for (T element : array) {
                Iterable<?> inner = (Iterable<?>) element;
                List<Object> innerList = new ArrayList<>();
                for (Object item : inner)
                    innerList.add(item);
                nested.add(printForConsole(innerList));
            }
            return "[" + String.join(",", nested) + "]";
        } else {
            // Simple flat list
            List<String> flat = new ArrayList<>();
            for (T element : array)
                flat.add(String.valueOf(element));
            return "[" + String.join(",", flat) + "]";
        }
    }

    // Overload for generic Object arrays (e.g., Integer[], String[])
    public static <T> String printForConsole(T[] array) {
        if (array == null)
            return "null";
        return printForConsole(Arrays.asList(array));
    }

    // Overload for primitive int arrays
    public static String printForConsole(int[] array) {
        if (array == null)
            return "null";
        if (array.length == 0)
            return "[]";
        StringBuilder sb = new StringBuilder("[");
        for (int i = 0; i < array.length; i++) {
            sb.append(array[i]);
            if (i < array.length - 1)
                sb.append(",");
        }
        sb.append("]");
        return sb.toString();
    }

    // -----------------------------
    // Problem Info Printer
    // -----------------------------
    public void printProblem(String description, Difficulty difficulty, Topic topic) {
        if (GUI_MODE) {
            // Suppress CLI color printing when running in GUI
            return;
        }
        System.out.print("Level: ");
        switch (difficulty) {
            case EASY -> setColor(ConsoleColor.BLUE);
            case MEDIUM -> setColor(ConsoleColor.YELLOW);
            case HARD -> setColor(ConsoleColor.RED);
        }
        System.out.println(difficulty);
        resetColor();

        System.out.print("Topic: ");
        setColor(ConsoleColor.CYAN);
        System.out.println(topic);
        resetColor();

        System.out.println(description);
        System.out.println();
    }

    // -----------------------------
    // Linked List Utilities
    // -----------------------------
    public static ListNode createLinkedList(int[] values) {
        if (values == null || values.length == 0)
            return null;

        ListNode head = new ListNode(values[0]);
        ListNode current = head;

        for (int i = 1; i < values.length; i++) {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        return head;
    }

    public static String printForConsole(ListNode head) {
        List<Integer> values = new ArrayList<>();
        while (head != null) {
            values.add(head.val);
            head = head.next;
        }
        return "[" + values.stream()
                .map(String::valueOf)
                .reduce((a, b) -> a + "," + b)
                .orElse("") + "]";
    }

    // -----------------------------
    // Console Color Helpers
    // -----------------------------
    private enum ConsoleColor {
        RESET("\u001B[0m"),
        BLUE("\u001B[34m"),
        YELLOW("\u001B[33m"),
        RED("\u001B[31m"),
        CYAN("\u001B[36m");

        private final String code;

        ConsoleColor(String code) {
            this.code = code;
        }
    }

    private static void setColor(ConsoleColor color) {
        System.out.print(color.code);
    }

    private static void resetColor() {
        System.out.print(ConsoleColor.RESET.code);
    }

    // -----------------------------
    // Supporting Enums
    // -----------------------------
    public enum Difficulty {
        EASY, MEDIUM, HARD
    }

    public enum Topic {
        ARRAYS, BINARY, BACKTRACKING, STRINGS, LINKED_LISTS, TREES, INTERVAL, GRAPHS, DYNAMIC_PROGRAMMING, GREEDY,
        MATRIX, OTHER
    }

    // -----------------------------
    // Simple ListNode Definition
    // -----------------------------
    public static class ListNode {
        public int val;
        public ListNode next;

        public ListNode(int val) {
            this.val = val;
        }
    }
}
