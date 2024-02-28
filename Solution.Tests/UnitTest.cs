namespace Solution.Tests;

public class UnitTest
{
    [Fact]
    public void Test()
    {
        Assert.True(Solution.IsSameTree(Solution.BuildTree([1, 2, 3]), Solution.BuildTree([1, 2, 3])));
        Assert.False(Solution.IsSameTree(Solution.BuildTree([1, 2]), Solution.BuildTree([1, null, 2])));
        Assert.False(Solution.IsSameTree(Solution.BuildTree([1, 2, 1]), Solution.BuildTree([1, 1, 2])));
    }
}