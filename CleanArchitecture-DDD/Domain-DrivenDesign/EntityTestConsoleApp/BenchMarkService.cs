using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestConsoleApp;

public class BenchMarkService
{
    [Benchmark(Baseline = true)]
    public bool Equals()
    {
        B b1 = new(1);
        B b2 = new(1);
        return b1.Equals(b2);
    }

    [Benchmark]
    public bool IEquatableEquals()
    {
        A a1 = new(1);
        A a2 = new(1);
        return a1.Equals(a2);
    }
}