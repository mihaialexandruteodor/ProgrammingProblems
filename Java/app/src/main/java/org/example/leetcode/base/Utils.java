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

    public static ListNode createLinkedList(int[] values, int pos) {
        if (values == null || values.length == 0)
            return null;

        ListNode head = new ListNode(values[0]);
        ListNode current = head;
        ListNode loop = pos == 0 ? head : null;

        for (int i = 1; i < values.length; i++) {
            current.next = new ListNode(values[i]);
            if (i == pos)
                loop = current;
            current = current.next;
        }

        current.next = loop;
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

    // Node definition
    public static class Node {
        public int val;
        public List<Node> neighbors;

        Node() {
            val = 0;
            neighbors = new ArrayList<>();
        }

        public Node(int val) {
            this.val = val;
            neighbors = new ArrayList<>();
        }

        Node(int val, List<Node> neighbors) {
            this.val = val;
            this.neighbors = neighbors;
        }
    }

    public static Node buildGraph(int[][] adjList) {
        if (adjList == null || adjList.length == 0)
            return null;

        // Step 1: Create all nodes
        Map<Integer, Node> nodeMap = new HashMap<>();
        for (int i = 0; i < adjList.length; i++) {
            int nodeVal = i + 1;
            nodeMap.put(nodeVal, new Node(nodeVal));
        }

        // Step 2: Link neighbors
        for (int i = 0; i < adjList.length; i++) {
            int nodeVal = i + 1;
            Node currentNode = nodeMap.get(nodeVal);
            for (int neighborVal : adjList[i]) {
                currentNode.neighbors.add(nodeMap.get(neighborVal));
            }
        }

        return nodeMap.get(1); // Return node with value 1 as entry point
    }

    public static void printGraph(Node root) {
        if (root == null) {
            System.out.println("[]");
            return;
        }

        // Use BFS to explore all nodes and map neighbors
        Map<Integer, List<Integer>> graphMap = new HashMap<>();
        Set<Integer> visited = new HashSet<>();
        Queue<Node> queue = new LinkedList<>();

        queue.add(root);
        visited.add(root.val);

        while (!queue.isEmpty()) {
            Node current = queue.poll();
            graphMap.putIfAbsent(current.val, new ArrayList<>());

            for (Node neighbor : current.neighbors) {
                graphMap.get(current.val).add(neighbor.val);
                if (!visited.contains(neighbor.val)) {
                    visited.add(neighbor.val);
                    queue.add(neighbor);
                }
            }
        }

        // Convert to sorted array output
        int maxNode = Collections.max(graphMap.keySet());
        List<String> output = new ArrayList<>();

        for (int i = 1; i <= maxNode; i++) {
            List<Integer> neighbors = graphMap.getOrDefault(i, new ArrayList<>());
            Collections.sort(neighbors);
            output.add(Utils.printForConsole(neighbors));
        }

        System.out.println(Utils.printForConsole(output));
    }

    // TreeNode definition
    public static class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val) {
            this.val = val;
        }

        public TreeNode(int val, TreeNode left, TreeNode right) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    // BuildTree helper
    public static TreeNode buildTree(Integer[] values) {
        if (values == null || values.length == 0 || values[0] == null)
            return null;

        TreeNode root = new TreeNode(values[0]);
        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);
        int i = 1;

        while (i < values.length) {
            TreeNode current = queue.poll();

            // Add left child
            if (i < values.length && values[i] != null) {
                current.left = new TreeNode(values[i]);
                queue.add(current.left);
            }
            i++;

            // Add right child
            if (i < values.length && values[i] != null) {
                current.right = new TreeNode(values[i]);
                queue.add(current.right);
            }
            i++;
        }

        return root;
    }

    public static void printTreeAsArray(TreeNode root) {
        if (root == null) {
            System.out.println("[]");
            return;
        }

        List<Integer> result = new ArrayList<>();
        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);

        while (!queue.isEmpty()) {
            TreeNode current = queue.poll();
            if (current != null) {
                result.add(current.val);
                queue.add(current.left);
                queue.add(current.right);
            } else {
                result.add(null);
            }
        }

        // Trim trailing nulls
        int i = result.size() - 1;
        while (i >= 0 && result.get(i) == null) {
            result.remove(i);
            i--;
        }

        // Print as array format
        System.out.print("[");
        for (int j = 0; j < result.size(); j++) {
            System.out.print(result.get(j) != null ? result.get(j) : "null");
            if (j < result.size() - 1) {
                System.out.print(",");
            }
        }
        System.out.println("]");
    }

}
