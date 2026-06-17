# 05. Async/Await, Delegates, and Events

## Async / Await

`Task` 表示异步操作，`Task<T>` 表示异步返回值：

```csharp
public async Task<PlayerProfile> LoadProfileAsync(string playerId)
{
    await Task.Delay(150);
    return new PlayerProfile(playerId, "Ada", Gold: 120);
}
```

`await` 不等于“启动线程”。它表达“异步等待结果”，非常适合 IO。Unity 核心 gameplay loop 通常先用 `Update` / coroutine，不急着上 `async`。

Common traps：

- 忘记 `await` 会得到未完成的 `Task`。
- 普通异步方法避免 `async void`；它主要用于事件处理。
- `.Result` / `.Wait()` 会阻塞线程，某些环境可能死锁。
- 异步异常在 `await` 时重新抛出。

## Delegate / Action / Func

```csharp
Func<int, int, int> add = (a, b) => a + b;
Action<string> log = message => Console.WriteLine(message);
```

delegate 是类型安全的函数引用。`Action` 无返回值，`Func` 有返回值。

## Event

`event` 是受控发布订阅：

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

外部可以订阅和取消订阅，但不能随意触发事件。

```csharp
health.Changed += (_, current) => Console.WriteLine($"hp={current}");
health.Died += (_, _) => Console.WriteLine("dead");
```

## Why It Matters

Unity UI、按钮、生命周期订阅、gameplay 事件都会用到 delegate/event 思维。AI 生成 Unity 代码时常混用 C# event 和 UnityEvent，你需要知道边界。

Common traps：

- `event` 只能在声明它的类型内部触发。
- 长生命周期对象订阅短生命周期对象时，记得取消订阅。
- lambda 会捕获变量，循环里捕获要特别小心。

Exercise：修改 console playground，让敌人死亡后通过事件给 inventory 加一个 `chest`。
