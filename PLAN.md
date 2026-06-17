# C# + Unity Crash Course Plan

## 目标

为有 Go、Python、Java 经验的软件工程师创建一个 2 天速成教程，目标不是完整掌握 C# 或 Unity，而是能读懂常见代码、写简单功能、并能更自信地用 AI 辅助编写 C# / Unity 原型。

## 受众假设

- 已熟悉变量、函数、类、接口、泛型、异常、异步等通用编程概念。
- 不需要解释“什么是 OOP”，但需要解释 C# 和 Unity 的惯用写法。
- 首选 macOS + VS Code / Cursor / Rider + .NET SDK + Unity Hub；Windows 作为补充路径。

## 范围

Day 1 聚焦 C# 与 .NET：

- `dotnet` 项目结构、`.csproj`、命名空间、类、方法。
- 类型系统、`var`、字符串、nullable reference types、属性、构造函数、record、enum。
- 集合、LINQ、接口、泛型、扩展方法、异常。
- `async` / `await`、`Task`、delegate、`Action`、`Func`、event。
- 可运行控制台示例和可测试的 idle-game domain logic。

Day 2 聚焦 Unity C#：

- GameObject + Component、Scene、Prefab、Inspector。
- MonoBehaviour 生命周期、`[SerializeField]`、`transform`、`Time.deltaTime`。
- Coroutine、UnityEvent / C# event、ScriptableObject、UI 绑定、JSON 存档。
- Mini Idle Clicker 脚本与编辑器搭建步骤。

## 代码与验证策略

- 使用 .NET 8 `net8.0` 作为目标框架。
- Unity 示例保持为脚本和 mini-project 结构，不要求 CI 安装或启动 Unity Editor。
- CI 在 GitHub Actions Ubuntu 上执行 `.NET restore/build/test`，并做基础 Markdown 链接检查。
- 本地如果安装了 .NET SDK，可运行：

```bash
./scripts/test.sh
dotnet run --project src/Day1.ConsolePlayground
```

## 仓库交付物

- `README.md`：macOS first-class setup、Windows setup、2-day schedule、运行方式、Unity 使用方式、后续学习路径。
- `docs/day1-csharp/`：Day 1 教程章节。
- `docs/day2-unity/`：Day 2 教程章节。
- `src/`：可运行 console playground、domain library、unit tests。
- `unity/MiniIdleClicker/`：Unity 脚本和导入说明。
- `exercises/`：Day 1 / Day 2 starter 与 solution。
- `cheatsheets/`：C# 对照速查、Unity C# 速查。
- `.github/workflows/ci.yml`：CI。

## 计划提交历史

1. `chore: initial scaffold`
2. `docs: add day1 csharp tutorial`
3. `docs: add day2 unity tutorial`
4. `feat: add exercises and final review`

## 当前环境说明

当前机器只有 .NET runtime，没有 .NET SDK，因此本地无法执行 `dotnet restore/build/test`。仓库会包含完整 `.NET 8` 项目和 GitHub Actions CI；最终会尝试推送到 GitHub 触发远端验证。
