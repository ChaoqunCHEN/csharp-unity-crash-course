namespace Exercises.Day1.Solution;

public sealed class Inventory
{
    private readonly Dictionary<string, int> items = new(StringComparer.Ordinal);

    public void Add(string itemId, int amount = 1)
    {
        Validate(itemId, amount);
        items[itemId] = CountOf(itemId) + amount;
    }

    public bool Remove(string itemId, int amount = 1)
    {
        Validate(itemId, amount);
        var current = CountOf(itemId);
        if (current < amount)
        {
            return false;
        }

        var remaining = current - amount;
        if (remaining == 0)
        {
            items.Remove(itemId);
        }
        else
        {
            items[itemId] = remaining;
        }

        return true;
    }

    public int CountOf(string itemId)
    {
        if (string.IsNullOrWhiteSpace(itemId))
        {
            throw new ArgumentException("Item id cannot be empty.", nameof(itemId));
        }

        return items.TryGetValue(itemId, out var count) ? count : 0;
    }

    private static void Validate(string itemId, int amount)
    {
        if (string.IsNullOrWhiteSpace(itemId))
        {
            throw new ArgumentException("Item id cannot be empty.", nameof(itemId));
        }

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
    }
}
