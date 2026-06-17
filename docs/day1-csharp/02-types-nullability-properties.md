# 02. Types, Nullability, and Properties

## Concept

C# is statically typed. `var` is compile-time type inference:

```csharp
var score = 100;      // int
var name = "Ada";     // string
// score = "100";     // compile error
```

Common primitive types:

- `int` / `long`: integers.
- `float`: common in Unity; write literals as `1.5f`.
- `double`: default floating-point type.
- `decimal`: useful for money-like values, not typical Unity gameplay math.
- `bool`, `char`, `string`.

## Nullable Reference Types

With `<Nullable>enable</Nullable>`:

```csharp
string name = "Ada";       // expected non-null
string? nickname = null;   // may be null

var label = nickname ?? "Guest";
var firstChar = nickname?.FirstOrDefault();
```

`?` tells the compiler that a reference may be null. `!` tells the compiler "trust me"; it is not a runtime null check.

## Properties vs Fields

C# properties look like fields from the outside, but they are getter/setter methods:

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

Plain C# domain code usually favors properties. Unity Inspector code often uses private fields with `[SerializeField]`.

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

Records are good for immutable data and value-like equality, similar to Java records or Kotlin data classes.

## Common Traps

- `string` is still a reference type; nullable analysis does not change runtime behavior.
- `List<string?>` and `List<string>?` mean different things. The first allows null elements; the second allows the list itself to be null.
- `enum` values are backed by integers. External input can contain undefined enum values unless you validate it.
- Unity Inspector does not serialize normal C# properties; it serializes fields.

Exercise: write `record UpgradeDefinition(string Id, int BaseCost, float Multiplier)` and create three upgrade definitions.
