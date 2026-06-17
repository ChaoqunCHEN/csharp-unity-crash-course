namespace Exercises.Day1.Solution;

public sealed class WeightedDropTable<T>
{
    private readonly List<(T Item, double Weight)> entries = [];
    private double totalWeight;

    public WeightedDropTable<T> Add(T item, double weight)
    {
        if (weight <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weight));
        }

        entries.Add((item, weight));
        totalWeight += weight;
        return this;
    }

    public T Roll(Random rng)
    {
        if (entries.Count == 0)
        {
            throw new InvalidOperationException("Drop table is empty.");
        }

        var target = rng.NextDouble() * totalWeight;
        var cursor = 0.0;

        foreach (var entry in entries)
        {
            cursor += entry.Weight;
            if (target < cursor)
            {
                return entry.Item;
            }
        }

        return entries[^1].Item;
    }
}
