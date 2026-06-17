# 03. GameObject, Component, Prefab, Scene

## Concept

Unity development is partly code and partly editor wiring. The script defines the component. The scene or prefab decides where it lives and what references it has.

## Component Access

```csharp
private Health health;

private void Awake()
{
    health = GetComponent<Health>();
}
```

Cache component references in `Awake` when you need them repeatedly.

## Serialized References

```csharp
[SerializeField] private Enemy targetEnemy;
```

This field appears in the Inspector. Drag an `Enemy` object into it. The field can stay private, preserving a sane public API.

## Prefab Workflow

Use prefabs when you need repeatable object structure:

1. Create a GameObject in the scene.
2. Add components and child objects.
3. Drag it into `Assets/Prefabs`.
4. Instantiate or place prefab instances as needed.

## Scene Workflow

For Mini Idle Clicker:

- `GameManager` object owns high-level coordination.
- `Enemy` object owns `Health` and reward/drop behavior.
- `Canvas` owns UI text and buttons.
- ScriptableObject assets define static item data.

## Common Traps

- Renaming a MonoBehaviour class without renaming the file can break script attachment.
- Scene references point to scene objects; prefab asset references should not accidentally point to temporary scene-only objects.
- Do not put runtime player state into prefab assets.

Checkpoint: why is `ItemDefinition` a ScriptableObject but `Inventory` a MonoBehaviour?
