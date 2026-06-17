# 06. Day 1 Exercises

These exercises map to `src/IdleGame.Domain` and `exercises/day1`. Try the starter version first, then compare with the solution.

## 1. Inventory System

Goal: implement a stackable inventory.

Requirements:

- `Add(string itemId, int amount)` increases a stack.
- `Remove(string itemId, int amount)` returns `true` on success and `false` when there are not enough items.
- `CountOf(string itemId)` returns the current count.
- Empty IDs and non-positive amounts should throw.

Checkpoint: run `InventoryTests`.

## 2. Weighted Drop Table

Goal: implement weighted random drops.

Requirements:

- Support chained calls such as `.Add("gold", 95).Add("chest", 5)`.
- Weight must be greater than zero.
- `Roll(Random rng)` should use the provided random instance so tests can be deterministic.

Checkpoint: explain why a test should not rely on "run 100 times and a rare drop will probably appear."

## 3. Offline Reward Calculation

Goal: calculate rewards from offline time.

Requirements:

- Input `lastSeen`, `now`, and `coinsPerSecond`.
- Return zero if the clock moves backward.
- Support a `maxOffline` cap.

Checkpoint: if a player is offline for 2 days but rewards cap at 8 hours, how many seconds should count?

## 4. Async Fake API Call

Goal: write a fake asynchronous API.

Requirements:

- Method name ends with `Async`.
- Return `Task<PlayerProfile>`.
- Use `Task.Delay` to simulate network latency.
- Support `CancellationToken`.

Checkpoint: remove `await` at the call site and inspect the type you get back.

## 5. Event-Driven Health System

Goal: use events for health changes and death.

Requirements:

- `Changed` carries the current HP.
- `Died` fires once.
- Further damage after death does not fire more events.

Checkpoint: why is `Died` better as an event than polling `IsDead` every frame?
