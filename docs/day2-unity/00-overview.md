# Day 2: Unity-Oriented C#

Day 2 takes the C# you learned on Day 1 and places it inside Unity's engine model. Unity code is still C#, but the control flow is different: the engine creates objects, calls lifecycle methods, serializes fields, runs scenes, and invokes UI events.

## Learning Path

1. Build the Unity mental model: GameObject + Component, Scene, Prefab, Inspector.
2. Learn MonoBehaviour lifecycle: `Awake`, `OnEnable`, `Start`, `Update`, `FixedUpdate`, `OnDisable`.
3. Work with GameObjects, components, prefabs, and scenes.
4. Use `[SerializeField]` and ScriptableObject for data.
5. Use input, `Update`, physics timing, and coroutines.
6. Bind UI, events, and JSON save/load.
7. Build Mini Idle Clicker.

## What You Will Build

Mini Idle Clicker:

- Player clicks an enemy.
- Enemy has health.
- Enemy death grants gold.
- Enemy death can drop a chest.
- Inventory tracks items.
- UI displays gold, enemy health, and items.
- Save/load persists local state.

## Run Model

The `.NET` tests do not validate Unity scripts. Unity validation is manual:

1. Create a Unity LTS 2D project.
2. Copy `unity/MiniIdleClicker/Assets/Scripts` into `Assets/Scripts`.
3. Follow `unity/MiniIdleClicker/README.md`.
4. Press Play and wire missing Inspector references if Unity reports them.

Checkpoint: before writing any Unity code, explain why `new GameManager()` is the wrong way to create a `MonoBehaviour`.
