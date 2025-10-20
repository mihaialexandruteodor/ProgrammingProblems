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

import java.lang.reflect.Modifier;
import java.util.*;
import java.util.stream.Collectors;

public class ProblemBrowser extends Application {

    private Map<Utils.Difficulty, List<BaseSolution>> problemsByDifficulty = new EnumMap<>(Utils.Difficulty.class);

    @Override
    public void start(Stage primaryStage) {
        loadProblems();

        TabPane tabPane = new TabPane();
        for (Utils.Difficulty diff : Utils.Difficulty.values()) {
            ListView<String> listView = new ListView<>();
            List<BaseSolution> list = problemsByDifficulty.getOrDefault(diff, Collections.emptyList());
            listView.setItems(FXCollections.observableArrayList(
                    list.stream().map(BaseSolution::getName).toList()));

            Button openButton = new Button("Open Problem");
            openButton.setOnAction(e -> {
                String selected = listView.getSelectionModel().getSelectedItem();
                if (selected != null) {
                    BaseSolution selectedProblem = list.stream()
                            .filter(p -> p.getName().equals(selected))
                            .findFirst().orElse(null);
                    if (selectedProblem != null) {
                        openProblemWindow(selectedProblem);
                    }
                }
            });

            VBox box = new VBox(10, listView, openButton);
            box.setPadding(new javafx.geometry.Insets(10));
            tabPane.getTabs().add(new Tab(diff.name(), box));
        }

        Scene scene = new Scene(tabPane, 600, 400);
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
                problemsByDifficulty
                        .computeIfAbsent(instance.getDifficulty(), k -> new ArrayList<>())
                        .add(instance);
            } catch (Exception ignored) {
            }
        }

        // Sort alphabetically by problem name
        problemsByDifficulty.values().forEach(list -> list.sort(Comparator.comparing(BaseSolution::getName)));
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
        desc.setPrefHeight(300);

        Button runButton = new Button("Run Solution");
        runButton.setOnAction(e -> {
            System.out.println("Running " + problem.getName() + "...");
            problem.solve();
        });

        box.getChildren().addAll(title, desc, runButton);
        stage.setScene(new Scene(box, 500, 400));
        stage.setTitle(problem.getName());
        stage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
