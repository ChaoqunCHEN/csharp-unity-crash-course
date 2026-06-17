# 04. Serialized Fields and ScriptableObject

## Serialized Fields

Unity serializes fields, not ordinary C# properties. The common pattern is:

```csharp
[SerializeField] private int goldReward = 5;
public int GoldReward => goldReward;
```

You get Inspector editing without exposing write access to every other script.

## ScriptableObject

ScriptableObject is good for static, reusable data:

- item definitions
- enemy definitions
- drop tables
- upgrade definitions
- balance constants

```csharp
[CreateAssetMenu(menuName = "Idle Clicker/Item Definition")]
public sealed class ItemDefinition : ScriptableObject
{
    [SerializeField] private string id = "small_chest";
    [SerializeField] private string displayName = "Small Chest";
    [SerializeField] private int goldValue = 10;

    public string Id => id;
    public string DisplayName => displayName;
    public int GoldValue => goldValue;
}
```

## Why It Matters

ScriptableObjects let you tune data without recompiling code. They also prevent hardcoding everything into one giant `GameManager`.

## Runtime State vs Definition Data

Good ScriptableObject data:

- "Small chest has id `small_chest`."
- "Small chest is worth 10 gold."
- "Rare chest drop weight is 5."

Bad ScriptableObject state:

- "The player currently owns 3 chests."
- "This enemy currently has 2 HP."

Runtime state belongs in scene objects, save data, or pure domain objects.

Common traps:

- Mutating ScriptableObject assets at runtime can persist surprising values in the editor.
- Unity serialization is not the same as `System.Text.Json` or Newtonsoft JSON.
- Private fields need `[SerializeField]`; properties do not appear by default.

Exercise: create two `ItemDefinition` assets and assign them to a `DropTable`.
