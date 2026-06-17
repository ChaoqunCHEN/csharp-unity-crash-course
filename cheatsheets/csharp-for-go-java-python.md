# C# for Go / Java / Python Cheatsheet

## Syntax

| Need | C# |
| --- | --- |
| Import namespace | `using System.Text;` |
| Namespace | `namespace MyApp.Domain;` |
| Class | `public sealed class Player { }` |
| Method | `public int Add(int a, int b) => a + b;` |
| Static method | `public static int Clamp(int value) { ... }` |
| Property | `public int Gold { get; private set; }` |
| Nullable reference | `string? name` |
| List | `List<string>` |
| Map/dict | `Dictionary<string, int>` |
| Set | `HashSet<string>` |
| Lambda | `x => x.Price > 10` |
| Async | `async Task<T>` |

## Mental Mappings

- Go `map[string]int` -> C# `Dictionary<string, int>`
- Python `list[str]` -> C# `List<string>`
- Java Stream `filter/map` -> C# LINQ `Where/Select`
- Java record -> C# `record`
- Python `None` -> C# `null`, but nullable analysis can warn you earlier
- Go error return -> C# often uses exceptions or `TryXxx` pattern

## LINQ Essentials

```csharp
items.Where(item => item.Price > 10)
items.Select(item => item.Name)
items.Sum(item => item.Amount)
items.Any(item => item.Id == "chest")
items.FirstOrDefault(item => item.Id == "key")
items.ToList()
```

## Traps

- `var` is not dynamic.
- `string` can still be null unless your code and annotations prevent it.
- `FirstOrDefault()` may return `null`.
- `async void` is mostly for event handlers.
- `event` can only be raised by the declaring type.
- In Unity, constructors are not where you initialize `MonoBehaviour` behavior.
