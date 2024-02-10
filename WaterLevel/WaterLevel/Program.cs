using System;
using System.Linq;
using System.Collections.Generic;


void Main()
{
    int level = 10;
    int[] A = [15,5,10,10,5,10,11,11,11,11,11];

    if (A.Length * level != A.Sum())
    {
        Console.WriteLine($"The level can not be calculated... sum: {A.Sum()}, mul: {A.Length * level} ");
        return;
    }
    var containers = A.Select((a, index) => new Container { Index = index, Value = a }).ToList();
    SetSameLevel(containers, level, true);
    containers = A.Select((a, index) => new Container { Index = index, Value = a }).ToList();
    SetSameLevel(containers, level, false);
}

void SetSameLevel(List<Container> containers, int level, bool isMinDistance = true)
{
    var counter = 0;
    if (isMinDistance)
    {
        Console.WriteLine($"Min distance");
    }
    else
    {
        Console.WriteLine($"Max distance");
    }

    Print(containers);
    while (containers.Where(c => c.Value == level).Count() != containers.Count())
    {
        var ctn = Move(containers, level, isMinDistance);
        Print(containers);
        Console.WriteLine($"({ctn})");
        counter += ctn;
    }
    Console.WriteLine($"Total:({counter})");
}

int Move(List<Container> containers, int level, bool isMinDistance = true)
{
    var maxs = containers.Where(c => c.Value == containers.Max(m => m.Value));
    var mins = containers.Where(c => c.Value == containers.Min(m => m.Value));

    Container minResult = new Container();
    Container maxResult = new Container();

    var distance = isMinDistance ? int.MaxValue : int.MinValue;
    foreach (Container max in maxs)
    {
        foreach (Container min in mins)
        {
            if (isMinDistance && Math.Abs(max.Index - min.Index) < distance
                || !isMinDistance && Math.Abs(max.Index - min.Index) > distance)
            {
                maxResult = max;
                minResult = min;
                distance = Math.Abs(max.Index - min.Index);
            }
        }
    }
    var maxDiff = maxResult.Value - level;
    var minDiff = level - minResult.Value;

    if (maxDiff < minDiff)
    {
        minResult.Value += maxDiff;
        maxResult.Value -= maxDiff;
    }
    else
    {
        minResult.Value += minDiff;
        maxResult.Value -= minDiff;
    }
    return distance;
}

void Print(List<Container> containers)
{
    var result = $"[{string.Join(",", containers.Select(c => c.Value).ToArray())}]";
    Console.WriteLine(result);
}

Main();

public class Container
{
    public int Index { get; set; }
    public int Value { get; set; }
}

