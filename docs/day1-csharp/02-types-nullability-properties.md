# 02. Types, Nullability, and Properties

## Concept

C# 是静态类型语言。`var` 只是编译期类型推断：

```csharp
var score = 100;      // int
var name = "Ada";     // string
// score = "100";     // compile error
```

常见数值类型：

- `int` / `long`：整数。
- `float`：Unity 中很常见，字面量写 `1.5f`。
- `double`：默认浮点类型。
- `decimal`：适合金额，不适合 Unity 高频数值。
- `bool`、`char`、`string`。

## Nullable Reference Types

开启 `<Nullable>enable</Nullable>` 后：

```csharp
string name = "Ada";       // should not be null
string? nickname = null;   // may be null

var label = nickname ?? "Guest";
var firstChar = nickname?.FirstOrDefault();
```

`?` 是告诉编译器“这里可能为空”。`!` 是告诉编译器“相信我不为空”，不是运行时检查。

## Properties vs Fields

C# property 表面像字段，实际是 getter/setter：

```csharp
public sealed class Player
{
    public string Name { get; }
    public int Gold { get; private set; }

    public Player(string name)
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException("Name is required.", nameof(name))
            : name;
    }

    public void AddGold(int amount) => Gold += amount;
}
```

Unity 脚本里常见 private field + `[SerializeField]`，普通 C# domain code 更常见 property。

## Records and Enums

```csharp
public sealed record ItemReward(string ItemId, int Amount);

public enum DamageType
{
    Physical,
    Fire,
    Ice
}
```

`record` 适合不可变数据和值语义，接近 Java record / Kotlin data class。

## Common Traps

- `string` 仍然是 reference type；nullable 分析不改变运行时。
- `List<string?>` 和 `List<string>?` 不一样：前者元素可空，后者列表本身可空。
- `enum` 底层是整数，可能出现未定义值，处理外部输入时要校验。
- Unity Inspector 不序列化普通 C# property，通常序列化 field。

Exercise：写一个 `record UpgradeDefinition(string Id, int BaseCost, float Multiplier)`，再创建 3 个升级配置。
