# 06. UI, Events, and Save/Load

## UI Binding

Small Unity projects can use direct references:

```csharp
[SerializeField] private TMP_Text goldText;
[SerializeField] private Button attackButton;
```

Subscribe in `OnEnable`, unsubscribe in `OnDisable`:

```csharp
private void OnEnable()
{
    attackButton.onClick.AddListener(Attack);
}

private void OnDisable()
{
    attackButton.onClick.RemoveListener(Attack);
}
```

## UnityEvent vs C# Event

Use `UnityEvent` / Inspector button bindings when designers need to wire behavior visually. Use C# events for code-owned domain events.

Mini Idle Clicker uses:

- Button `onClick` for UI.
- C# events for health and inventory changes.

## JSON Save/Load

Unity has built-in `JsonUtility`. It is fast and simple but limited. Save plain DTOs, not GameObjects or Sprites.

```csharp
[Serializable]
public sealed class GameSaveData
{
    public int gold;
    public List<InventoryStack> inventory = new List<InventoryStack>();
    public string savedAtUtc = "";
}
```

Use:

```csharp
Application.persistentDataPath
```

Do not assume the project directory is writable at runtime, especially on macOS.

## Common Traps

- `JsonUtility` does not serialize arbitrary dictionaries directly.
- UI references must be wired in the Inspector unless you find them in code.
- TextMeshPro may ask to import essentials the first time you use it.
- Save data should be versioned in real projects. For Day 2, keep it simple.

Exercise: add `lastSavedAt` text to the UI and update it after saving.
