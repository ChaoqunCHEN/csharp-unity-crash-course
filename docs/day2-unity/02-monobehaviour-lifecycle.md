# 02. MonoBehaviour Lifecycle

## Concept

Unity calls your script methods. You do not own the main loop.

Common lifecycle methods:

- `Awake`: object is loaded. Cache local components and initialize self-contained state.
- `OnEnable`: object becomes enabled. Subscribe to events here.
- `Start`: before the first frame update. Use when other objects should already be initialized.
- `Update`: every frame. Use for input and lightweight per-frame state.
- `FixedUpdate`: fixed timestep. Use for physics.
- `OnDisable`: object becomes disabled. Unsubscribe from events here.
- `OnDestroy`: object is destroyed. Release external resources if needed.

## Example

```csharp
private void Awake()
{
    health = GetComponent<Health>();
}

private void OnEnable()
{
    health.Died += HandleDied;
}

private void OnDisable()
{
    health.Died -= HandleDied;
}
```

## Why It Matters

Most Unity bugs are not syntax bugs. They are timing bugs:

- A field was not wired before `Start`.
- A component was fetched every frame instead of cached.
- An event was subscribed twice.
- An object was disabled but still expected to receive events.

## Common Traps

- Constructors are not the normal place to initialize MonoBehaviour logic.
- `Update` runs every frame; avoid expensive searches such as `GameObject.Find`.
- Pair `OnEnable` subscriptions with `OnDisable` unsubscriptions.
- `FixedUpdate` is for physics, not a general "more stable Update."

Exercise: add a `Debug.Log` to each lifecycle method in a test script and observe the order in Play Mode.
