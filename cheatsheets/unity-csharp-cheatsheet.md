# Unity C# Cheatsheet

## Core Types

| Need | Unity C# |
| --- | --- |
| Script component | `public sealed class Foo : MonoBehaviour` |
| Inspector private field | `[SerializeField] private int value;` |
| Current object transform | `transform.position` |
| Get sibling component | `GetComponent<Health>()` |
| Per-frame callback | `Update()` |
| Physics callback | `FixedUpdate()` |
| Subscribe while enabled | `OnEnable()` |
| Unsubscribe while disabled | `OnDisable()` |
| Time-scaled frame delta | `Time.deltaTime` |
| Save path | `Application.persistentDataPath` |

## Lifecycle

```csharp
private void Awake() { }
private void OnEnable() { }
private void Start() { }
private void Update() { }
private void FixedUpdate() { }
private void OnDisable() { }
private void OnDestroy() { }
```

## Inspector Pattern

```csharp
[SerializeField] private Enemy enemy;
public Enemy Enemy => enemy;
```

## Button Binding

```csharp
private void OnEnable()
{
    button.onClick.AddListener(HandleClick);
}

private void OnDisable()
{
    button.onClick.RemoveListener(HandleClick);
}
```

## Performance Traps

- Do not use `GameObject.Find` in `Update`.
- Cache repeated `GetComponent` calls.
- Avoid LINQ in hot loops.
- Avoid rebuilding UI every frame.
- Do not store runtime player state in ScriptableObject assets.
