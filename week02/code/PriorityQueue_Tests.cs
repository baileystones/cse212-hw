using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: We're adding items to the queue with different priority numbers
    // Expected Result: Items are getting added in the order they go in the queue, ignoring their priority number
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Number1", 1);
        priorityQueue.Enqueue("Number2", 3);
        priorityQueue.Enqueue("Number3", 2);
        
        var items = priorityQueue.ToString();
        Assert.AreEqual("[Number1 (Pri:1), Number2 (Pri:3), Number3 (Pri:2)]", items);
       // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: The numbers dequeue when there are differing priorities
    // Expected Result: The item with the highest number priority gets dequeued 
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Number1", 1);
        priorityQueue.Enqueue("Number2", 2);
        priorityQueue.Enqueue("Number3", 3);

        var dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("Number3", dequeued);

        //Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}