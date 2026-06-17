# 05. Input, Update, Physics, and Coroutines

## Update and Time.deltaTime

`Update` runs once per rendered frame. Frame rates vary, so time-based movement or income should use `Time.deltaTime`:

```csharp
transform.position += direction * speed * Time.deltaTime;
```

For idle games:

```csharp
gold += coinsPerSecond * Time.deltaTime;
```

## Input

For this mini-project, UI Button clicks are enough:

```csharp
attackButton.onClick.AddListener(Attack);
```

For keyboard or gamepad input, Unity's newer Input System is worth learning later. Do not add it on Day 2 unless you need it.

## FixedUpdate

`FixedUpdate` runs on a fixed timestep and is intended for physics. If you use `Rigidbody2D`, apply physics forces in `FixedUpdate`.

Mini Idle Clicker does not need physics.

## Coroutines

Coroutines express work over multiple frames:

```csharp
private IEnumerator RespawnAfterDelay()
{
    yield return new WaitForSeconds(0.5f);
    enemy.Respawn();
}
```

They are not threads. Heavy CPU work in a coroutine still blocks the main thread.

## Performance Notes

- Avoid `GameObject.Find`, `FindObjectOfType`, and repeated `GetComponent` in `Update`.
- Avoid LINQ in hot per-frame loops.
- Avoid unnecessary string formatting every frame.
- Update UI when data changes, not blindly every frame.
- Watch GC allocation when targeting mobile.

Checkpoint: in Mini Idle Clicker, why does `GameManager` refresh UI after events instead of rebuilding UI every `Update`?
