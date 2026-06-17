# Day 1: C# Crash Course

今天的目标：你不需要“从零学编程”，你需要把已有的 Go / Python / Java 经验映射到 C#，能读懂项目、能写小功能、能让 AI 生成的 C# 代码不至于失控。

## 学习路径

1. 项目结构与入口：`dotnet`、`.csproj`、namespace、class、method。
2. 类型系统：`var`、基础类型、字符串、nullable reference types。
3. 数据建模：property、constructor、record、enum。
4. 集合与 LINQ：`List<T>`、`Dictionary<TKey,TValue>`、`Where`、`Select`、`Sum`。
5. 抽象与复用：interface、generics、extension methods、exceptions。
6. 异步与事件：`async` / `await`、`Task`、delegate、`Action`、`Func`、event。
7. 练习：inventory、weighted drop table、offline reward、fake API、health event。

## 运行示例

```bash
dotnet run --project src/Day1.ConsolePlayground
dotnet test src/IdleGame.Tests
```

## 今天的心法

- C# 很像 Java，但属性、LINQ、nullable reference types、delegate/event 会改变代码风格。
- C# 的 `var` 是静态类型推断，不是 Python 的动态变量。
- Unity 里大量 API 是 C#，但运行模型不是普通后端服务：生命周期由 Editor 和 Engine 驱动。

Checkpoint：先浏览 [01-syntax-for-java-go-python-devs.md](01-syntax-for-java-go-python-devs.md)，再运行 console playground。
