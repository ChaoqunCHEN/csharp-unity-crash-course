# 05. Async/Await, Delegates, and Events

## Async / Await

`Task` represents an asynchronous operation. `Task<T>` represents an asynchronous operation that returns a value:

```csharp
public async Task<PlayerProfile> LoadProfileAsync(string playerId)
{
    await Task.Delay(150);
    return new PlayerProfile(playerId, "Ada", Gold: 120);
}
```

`await` does not mean "start a thread." It means "asynchronously wait for this result." It is excellent for IO. In Unity gameplay code, start with `Update` and coroutines before reaching for `async`.

Common traps:

- Forgetting `await` leaves you with an unfinished `Task`.
- Avoid `async void` except for event handlers.
- `.Result` and `.Wait()` block threads and can deadlock in some environments.
- Async exceptions are re-thrown when you `await`.

## Delegate / Action / Func

```csharp
Func<int, int, int> add = (a, b) => a + b;
Action<string> log = message => Console.WriteLine(message);
```

A delegate is a type-safe function reference. `Action` has no return value. `Func` returns a value.

## Event

`event` is controlled publish/subscribe:

```csharp
public sealed class Health
{
    public event EventHandler<int>? Changed;
    public event EventHandler? Died;

    private void RaiseChanged(int current)
    {
        Changed?.Invoke(this, current);
    }
}
```

External code can subscribe and unsubscribe, but it cannot raise the event directly.

```csharp
health.Changed += (_, current) => Console.WriteLine($"hp={current}");
health.Died += (_, _) => Console.WriteLine("dead");
```

## Why It Matters

Unity UI, buttons, lifecycle subscriptions, and gameplay events all use delegate/event thinking. AI-generated Unity code often mixes C# events and UnityEvents; you need to know the boundary.

Common traps:

- An `event` can only be raised by the type that declares it.
- Unsubscribe when a long-lived object subscribes to a shorter-lived object.
- Lambdas capture variables; be careful inside loops.

Exercise: change the console playground so enemy death grants a `chest` through an event handler.
