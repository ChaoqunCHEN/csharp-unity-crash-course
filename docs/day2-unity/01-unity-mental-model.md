# 01. Unity Mental Model

## Concept

Unity scenes are object graphs. A `GameObject` is a container in that graph. Behavior and data come from components attached to GameObjects.

```text
GameObject: Enemy
  Transform
  Health
  Enemy

GameObject: GameManager
  GameManager

GameObject: Canvas
  Button
  TMP_Text
```

## GameObject + Component

- `GameObject`: name, active state, tag, layer, hierarchy, and a required `Transform`.
- `Component`: behavior or data attached to a GameObject.
- `MonoBehaviour`: your usual script component base class.

This is composition-first. Instead of making `Enemy : Health : DropTable`, attach `Health` and `Enemy` components to the same GameObject.

## Scene

A Scene saves a runtime object graph: hierarchy, cameras, UI, lighting, serialized field references, and component settings.

Common beginner workflow:

1. Create a scene.
2. Add objects.
3. Attach scripts.
4. Wire serialized fields in the Inspector.
5. Press Play.

## Prefab

A Prefab is a reusable GameObject template. Use prefabs for enemies, item rows, projectiles, UI panels, and pickups.

Prefab instances can override values. Changing the prefab asset can update all instances.

## Inspector

The Inspector is Unity's object editor. Public fields show by default, but do not make fields public only for Inspector access. Prefer:

```csharp
[SerializeField] private int goldReward = 5;
public int GoldReward => goldReward;
```

## Common Traps

- Do not create MonoBehaviours with `new`.
- Missing Inspector references are normal early errors; wire the field or add runtime validation.
- Unity's `null` for destroyed objects is special because `UnityEngine.Object` overloads equality.
- Script file name and class name should match for MonoBehaviour scripts.

Checkpoint: inspect `unity/MiniIdleClicker/Assets/Scripts/GameManager.cs` and list which fields must be wired in the Inspector.
