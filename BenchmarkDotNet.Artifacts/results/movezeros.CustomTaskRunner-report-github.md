``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 3600X, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


```
|         Method |     Mean |    Error |   StdDev |
|--------------- |---------:|---------:|---------:|
| ExecuteSample1 | 79.41 ns | 0.435 ns | 0.364 ns |
| ExecuteSample2 | 26.97 ns | 0.345 ns | 0.323 ns |
| ExecuteSample3 | 21.58 ns | 0.226 ns | 0.201 ns |
