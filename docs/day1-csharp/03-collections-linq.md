# 03. Collections and LINQ

## Concept

常用集合：

```csharp
var scores = new int[] { 10, 20, 30 };
var items = new List<string> { "gold", "chest" };
var counts = new Dictionary<string, int>();
var seen = new HashSet<string>();
```

泛型写法 `List<T>` 和 Java 类似，比 Go 传统 slice/map 更强调库类型。

## LINQ

LINQ 是 C# 的集合查询工具。常用方法：

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

AI 生成 C# 时很爱用 LINQ。你需要能读懂链式查询，也要知道什么时候不要用。

## Comparisons

- `Where` 类似 Python `filter` / Java Stream `filter`。
- `Select` 类似 Python map/list comprehension / Java Stream `map`。
- `IEnumerable<T>` 很多时候是延迟执行，接近 Java Stream 的懒计算。

## Common Traps

- `First()` 找不到会抛异常；`FirstOrDefault()` 对 reference type 可能返回 `null`。
- LINQ 默认延迟执行，反复枚举可能反复计算。
- 不要修改正在 `foreach` 的集合。
- Unity `Update()` 里避免频繁 LINQ，可能产生 GC allocation。

Exercise：在 `Inventory.Snapshot()` 上用 LINQ 找出数量大于 1 的物品 ID。
