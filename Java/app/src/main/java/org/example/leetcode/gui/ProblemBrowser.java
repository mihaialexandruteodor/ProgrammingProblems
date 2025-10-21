package org.example.leetcode.gui;

import javafx.application.Application;
import javafx.collections.FXCollections;
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
import java.nio.file.Paths;
import java.util.*;
import java.util.stream.Collectors;

public class ProblemBrowser extends Application {

    private List<BaseSolution> allProblems = new ArrayList<>();
    private ListView<String> listView = new ListView<>();

    private ComboBox<Utils.Difficulty> difficultyFilter;
    private ComboBox<Utils.Topic> topicFilter;
    private TextField searchField;

    @Override
    public void start(Stage primaryStage) {
        Utils.GUI_MODE = true; // suppress CLI printing

        loadProblems();

        VBox root = new VBox(10);
        root.setPadding(new javafx.geometry.Insets(10));

        // Filters
        difficultyFilter = new ComboBox<>();
        difficultyFilter.getItems().add(null); // "All" option
        difficultyFilter.getItems().addAll(Utils.Difficulty.values());
        difficultyFilter.setPromptText("Filter by Difficulty");
        difficultyFilter.setOnAction(e -> updateList());

        topicFilter = new ComboBox<>();
        topicFilter.getItems().add(null); // "All" option
        topicFilter.getItems().addAll(Utils.Topic.values());
        topicFilter.setPromptText("Filter by Topic");
        topicFilter.setOnAction(e -> updateList());

        searchField = new TextField();
        searchField.setPromptText("Search by problem number or text");
        searchField.textProperty().addListener((obs, oldVal, newVal) -> updateList());

        HBox filtersBox = new HBox(10, difficultyFilter, topicFilter, searchField);

        // List
        listView.setPrefHeight(300);
        updateList();

        // Open button
        Button openButton = new Button("Open Problem");
        openButton.setOnAction(e -> {
            String selected = listView.getSelectionModel().getSelectedItem();
            if (selected != null) {
                BaseSolution selectedProblem = allProblems.stream()
                        .filter(p -> p.getName().equals(selected))
                        .findFirst().orElse(null);
                if (selectedProblem != null) {
                    openProblemWindow(selectedProblem);
                }
            }
        });

        root.getChildren().addAll(filtersBox, listView, openButton);

        Scene scene = new Scene(root, 700, 500);
        primaryStage.setTitle("LeetCode Problem Browser");
        primaryStage.setScene(scene);
        primaryStage.show();
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
            } catch (Exception ignored) {
            }
        }

        allProblems.sort(Comparator.comparing(BaseSolution::getName));
    }

    private void updateList() {
        Utils.Difficulty selectedDiff = difficultyFilter.getValue();
        Utils.Topic selectedTopic = topicFilter.getValue();
        String searchText = searchField.getText() != null ? searchField.getText().toLowerCase() : "";

        List<String> filtered = allProblems.stream()
                .filter(p -> (selectedDiff == null || p.getDifficulty() == selectedDiff))
                .filter(p -> (selectedTopic == null || p.getTopic() == selectedTopic))
                .filter(p -> p.getName().toLowerCase().contains(searchText))
                .map(BaseSolution::getName)
                .collect(Collectors.toList());

        listView.setItems(FXCollections.observableArrayList(filtered));
    }

    private void openProblemWindow(BaseSolution problem) {
        Stage stage = new Stage();
        VBox box = new VBox(10);
        box.setPadding(new javafx.geometry.Insets(10));

        Label title = new Label(problem.getName());
        title.setStyle("-fx-font-size: 18px; -fx-font-weight: bold;");

        TextArea desc = new TextArea(problem.getDescription());
        desc.setWrapText(true);
        desc.setEditable(false);
        desc.setPrefHeight(200);

        // Inner Solution class full source
        TextArea solutionSource = new TextArea();
        solutionSource.setWrapText(true);
        solutionSource.setEditable(false);
        solutionSource.setPrefHeight(200);
        solutionSource.setText(getInnerSolutionSource(problem));

        // Run button + output area
        Button runButton = new Button("Run Solution");
        TextArea outputArea = new TextArea();
        outputArea.setEditable(false);
        outputArea.setWrapText(true);
        outputArea.setPrefHeight(150);

        runButton.setOnAction(e -> {
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

        box.getChildren().addAll(title, desc, new Label("Solution Inner Class:"), solutionSource,
                runButton, new Label("Output:"), outputArea);

        stage.setScene(new Scene(box, 700, 650));
        stage.setTitle(problem.getName());
        stage.show();
    }

    private String getInnerSolutionSource(BaseSolution problem) {
        try {
            Class<?> cls = problem.getClass();
            String path = System.getProperty("user.dir") + "/src/main/java/" +
                    cls.getName().replace('.', '/') + ".java";
            File file = new File(path);
            if (!file.exists())
                return "// Source not found at: " + file.getAbsolutePath();

            List<String> lines = Files.readAllLines(Paths.get(file.getAbsolutePath()));
            StringBuilder sb = new StringBuilder();
            boolean inSolution = false;
            int braceCount = 0;

            for (String line : lines) {
                if (!inSolution) {
                    // Match any class Solution declaration
                    if (line.matches(".*\\bclass\\s+Solution\\b.*")) {
                        inSolution = true;
                        braceCount = countChar(line, '{') - countChar(line, '}');
                        continue; // skip the declaration line
                    }
                } else {
                    braceCount += countChar(line, '{') - countChar(line, '}');
                    if (braceCount <= 0)
                        break; // finished inner class
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
        launch(args);
    }
}
