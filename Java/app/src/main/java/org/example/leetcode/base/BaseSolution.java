package org.example.leetcode.base;

public abstract class BaseSolution {

    protected boolean isGuiRun = false;

    public void setGuiRun(boolean isGuiRun) {
        this.isGuiRun = isGuiRun;
    }

    public boolean isGuiRun() {
        return isGuiRun;
    }

    public abstract void solve();

    public void printSource() {
        SourcePrinter.printSource(this.getClass());
    }

    protected String name = "Unnamed Problem";
    protected Utils.Difficulty difficulty = Utils.Difficulty.EASY;
    protected Utils.Topic topic = Utils.Topic.OTHER;
    protected String description = "";
    protected String leetcodeurl = "";

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
