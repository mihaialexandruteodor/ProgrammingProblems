package org.example.leetcode.base;

public abstract class BaseSolution {

    /**
     * Standard entry point for all LeetCode solutions.
     * Each subclass must override this method to demonstrate or test its logic.
     */
    public abstract void solve();

    /**
     * Prints the source code of the implementing class.
     * Relies on a SourcePrinter utility class.
     */
    public void printSource() {
        SourcePrinter.printSource(this.getClass());
    }
}
