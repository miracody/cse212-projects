/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
using System;
using System.Collections.Generic;

/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be added and serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Test 1: Add one customer and then serve them
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer();   // enter sample input when prompted
        service.ServeCustomer();    // should print the same customer
        Console.WriteLine("=================");

        // Test 2: Add two customers and serve them in order
        Console.WriteLine("Test 2");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");
        Console.WriteLine("=================");

        // Test 3: Serve a customer when queue is empty
        Console.WriteLine("Test 3");
        service = new CustomerService(4);
        service.ServeCustomer(); // should display an error
        Console.WriteLine("=================");

        // Test 4: Add more customers than max size
        Console.WriteLine("Test 4");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();   // this one should trigger error
        Console.WriteLine($"Service Queue: {service}");
        Console.WriteLine("=================");

        // Test 5: Initialize with invalid size (0) -> defaults to 10
        Console.WriteLine("Test 5");
        service = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {service}");
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() => $"{Name} ({AccountId}): {Problem}";
    }

    /// <summary>
    /// Prompt the user for the customer and problem information. Enqueue the new record.
    /// </summary>
    public void AddNewCustomer()
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine();
        Console.Write("Problem: ");
        var problem = Console.ReadLine();

        // Guard against nulls and trim
        name = (name ?? string.Empty).Trim();
        accountId = (accountId ?? string.Empty).Trim();
        problem = (problem ?? string.Empty).Trim();

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    public void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("Error: Queue is empty");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
