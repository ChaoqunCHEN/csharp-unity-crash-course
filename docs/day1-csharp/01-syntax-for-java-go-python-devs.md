# 01. Syntax for Java / Go / Python Developers

## Concept

C# projects are usually organized as one or more `.csproj` files. Each project declares its target framework, dependencies, and compiler settings. `Program.cs` is a common entry point. Modern C# also supports top-level statements, so you may not see an explicit `Main` method.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

```csharp
namespace IdleGame.Domain;

public sealed class Enemy
{
    public Enemy(string id, int maxHealth)
    {
        Id = id;
        Health = new Health(maxHealth);
    }

    public string Id { get; }
    public Health Health { get; }
}
```

## Why It Matters

When reading a C# repo, first inspect `.csproj` files and `ProjectReference` relationships. That gives you the same kind of orientation as `go.mod`, Maven/Gradle modules, or Python package metadata.

## Comparisons

| C# | Java | Go | Python |
| --- | --- | --- | --- |
| `.csproj` | `pom.xml` / `build.gradle` | `go.mod` | `pyproject.toml` |
| `namespace` | `package` | package | module/package |
| `using` | `import` | `import` | `import` |
| `internal` | similar to package-private, but assembly-scoped | unexported name | `_private` convention |

## Common Traps

- C# file names do not have to match class names, but teams usually keep them aligned.
- Class members are `private` by default. Java's package-private default does not exist in the same way.
- Top-level statements hide `Main`, but the compiled program still has an entry point.
- `using` imports a namespace; it does not install a package.

## Example

```csharp
public static class DamageMath
{
    public static int ClampDamage(int amount)
    {
        return Math.Max(0, amount);
    }
}
```

Checkpoint: open `src/Day1.ConsolePlayground/Program.cs` and identify which types come from `IdleGame.Domain`.
