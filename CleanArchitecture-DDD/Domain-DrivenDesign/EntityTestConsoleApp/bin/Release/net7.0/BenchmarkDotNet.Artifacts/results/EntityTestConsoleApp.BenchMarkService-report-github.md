```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.403
  [Host]     : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2


```
| Method           | Mean     | Error     | StdDev    | Ratio | RatioSD |
|----------------- |---------:|----------:|----------:|------:|--------:|
| Equals           | 7.923 ns | 0.1836 ns | 0.2804 ns |  1.00 |    0.00 |
| IEquatableEquals | 5.091 ns | 0.1270 ns | 0.1512 ns |  0.64 |    0.04 |
