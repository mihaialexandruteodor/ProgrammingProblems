package org.example.leetcode.base;

public abstract class BaseSolution {

    public abstract void solve();

    public void printSource() {
        SourcePrinter.printSource(this.getClass());
    }

    // Metadata properties — instance fields
    protected String name = "Unnamed Problem";
    protected Utils.Difficulty difficulty = Utils.Difficulty.EASY;
    protected Utils.Topic topic = Utils.Topic.OTHER;
    protected String description = "";

    // Accessors
    public String getName() {
        return name;
    }

    public Utils.Difficulty getDifficulty() {
        return difficulty;
    }

    public Utils.Topic getTopic() {
        return topic;
    }

    public String getDescription() {
        return description;
    }
}
