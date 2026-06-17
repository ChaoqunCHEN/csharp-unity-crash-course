namespace IdleGame.Domain;

public sealed class Inventory
{
    private readonly Dictionary<string, int> _items = new(StringComparer.Ordinal);

    public void Add(string itemId, int amount = 1)
    {
        ValidateItemId(itemId);
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
        }

        _items[itemId] = CountOf(itemId) + amount;
    }

    public bool Remove(string itemId, int amount = 1)
    {
        ValidateItemId(itemId);
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
        }

        var current = CountOf(itemId);
        if (current < amount)
        {
            return false;
        }

        var remaining = current - amount;
        if (remaining == 0)
        {
            _items.Remove(itemId);
        }
        else
        {
            _items[itemId] = remaining;
        }

        return true;
    }

    public int CountOf(string itemId)
    {
        ValidateItemId(itemId);
        return _items.TryGetValue(itemId, out var count) ? count : 0;
    }

    public IReadOnlyDictionary<string, int> Snapshot()
    {
        return new Dictionary<string, int>(_items, StringComparer.Ordinal);
    }

    private static void ValidateItemId(string itemId)
    {
        if (string.IsNullOrWhiteSpace(itemId))
        {
            throw new ArgumentException("Item id cannot be empty.", nameof(itemId));
        }
    }
}
