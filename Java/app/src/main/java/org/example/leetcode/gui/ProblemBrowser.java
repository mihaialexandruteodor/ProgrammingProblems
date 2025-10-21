package org.example.leetcode.gui;

import javafx.application.Application;
import javafx.collections.FXCollections;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.stage.Stage;
import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;
import org.reflections.Reflections;

import java.io.*;
import java.lang.reflect.Modifier;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class ProblemBrowser extends Application {

    private final Map<Utils.Difficulty, List<BaseSolution>> problemsByDifficulty = new EnumMap<>(
            Utils.Difficulty.class);
    private final List<BaseSolution> allProblems = new ArrayList<>();
    private final Map<Utils.Topic, List<BaseSolution>> problemsByTopic = new EnumMap<>(Utils.Topic.class);

    private ComboBox<String> topicFilter;
    private ListView<String> listView;
    private List<BaseSolution> currentList = new ArrayList<>();

    @Override
    public void start(Stage primaryStage) {
        Utils.GUI_MODE = true;
        loadProblems();

        // ----- Filter dropdown -----
        topicFilter = new ComboBox<>();
        topicFilter.getItems().add("All");
        topicFilter.getItems().addAll(Arrays.stream(Utils.Topic.values()).map(Enum::name).toList());
        topicFilter.setValue("All");
        topicFilter.setOnAction(e -> applyFilter());

        // ----- List view -----
        listView = new ListView<>();
        updateListView(allProblems);

        Button openButton = new Button("Open Problem");
        openButton.setOnAction(e -> {
            String selected = listView.getSelectionModel().getSelectedItem();
            if (selected != null) {
                BaseSolution selectedProblem = currentList.stream()
                        .filter(p -> p.getName().equals(selected))
                        .findFirst().orElse(null);
                if (selectedProblem != null) {
                    openProblemWindow(selectedProblem);
                }
            }
        });

        VBox mainLayout = new VBox(10,
                new Label("Filter by topic:"), topicFilter,
                listView, openButton);
        mainLayout.setPadding(new Insets(10));

        Scene scene = new Scene(mainLayout, 700, 500);
        primaryStage.setTitle("LeetCode Problem Browser");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    private void applyFilter() {
        String selected = topicFilter.getValue();
        if (selected == null || selected.equals("All")) {
            updateListView(allProblems);
        } else {
            Utils.Topic topic = Utils.Topic.valueOf(selected);
            updateListView(problemsByTopic.getOrDefault(topic, Collections.emptyList()));
        }
    }

    private void updateListView(List<BaseSolution> problems) {
        currentList = problems;
        listView.setItems(FXCollections.observableArrayList(
                problems.stream().map(BaseSolution::getName).sorted().toList()));
    }

    private void loadProblems() {
        Reflections reflections = new Reflections("org.example.leetcode");
        Set<Class<? extends BaseSolution>> classes = reflections.getSubTypesOf(BaseSolution.class);

        for (Class<? extends BaseSolution> cls : classes) {
            if (Modifier.isAbstract(cls.getModifiers()))
                continue;
            try {
                BaseSolution instance = cls.getDeclaredConstructor().newInstance();
                allProblems.add(instance);
                problemsByDifficulty
                        .computeIfAbsent(instance.getDifficulty(), k -> new ArrayList<>())
                        .add(instance);
                problemsByTopic
                        .computeIfAbsent(instance.getTopic(), k -> new ArrayList<>())
                        .add(instance);
            } catch (Exception ignored) {
            }
        }

        allProblems.sort(Comparator.comparing(BaseSolution::getName));
    }

    private void openProblemWindow(BaseSolution problem) {
        Stage stage = new Stage();
        VBox box = new VBox(10);
        box.setPadding(new Insets(10));

        Label title = new Label(problem.getName());
        title.setStyle("-fx-font-size: 18px; -fx-font-weight: bold;");

        TextArea desc = new TextArea(problem.getDescription());
        desc.setWrapText(true);
        desc.setEditable(false);
        desc.setPrefHeight(180);

        // ---- Source Code Display ----
        TextArea sourceArea = new TextArea(loadInnerSolutionSource(problem));
        sourceArea.setWrapText(false);
        sourceArea.setEditable(false);
        sourceArea.setPrefHeight(250);

        // ---- Output Display ----
        TextArea outputArea = new TextArea();
        outputArea.setEditable(false);
        outputArea.setPrefHeight(200);
        outputArea.setWrapText(true);

        Button runButton = new Button("Run Solution");
        runButton.setOnAction(e -> {
            outputArea.clear();
            outputArea.appendText(runSolution(problem));
        });

        box.getChildren().addAll(
                title,
                new Label("Description:"), desc,
                new Label("Inner Solution Code:"), sourceArea,
                runButton,
                new Label("Output:"), outputArea);

        stage.setScene(new Scene(box, 800, 700));
        stage.setTitle(problem.getName());
        stage.show();
    }

    private String runSolution(BaseSolution problem) {
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        PrintStream oldOut = System.out;
        System.setOut(new PrintStream(baos));
        try {
            problem.solve();
        } catch (Exception ex) {
            ex.printStackTrace();
        } finally {
            System.setOut(oldOut);
        }

        // Strip ANSI colors (if printProblem was used accidentally)
        return baos.toString()
                .replaceAll("\u001B\\[[;\\d]*m", "");
    }

    /**
     * Reads only the inner 'Solution' class from the problem source file.
     */
    private String loadInnerSolutionSource(BaseSolution problem) {
        try {
            String baseDir = System.getProperty("user.dir");
            String packagePath = problem.getClass().getPackageName().replace('.', '/');
            String className = problem.getClass().getSimpleName() + ".java";
            Path srcPath = Path.of(baseDir, "src", "main", "java", packagePath, className);

            if (!Files.exists(srcPath)) {
                return "// Source not found at: " + srcPath;
            }

            String source = Files.readString(srcPath);

            // Regex to extract the inner Solution class contents
            Pattern pattern = Pattern.compile(
                    "(?s)class\\s+Solution\\s*\\{(.*)\\}\\s*$");
            Matcher matcher = pattern.matcher(source);
            if (matcher.find()) {
                return matcher.group(1).strip();
            } else {
                return "// Inner class 'Solution' not found in " + className;
            }
        } catch (IOException e) {
            return "// Unable to read source for " + problem.getName();
        }
    }

    public static void main(String[] args) {
        launch(args);
    }
}
