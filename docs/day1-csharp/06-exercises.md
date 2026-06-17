# 06. Day 1 Exercises

这些练习对应 `src/IdleGame.Domain` 和 `exercises/day1`。建议先自己写 starter，再对照 solution。

## 1. Inventory System

目标：实现可堆叠背包。

要求：

- `Add(string itemId, int amount)` 增加数量。
- `Remove(string itemId, int amount)` 成功返回 `true`，数量不足返回 `false`。
- `CountOf(string itemId)` 查询数量。
- 空 ID 和非正数量要抛异常。

Checkpoint：运行 `InventoryTests`。

## 2. Weighted Drop Table

目标：实现按权重抽奖。

要求：

- 支持链式 `.Add("gold", 95).Add("chest", 5)`。
- 权重必须大于 0。
- `Roll(Random rng)` 使用传入的随机数，方便测试。

Checkpoint：解释为什么测试里不应该依赖“跑 100 次大概率会出现 rare”。

## 3. Offline Reward Calculation

目标：根据离线时间计算收益。

要求：

- 输入 `lastSeen`、`now`、`coinsPerSecond`。
- 时钟倒退时返回 0。
- 支持 `maxOffline` 封顶。

Checkpoint：如果玩家离线 2 天，但最多奖励 8 小时，应该得到多少？

## 4. Async Fake API Call

目标：写一个模拟异步 API。

要求：

- 方法名以 `Async` 结尾。
- 返回 `Task<PlayerProfile>`。
- 用 `Task.Delay` 模拟网络等待。
- 支持 `CancellationToken`。

Checkpoint：故意去掉 `await`，观察调用端拿到的类型是什么。

## 5. Event-Driven Health System

目标：用事件表达生命值变化和死亡。

要求：

- `Changed` 事件携带当前 HP。
- `Died` 事件只触发一次。
- 死亡后继续伤害不再重复触发。

Checkpoint：为什么 `Died` 应该是事件，而不是外部每帧检查 `IsDead`？
