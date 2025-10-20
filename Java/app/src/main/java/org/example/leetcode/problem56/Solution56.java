package org.example.leetcode.problem56;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution56 extends BaseSolution {
    public Solution56() {
        this.name = "56. Merge Intervals";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.INTERVAL;
        this.description = "Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: intervals = [[1,3],[2,6],[8,10],[15,18]]\r\nOutput: [[1,6],[8,10],[15,18]]\r\nExplanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].\r\nExample 2:\r\n\r\nInput: intervals = [[1,4],[4,5]]\r\nOutput: [[1,5]]\r\nExplanation: Intervals [1,4] and [4,5] are considered overlapping.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= intervals.length <= 104\r\nintervals[i].length == 2\r\n0 <= starti <= endi <= 104";
        // https://leetcode.com/problems/merge-intervals/
    }

    @Override
    public void solve() {

    }

}
