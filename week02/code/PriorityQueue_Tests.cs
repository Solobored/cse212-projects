using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in priority order (highest first)
    // Defect(s) Found: 1) Loop in Dequeue went to Count-1 instead of Count, missing last item
    //                  2) Item was not actually removed from queue after finding highest priority
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and verify FIFO order for same priority
    // Expected Result: Items with same priority should be dequeued in FIFO order
    // Defect(s) Found: The comparison for finding high priority was `>=` instead of `>`, causing it to pick the last item with highest priority instead of the first (FIFO).
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: InvalidOperationException should be thrown
    // Defect(s) Found: None. This test passed as expected.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Mixed priorities with duplicates
    // Expected Result: Higher priorities first, then FIFO within same priority
    // Defect(s) Found: The comparison for finding high priority was `>=` instead of `>`, causing incorrect FIFO behavior for items with same priority.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);
        
        Assert.AreEqual("B", priorityQueue.Dequeue()); // First item with priority 5
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Second item with priority 5
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First item with priority 2
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Second item with priority 2
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Item with priority 1
    }
}
