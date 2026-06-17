# 04. OOP, Interfaces, Generics, Extension Methods

## Concept

C# 支持完整 OOP，但 Unity 和游戏逻辑都更偏向组合。先用 interface 表达能力，再用小类组合行为。

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

泛型约束让编译器知道 `T` 有什么能力：

```csharp
public static T Create<T>() where T : new()
{
    return new T();
}
```

## Extension Methods

扩展方法让静态方法看起来像实例方法：

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

普通分支优先用 `TryParse`，异常用于异常路径。

## Common Traps

- 扩展方法不能访问 private 成员，也没有真的修改原类型。
- `catch (Exception)` 太宽，容易吞掉重要错误。
- `where T : class` 表示 reference type，`where T : struct` 表示 value type。
- `sealed` 禁止继承，常用于简单 domain class，减少意外扩展点。

Exercise：给 `IReadOnlyDictionary<string, int>` 写扩展方法 `TotalItems()`，返回所有数量之和。
