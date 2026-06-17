# 03. Collections and LINQ

## Concept

Common collection types:

```csharp
var scores = new int[] { 10, 20, 30 };
var items = new List<string> { "gold", "chest" };
var counts = new Dictionary<string, int>();
var seen = new HashSet<string>();
```

Generic syntax such as `List<T>` is close to Java. Compared with Go slices/maps, C# leans more heavily on library collection types and LINQ extension methods.

## LINQ

LINQ is C#'s collection query toolkit:

```csharp
var enemies = new List<Enemy>
{
    new("slime", maxHealth: 10, goldReward: 3),
    new("bat", maxHealth: 6, goldReward: 2),
    new("boss", maxHealth: 100, goldReward: 50)
};

var richEnemies = enemies
    .Where(enemy => enemy.GoldReward >= 3)
    .Select(enemy => enemy.Id)
    .ToList();

var totalGold = enemies.Sum(enemy => enemy.GoldReward);
var hasBoss = enemies.Any(enemy => enemy.Id == "boss");
var firstSmallEnemy = enemies.FirstOrDefault(enemy => enemy.GoldReward < 3);
```

## Why It Matters

AI-generated C# often uses LINQ. You need to read it fluently and know when to avoid it.

## Comparisons

- `Where` is similar to Python `filter` or Java Stream `filter`.
- `Select` is similar to Python `map` / list comprehensions or Java Stream `map`.
- Many LINQ calls return `IEnumerable<T>` and are lazy, similar to Java streams.

## Common Traps

- `First()` throws if nothing matches; `FirstOrDefault()` may return `null` for reference types.
- Lazy LINQ queries can re-run work each time you enumerate them.
- Modifying a collection while iterating it usually throws.
- Avoid frequent LINQ allocations inside Unity `Update()`.

Exercise: use LINQ on `Inventory.Snapshot()` to find item IDs whose count is greater than 1.
