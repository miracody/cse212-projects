using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n======================\nComplex Stack Solution\n======================");

        Console.WriteLine(ComplexStackSolution.CheckBraces("(a == 3 or (b == 5 and c == 6))")); // True
        Console.WriteLine(ComplexStackSolution.CheckBraces("(students]i].Grade > 80 and students[i].Grade < 90")); // False
        Console.WriteLine(ComplexStackSolution.CheckBraces("(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))")); // False
    }

    //CustomerServiceSolution.Run();
}

