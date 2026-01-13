using System;
using System.Collections.Generic;

public class SimpleQueueSolution
{
    private readonly List<int> _queue = new();

    public static void Run()
    {
        Console.WriteLine("Test 1");
        var queue = new SimpleQueueSolution();
        queue.Enqueue(100);
        Console.WriteLine(queue.Dequeue());

        Console.WriteLine("------------");

        Console.WriteLine("Test 2");
        queue = new SimpleQueueSolution();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());

        Console.WriteLine("------------");

        Console.WriteLine("Test 3");
        queue = new SimpleQueueSolution();
        try
        {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("I got the exception as expected.");
        }
    }

    private void Enqueue(int value) => _queue.Add(value);

    private int Dequeue()
    {
        if (_queue.Count == 0)
            throw new IndexOutOfRangeException();

        var value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }
}
