using BenchmarkDotNet.Running;

namespace EntityTestConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<BenchMarkService>();
        //A a1 = new(1);
        //A a2 = new(1);
        //Console.WriteLine(a1.Equals(a2));

        //HashSet<int> numbers = new();

        //numbers.Add(1);
        //numbers.Add(2);
        //numbers.Add(2);
        //numbers.Add(3);
        //numbers.Add(4);
        //numbers.Add(5);

        //foreach (var item in numbers)
        //{
        //    Console.WriteLine(item);
        //}

        Console.ReadLine();
    }
}

public class B
{
    public int Id { get; init; }

    public B(int id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        if (obj is not A a) return false;

        return a.Id == Id;
    }
}

public class A : IEquatable<A>
{
    public int Id { get; init; }

    public A(int id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        if (obj is not A a) return false;

        return a.Id == Id;
    }

    public bool Equals(A? other)
    {
        if (other is null) return false;

        if (other.GetType() != GetType()) return false;

        if (other is not A a) return false;

        return a.Id == Id;
    }
}