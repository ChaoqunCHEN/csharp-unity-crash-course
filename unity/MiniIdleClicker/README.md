# Mini Idle Clicker Unity Scripts

This folder is not a full Unity Editor project. It is a script mini-project that you can copy into a Unity LTS 2D project. CI does not launch Unity.

## macOS Setup

1. Install Unity Hub.
2. Sign in and activate a Personal or Pro license.
3. Install Unity LTS. On Apple Silicon Macs, prefer the Apple Silicon editor. On Intel Macs, choose the Intel editor. Add iOS/Android modules only if you need them.
4. Create a 2D Core project named `MiniIdleClicker`.
5. In Unity, create folders:

```text
Assets/
  Scripts/
  ScriptableObjects/
  Prefabs/
  Scenes/
```

6. Copy this repo's `unity/MiniIdleClicker/Assets/Scripts` files into the Unity project's `Assets/Scripts`.
7. If macOS blocks Unity Hub or Unity Editor on first launch, open System Settings -> Privacy & Security and allow it.
8. Avoid putting Unity projects in iCloud or Dropbox synced folders.

## Scene Setup

1. Create a scene: `Assets/Scenes/MiniIdleClicker.unity`.
2. Create a `Canvas` and add:
   - `GoldText`: TextMeshProUGUI
   - `ItemsText`: TextMeshProUGUI
   - `EnemyHealthText`: TextMeshProUGUI
   - `AttackButton`: Button
   - `SaveButton`: Button
   - `LoadButton`: Button
3. Create an empty `GameManager` object and attach `GameManager.cs`.
4. Create an empty `Enemy` object and attach `Health.cs` and `Enemy.cs`.
5. In the Inspector, wire the UI fields, buttons, enemy, inventory, player controller, and item definitions into `GameManager`.
6. In the Project window, use Create -> Idle Clicker -> Item Definition to create items such as:
   - `SmallChest`, with a low drop chance through a drop table
   - `Potion`
7. Press Play. Click Attack. Enemy death grants gold and can drop an item.

## Common macOS Unity Issues

- First launch may trigger Gatekeeper or security prompts.
- Unity Hub requires login and license activation.
- Apple Silicon Macs should usually use the native editor; old plugins may require Rosetta.
- Keep asset, script, and class names case-consistent. CI/Linux can be case-sensitive.
- If double-clicking scripts does nothing, reset External Script Editor in Unity preferences.
- JSON save files should go under `Application.persistentDataPath`; do not assume the project directory is writable at runtime.
