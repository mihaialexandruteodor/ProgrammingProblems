package org.example.leetcode.gui;

import com.formdev.flatlaf.FlatLightLaf;
import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;
import org.reflections.Reflections;

import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.io.ByteArrayOutputStream;
import java.io.PrintStream;
import java.lang.reflect.Modifier;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

public class ProblemBrowserSwing {

    private JFrame frame;
    private JList<String> problemList;
    private DefaultListModel<String> listModel;

    private JComboBox<Utils.Difficulty> difficultyFilter;
    private JComboBox<Utils.Topic> topicFilter;
    private JTextField searchField;

    private List<BaseSolution> allProblems = new ArrayList<>();

    public ProblemBrowserSwing() {
        loadProblems();
        initUI();
    }

    private void loadProblems() {
        Reflections reflections = new Reflections("org.example.leetcode");
        Set<Class<? extends BaseSolution>> classes = reflections.getSubTypesOf(BaseSolution.class);

        for (Class<? extends BaseSolution> cls : classes) {
            if (Modifier.isAbstract(cls.getModifiers()))
                continue;
            try {
                BaseSolution instance = cls.getDeclaredConstructor().newInstance();
                instance.setGuiRun(true);
                allProblems.add(instance);
            } catch (Exception ignored) {
            }
        }

        allProblems.sort(Comparator.comparing(BaseSolution::getName));
    }

