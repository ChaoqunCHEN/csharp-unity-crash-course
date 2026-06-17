# 01. Syntax for Java / Go / Python Devs

## Concept

C# 项目通常由一个或多个 `.csproj` 组成。每个项目声明目标框架、依赖和编译设置。`Program.cs` 是常见入口；现代 C# 可以使用 top-level statements，不一定显式写 `Main`。

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

读 C# 仓库时，先看 `.csproj` 和项目之间的 `ProjectReference`。这相当于先搞清楚 Go module / Java Maven module / Python package 的边界。

## Comparisons

| C# | Java | Go | Python |
| --- | --- | --- | --- |
| `.csproj` | `pom.xml` / `build.gradle` | `go.mod` | `pyproject.toml` |
| `namespace` | `package` | package | module/package |
| `using` | `import` | `import` | `import` |
| `internal` | package-private 接近但不相同 | unexported name | `_private` convention |

## Common Traps

- C# 文件名不强制等于类名，但团队通常保持一致。
- 类成员默认是 `private`；Java 的默认 package-private 在 C# 里不是默认行为。
- top-level statements 隐藏了 `Main`，但程序仍然有入口。
- `using` 是导入 namespace，不代表依赖已经被包管理器安装。

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

Checkpoint：打开 `src/Day1.ConsolePlayground/Program.cs`，找出哪些类型来自 `IdleGame.Domain`。
