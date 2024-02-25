namespace UnitTestProj;

public class Test168
{
    [Fact]
    public void TestAZ()
    {
        IBaseSolution solution = new ExcelSheetColumnTitle();

        string res = solution.solve(52);    
        Assert.Equal("AZ", res);   
    }

    [Fact]
    public void TestA()
    {
        IBaseSolution solution = new ExcelSheetColumnTitle();

        string res = solution.solve(1);    
        Assert.Equal("A", res);   
    }

    [Fact]
    public void TestAB()
    {
        IBaseSolution solution = new ExcelSheetColumnTitle();

        string res = solution.solve(28);    
        Assert.Equal("AB", res);   
    }

    [Fact]
    public void TestZY()
    {
        IBaseSolution solution = new ExcelSheetColumnTitle();

        string res = solution.solve(701);    
        Assert.Equal("ZY", res);   
    }
}