# Day 1: C# Crash Course

Today is not about learning programming from scratch. It is about mapping your Go / Python / Java experience onto C# quickly enough that you can read real code, write small features, and review AI-generated C# with a clear head.

## Learning Path

1. Project structure: `dotnet`, `.csproj`, namespaces, classes, methods.
2. Type system: `var`, primitive types, strings, nullable reference types.
3. Data modeling: properties, constructors, records, enums.
4. Collections and LINQ: `List<T>`, `Dictionary<TKey,TValue>`, `Where`, `Select`, `Sum`.
5. Abstraction and reuse: interfaces, generics, extension methods, exceptions.
6. Async and events: `async` / `await`, `Task`, delegates, `Action`, `Func`, event.
7. Exercises: inventory, weighted drop table, offline rewards, fake API call, health events.

## Run the Examples

```bash
dotnet run --project src/Day1.ConsolePlayground
dotnet test src/IdleGame.Tests
```

## The Day 1 Mental Model

- C# often feels like Java with stronger syntax ergonomics: properties, LINQ, records, delegates, nullable analysis.
- `var` is static type inference, not dynamic typing.
- Nullable reference types are compiler analysis, not runtime magic.
- Unity uses C#, but Unity's runtime model is engine-driven, not a normal server or CLI app.

Checkpoint: read [01-syntax-for-java-go-python-devs.md](01-syntax-for-java-go-python-devs.md), then run the console playground.
