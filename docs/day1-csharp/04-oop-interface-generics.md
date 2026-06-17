# 04. OOP, Interfaces, Generics, Extension Methods

## Concept

C# supports full OOP, but both Unity and game domain code often work best with composition. Use interfaces to express capabilities, then compose small classes.

```csharp
public interface IDamageable
{
    void TakeDamage(int amount);
}

public sealed class Health : IDamageable
{
    public int Current { get; private set; }

    public void TakeDamage(int amount)
    {
        Current = Math.Max(0, Current - amount);
    }
}
```

## Generics

```csharp
public sealed class Result<T>
{
    private Result(T? value, string? error)
    {
        Value = value;
        Error = error;
    }

    public T? Value { get; }
    public string? Error { get; }
    public bool IsOk => Error is null;

    public static Result<T> Ok(T value) => new(value, null);
    public static Result<T> Fail(string error) => new(default, error);
}
```

Generic constraints tell the compiler what `T` can do:

```csharp
public static T Create<T>() where T : new()
{
    return new T();
}
```

## Extension Methods

Extension methods let static methods read like instance methods:

```csharp
public static class StringExtensions
{
    public static bool IsMissing(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
}
```

## Exceptions

```csharp
try
{
    var amount = int.Parse(input);
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid number: {ex.Message}");
}
```

Prefer `TryParse` for normal branchy parsing. Use exceptions for exceptional paths.

## Common Traps

- Extension methods cannot access private members and do not actually modify the original type.
- `catch (Exception)` is often too broad and can hide important failures.
- `where T : class` means reference type; `where T : struct` means value type.
- `sealed` prevents inheritance. It is useful for simple domain classes with no intended extension point.

Exercise: write an extension method `TotalItems()` for `IReadOnlyDictionary<string, int>` that returns the sum of all counts.
