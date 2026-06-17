namespace IdleGame.Domain;

public sealed class WeightedDropTable<T>
{
    private readonly List<DropEntry<T>> _entries = [];
    private double _totalWeight;

    public WeightedDropTable<T> Add(T item, double weight)
    {
        if (weight <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be positive.");
        }

        _entries.Add(new DropEntry<T>(item, weight));
        _totalWeight += weight;
        return this;
    }

    public T Roll(Random rng)
    {
        if (_entries.Count == 0)
        {
            throw new InvalidOperationException("Cannot roll an empty drop table.");
        }

        var target = rng.NextDouble() * _totalWeight;
        var cursor = 0.0;

        foreach (var entry in _entries)
        {
            cursor += entry.Weight;
            if (target < cursor)
            {
                return entry.Item;
            }
        }

        return _entries[^1].Item;
    }

    public IReadOnlyList<DropEntry<T>> Entries => _entries;
}

public sealed record DropEntry<T>(T Item, double Weight);
