package org.example.leetcode.gui;

import com.formdev.flatlaf.FlatDarkLaf;
import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;
import org.reflections.Reflections;

import javax.swing.*;
import javax.swing.border.EmptyBorder;
import javax.swing.plaf.FontUIResource;
import javax.swing.text.*;
import java.awt.*;
import java.io.ByteArrayOutputStream;
import java.io.PrintStream;
import java.lang.reflect.Modifier;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.*;
import java.util.List;
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
        try {
            UIManager.setLookAndFeel(new FlatDarkLaf());
        } catch (Exception e) {
            e.printStackTrace();
        }

        // default font +2 size
        FontUIResource f = new FontUIResource("Segoe UI", Font.PLAIN, 18);
        setUIFont(f);

        frame = new JFrame("LeetCode Problem Browser");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(1200, 720);
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

        // font size buttons
        JButton increaseFontBtn = new JButton("+");
        JButton decreaseFontBtn = new JButton("-");
        increaseFontBtn.addActionListener(e -> adjustFontSize(2));
        decreaseFontBtn.addActionListener(e -> adjustFontSize(-2));

        filterPanel.add(new JLabel("Difficulty:"));
        filterPanel.add(difficultyFilter);
        filterPanel.add(new JLabel("Topic:"));
        filterPanel.add(topicFilter);
        filterPanel.add(new JLabel("Search:"));
        filterPanel.add(searchField);
        filterPanel.add(increaseFontBtn);
        filterPanel.add(decreaseFontBtn);

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
        title.setFont(title.getFont().deriveFont(Font.BOLD, 20f));
        topPanel.add(title, BorderLayout.NORTH);

        JTextArea descArea = new JTextArea(problem.getDescription());
        descArea.setLineWrap(true);
        descArea.setWrapStyleWord(true);
        descArea.setEditable(false);
        JScrollPane descScroll = new JScrollPane(descArea);
        descScroll.setPreferredSize(new Dimension(650, 150));
        topPanel.add(descScroll, BorderLayout.CENTER);

        window.add(topPanel, BorderLayout.NORTH);

        JTextPane sourcePane = createCodePane(getInnerSolutionSource(problem));
        JScrollPane sourceScroll = new JScrollPane(sourcePane);
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

    private JTextPane createCodePane(String code) {
        JTextPane codePane = new JTextPane();
        codePane.setEditable(false);
        codePane.setFont(new Font("Consolas", Font.PLAIN, 18));

        StyledDocument doc = codePane.getStyledDocument();
        addStylesToDocument(doc);

        try {
            doc.insertString(0, code, doc.getStyle("default"));
        } catch (Exception e) {
            e.printStackTrace();
        }

        highlightJavaSyntax(doc, code);
        return codePane;
    }

    private void addStylesToDocument(StyledDocument doc) {
        Style def = StyleContext.getDefaultStyleContext().getStyle(StyleContext.DEFAULT_STYLE);
        Style defaultStyle = doc.addStyle("default", def);
        StyleConstants.setForeground(defaultStyle, Color.WHITE);

        Style keyword = doc.addStyle("keyword", null);
        StyleConstants.setForeground(keyword, new Color(102, 217, 239));
        StyleConstants.setBold(keyword, true);

        Style comment = doc.addStyle("comment", null);
        StyleConstants.setForeground(comment, new Color(117, 113, 94));
        StyleConstants.setItalic(comment, true);

        Style string = doc.addStyle("string", null);
        StyleConstants.setForeground(string, new Color(255, 198, 109));

        Style type = doc.addStyle("type", null);
        StyleConstants.setForeground(type, new Color(166, 226, 46));
        StyleConstants.setBold(type, true);

        Style number = doc.addStyle("number", null);
        StyleConstants.setForeground(number, new Color(174, 129, 255));

        Style annotation = doc.addStyle("annotation", null);
        StyleConstants.setForeground(annotation, new Color(166, 226, 46));

        Style bracket = doc.addStyle("bracket", null);
        StyleConstants.setForeground(bracket, new Color(249, 38, 114));

        Style variable = doc.addStyle("variable", null);
        StyleConstants.setForeground(variable, new Color(97, 175, 239));
    }

    private void highlightJavaSyntax(StyledDocument doc, String code) {
        String[] keywords = {
                "abstract", "assert", "boolean", "break", "byte", "case", "catch", "char", "class", "continue",
                "default", "do",
                "double", "else", "enum", "extends", "final", "finally", "float", "for", "if", "implements", "import",
                "instanceof",
                "int", "interface", "long", "native", "new", "package", "private", "protected", "public", "return",
                "short", "static",
                "strictfp", "super", "switch", "synchronized", "this", "throw", "throws", "transient", "try", "void",
                "volatile", "while"
        };

        String[] types = { "String", "Integer", "Double", "Float", "List", "Map", "Set", "HashMap", "ArrayList",
                "HashSet", "Object" };

        Set<String> keywordSet = new HashSet<>(Arrays.asList(keywords));
        Set<String> typeSet = new HashSet<>(Arrays.asList(types));

        try {
            String[] lines = code.split("\n");
            int offset = 0;

            for (String line : lines) {
                if (line.trim().startsWith("//")) {
                    doc.setCharacterAttributes(offset, line.length(), doc.getStyle("comment"), false);
                } else {
                    for (String kw : keywords) {
                        int idx = line.indexOf(kw);
                        while (idx >= 0) {
                            if (isStandaloneToken(line, idx, kw.length())) {
                                doc.setCharacterAttributes(offset + idx, kw.length(), doc.getStyle("keyword"), false);
                            }
                            idx = line.indexOf(kw, idx + kw.length());
                        }
                    }

                    for (String tp : types) {
                        int idx = line.indexOf(tp);
                        while (idx >= 0) {
                            if (isStandaloneToken(line, idx, tp.length())) {
                                doc.setCharacterAttributes(offset + idx, tp.length(), doc.getStyle("type"), false);
                            }
                            idx = line.indexOf(tp, idx + tp.length());
                        }
                    }

                    int start = line.indexOf("\"");
                    while (start >= 0) {
                        int end = line.indexOf("\"", start + 1);
                        if (end < 0)
                            break;
                        doc.setCharacterAttributes(offset + start, end - start + 1, doc.getStyle("string"), false);
                        start = line.indexOf("\"", end + 1);
                    }

                    for (int i = 0; i < line.length(); i++) {
                        if (Character.isDigit(line.charAt(i))) {
                            int len = 1;
                            while (i + len < line.length()
                                    && (Character.isDigit(line.charAt(i + len)) || line.charAt(i + len) == '.'))
                                len++;
                            doc.setCharacterAttributes(offset + i, len, doc.getStyle("number"), false);
                            i += len - 1;
                        }
                    }

                    int annIdx = line.indexOf("@");
                    while (annIdx >= 0) {
                        int len = 1;
                        while (annIdx + len < line.length()
                                && Character.isJavaIdentifierPart(line.charAt(annIdx + len)))
                            len++;
                        doc.setCharacterAttributes(offset + annIdx, len, doc.getStyle("annotation"), false);
                        annIdx = line.indexOf("@", annIdx + len);
                    }

                    for (char c : new char[] { '{', '}', '(', ')', '[', ']' }) {
                        int idx = line.indexOf(c);
                        while (idx >= 0) {
                            doc.setCharacterAttributes(offset + idx, 1, doc.getStyle("bracket"), false);
                            idx = line.indexOf(c, idx + 1);
                        }
                    }

                    // variables
                    String[] tokens = line.split("[^A-Za-z0-9_]");
                    for (String token : tokens) {
                        if (token.matches("[A-Za-z_][A-Za-z0-9_]*") &&
                                !keywordSet.contains(token) &&
                                !typeSet.contains(token) &&
                                !token.startsWith("@")) {

                            int idx = line.indexOf(token);
                            while (idx >= 0) {
                                if (isStandaloneToken(line, idx, token.length())) {
                                    doc.setCharacterAttributes(offset + idx, token.length(), doc.getStyle("variable"),
                                            false);
                                }
                                idx = line.indexOf(token, idx + token.length());
                            }
                        }
                    }
                }
                offset += line.length() + 1;
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private boolean isStandaloneToken(String line, int idx, int length) {
        boolean beforeOK = idx == 0 || !Character.isJavaIdentifierPart(line.charAt(idx - 1));
        boolean afterOK = (idx + length >= line.length()) || !Character.isJavaIdentifierPart(line.charAt(idx + length));
        return beforeOK && afterOK;
    }

    private void adjustFontSize(int delta) {
        Font f = UIManager.getFont("Label.font");
        if (f == null)
            f = new Font("Segoe UI", Font.PLAIN, 18);
        Font newFont = f.deriveFont((float) (f.getSize() + delta));
        setUIFont(new FontUIResource(newFont));
        SwingUtilities.updateComponentTreeUI(frame);
    }

    private void setUIFont(FontUIResource f) {
        for (Object key : UIManager.getDefaults().keySet()) {
            if (UIManager.get(key) instanceof FontUIResource) {
                UIManager.put(key, f);
            }
        }
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