    private void initUI() {
        FlatLightLaf.install();

        frame = new JFrame("LeetCode Problem Browser");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(700, 600);
        frame.setLayout(new BorderLayout(10, 10));

        JPanel filterPanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 10, 5));

        difficultyFilter = new JComboBox<>();
        difficultyFilter.addItem(null);
        for (Utils.Difficulty d : Utils.Difficulty.values())
            difficultyFilter.addItem(d);
        difficultyFilter.addActionListener(e -> updateList());

        topicFilter = new JComboBox<>();
        topicFilter.addItem(null);
        for (Utils.Topic t : Utils.Topic.values())
            topicFilter.addItem(t);
        topicFilter.addActionListener(e -> updateList());

        searchField = new JTextField(20);
        searchField.getDocument().addDocumentListener((SimpleDocumentListener) this::updateList);

        filterPanel.add(new JLabel("Difficulty:"));
        filterPanel.add(difficultyFilter);
        filterPanel.add(new JLabel("Topic:"));
        filterPanel.add(topicFilter);
        filterPanel.add(new JLabel("Search:"));
        filterPanel.add(searchField);

        listModel = new DefaultListModel<>();
        problemList = new JList<>(listModel);
        problemList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        JScrollPane scrollPane = new JScrollPane(problemList);

        JButton openButton = new JButton("Open Problem");
        openButton.addActionListener(e -> {
            String selected = problemList.getSelectedValue();
            if (selected != null) {
                BaseSolution problem = allProblems.stream()
                        .filter(p -> p.getName().equals(selected))
                        .findFirst()
                        .orElse(null);
                if (problem != null)
                    openProblemWindow(problem);
            }
        });

        frame.add(filterPanel, BorderLayout.NORTH);
        frame.add(scrollPane, BorderLayout.CENTER);
        frame.add(openButton, BorderLayout.SOUTH);

        updateList();
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }

    private void updateList() {
        Utils.Difficulty diff = (Utils.Difficulty) difficultyFilter.getSelectedItem();
        Utils.Topic topic = (Utils.Topic) topicFilter.getSelectedItem();
        String search = searchField.getText() != null ? searchField.getText().toLowerCase() : "";

        List<String> filtered = allProblems.stream()
                .filter(p -> diff == null || p.getDifficulty() == diff)
                .filter(p -> topic == null || p.getTopic() == topic)
                .filter(p -> p.getName().toLowerCase().contains(search))
                .map(BaseSolution::getName)
                .collect(Collectors.toList());

        listModel.clear();
        for (String name : filtered)
            listModel.addElement(name);
    }

    private void openProblemWindow(BaseSolution problem) {
        JFrame window = new JFrame(problem.getName());
        window.setSize(700, 650);
        window.setLayout(new BorderLayout(10, 10));
        window.setLocationRelativeTo(frame);

        JPanel topPanel = new JPanel(new BorderLayout());
        topPanel.setBorder(new EmptyBorder(10, 10, 10, 10));

        JLabel title = new JLabel(problem.getName());
        title.setFont(title.getFont().deriveFont(Font.BOLD, 18f));
        topPanel.add(title, BorderLayout.NORTH);

        JTextArea descArea = new JTextArea(problem.getDescription());
        descArea.setLineWrap(true);
        descArea.setWrapStyleWord(true);
        descArea.setEditable(false);
        JScrollPane descScroll = new JScrollPane(descArea);
        descScroll.setPreferredSize(new Dimension(650, 150));
        topPanel.add(descScroll, BorderLayout.CENTER);

        window.add(topPanel, BorderLayout.NORTH);

        JTextArea sourceArea = new JTextArea(getInnerSolutionSource(problem));
        sourceArea.setLineWrap(true);
        sourceArea.setWrapStyleWord(true);
        sourceArea.setEditable(false);
        JScrollPane sourceScroll = new JScrollPane(sourceArea);
        sourceScroll.setPreferredSize(new Dimension(650, 200));

        JButton runButton = new JButton("Run Solution");
        JTextArea outputArea = new JTextArea();
        outputArea.setEditable(false);
        outputArea.setLineWrap(true);
        outputArea.setWrapStyleWord(true);
        JScrollPane outputScroll = new JScrollPane(outputArea);
        outputScroll.setPreferredSize(new Dimension(650, 150));

        runButton.addActionListener(e -> {
            try {
                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                PrintStream ps = new PrintStream(baos);
                PrintStream oldOut = System.out;
                System.setOut(ps);

                problem.solve();

                System.out.flush();
                System.setOut(oldOut);
                outputArea.setText(baos.toString());
            } catch (Exception ex) {
                outputArea.setText(ex.toString());
            }
        });

        JButton leetCodeButton = new JButton("Open LeetCode Problem");
        leetCodeButton.addActionListener(e -> {
            try {
                String url = problem.getLeetcodeUrl();
                if (url != null && !url.isEmpty())
                    Desktop.getDesktop().browse(new URI(url));
            } catch (Exception ex) {
                JOptionPane.showMessageDialog(window,
                        "Failed to open URL: " + ex.getMessage(),
                        "Error",
                        JOptionPane.ERROR_MESSAGE);
            }
        });

        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 10, 5));
        buttonPanel.add(runButton);
        buttonPanel.add(leetCodeButton);

        JPanel centerPanel = new JPanel(new BorderLayout());
        centerPanel.add(sourceScroll, BorderLayout.NORTH);
        centerPanel.add(buttonPanel, BorderLayout.CENTER);
        centerPanel.add(outputScroll, BorderLayout.SOUTH);

        window.add(centerPanel, BorderLayout.CENTER);
        window.setVisible(true);
    }

    private String getInnerSolutionSource(BaseSolution problem) {
        try {
            Class<?> cls = problem.getClass();
            String path = System.getProperty("user.dir") + "/src/main/java/" +
                    cls.getName().replace('.', '/') + ".java";
            java.io.File file = new java.io.File(path);
            if (!file.exists())
                return "// Source not found at: " + file.getAbsolutePath();

            List<String> lines = Files.readAllLines(Paths.get(file.getAbsolutePath()));
            StringBuilder sb = new StringBuilder();
            boolean inSolution = false;
            int braceCount = 0;

            for (String line : lines) {
                if (!inSolution) {
                    if (line.matches(".*\\bclass\\s+Solution\\b.*")) {
                        inSolution = true;
                        braceCount = countChar(line, '{') - countChar(line, '}');
                        continue;
                    }
                } else {
                    braceCount += countChar(line, '{') - countChar(line, '}');
                    if (braceCount <= 0)
                        break;
                    sb.append(line).append("\n");
                }
            }

            if (!inSolution)
                return "// Inner Solution class not found";
            return sb.toString().trim();
        } catch (Exception e) {
            return "// Unable to read inner Solution class: " + e.getMessage();
        }
    }

    private int countChar(String s, char c) {
        int cnt = 0;
        for (char ch : s.toCharArray())
            if (ch == c)
                cnt++;
        return cnt;
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(ProblemBrowserSwing::new);
    }

    @FunctionalInterface
    private interface SimpleDocumentListener extends javax.swing.event.DocumentListener {
        void update();

        @Override
        default void insertUpdate(javax.swing.event.DocumentEvent e) {
            update();
        }

        @Override
        default void removeUpdate(javax.swing.event.DocumentEvent e) {
            update();
        }

        @Override
        default void changedUpdate(javax.swing.event.DocumentEvent e) {
            update();
        }
    }
}
