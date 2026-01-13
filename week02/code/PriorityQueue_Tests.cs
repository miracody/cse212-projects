using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueue_TestsTest
{
    [TestMethod]
    public void TestPriorityQueue_Int()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("5", 1);
        pq.Enqueue("10", 2);

        var first = pq.Dequeue();
        Assert.AreEqual("10", (string)first);
    }

    [TestMethod]
    public void TestPriorityQueue_String()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("low", 1);
        pq.Enqueue("high", 5);

        var first = pq.Dequeue();
        Assert.AreEqual("high", (string)first);
        var second = pq.Dequeue();
        Assert.AreEqual("low", (string)second);
    }
}