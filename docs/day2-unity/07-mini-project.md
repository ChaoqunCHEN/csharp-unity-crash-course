# 07. Mini Project: Mini Idle Clicker

## Goal

Build a tiny Unity scene that proves you understand Unity-oriented C#:

- Click an enemy.
- Enemy health decreases.
- Enemy death grants gold.
- Enemy death can drop a chest.
- Inventory tracks dropped items.
- UI displays gold, item counts, and enemy health.
- Save/load persists state locally.

## Step 1: Create the Project

On macOS:

1. Install Unity Hub.
2. Install Unity LTS.
3. Choose Apple Silicon editor on M-series Macs and Intel editor on Intel Macs.
4. Create a 2D Core project named `MiniIdleClicker`.
5. Open it once and allow macOS security prompts if they appear.

On Windows:

1. Install Unity Hub.
2. Install Unity LTS.
3. Create a 2D Core project named `MiniIdleClicker`.

## Step 2: Add Folders

```text
Assets/
  Scripts/
  ScriptableObjects/
  Prefabs/
  Scenes/
```

Copy `unity/MiniIdleClicker/Assets/Scripts` from this repository into `Assets/Scripts`.

## Step 3: Build the Scene

1. Save a scene as `Assets/Scenes/MiniIdleClicker.unity`.
2. Create an empty `Enemy` object.
3. Add `Health` and `Enemy` components.
4. Create an empty `Player` object.
5. Add `PlayerController`.
6. Create an empty `Inventory` object.
7. Add `Inventory`.
8. Create an empty `GameManager` object.
9. Add `GameManager`.

## Step 4: Build the UI

Create a `Canvas` with:

- `GoldText` as TextMeshProUGUI.
- `EnemyHealthText` as TextMeshProUGUI.
- `ItemsText` as TextMeshProUGUI.
- `AttackButton`.
- `SaveButton`.
- `LoadButton`.

Wire these fields into `GameManager` in the Inspector.

## Step 5: Create Drops

1. Create an `ItemDefinition` asset named `SmallChest`.
2. Create a `DropTable` asset.
3. Add an entry for `SmallChest` with weight `5`.
4. Add an entry with no item assigned and weight `95`.

That gives an exact 5% chest drop in the simple weighted table.

## Step 6: Wire Inspector Fields

- `PlayerController.targetEnemy` -> `Enemy`
- `GameManager.player` -> `Player`
- `GameManager.enemy` -> `Enemy`
- `GameManager.inventory` -> `Inventory`
- `GameManager.goldText` -> `GoldText`
- `GameManager.itemsText` -> `ItemsText`
- `GameManager.enemyHealthText` -> `EnemyHealthText`
- `GameManager.attackButton` -> `AttackButton`
- `GameManager.saveButton` -> `SaveButton`
- `GameManager.loadButton` -> `LoadButton`
- `Enemy.drops` -> `DropTable`

## Step 7: Test

Press Play:

1. Click Attack until the enemy dies.
2. Confirm gold increases.
3. Confirm enemy health resets.
4. Confirm item text updates when an item drops.
5. Click Save.
6. Stop Play Mode, start again, click Load.

## Common macOS Issues

- First launch security prompts are normal.
- Unity Hub may require login/license activation before projects open.
- Apple Silicon module choice matters if you later build for iOS or use native plugins.
- If shell scripts fail with permission errors, run `chmod +x scripts/test.sh`.
- Avoid synced folders like iCloud Drive for Unity projects.

Checkpoint: after wiring the scene, intentionally clear one Inspector field and observe the Console error or missing behavior. Then wire it back.
