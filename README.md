# C# + Unity Crash Course

A two-day fast-track tutorial for experienced Go, Python, and Java engineers who want practical C# and Unity fluency.

You will learn enough C# to read code, write simple features, and vibe-code Unity prototypes with better judgment.

## Who This Is For

This is for you if:

- You already know at least one production language well.
- You want a compact bridge into C# syntax and idioms.
- You want Unity-specific C# patterns without getting buried in engine architecture.
- You use macOS, VS Code / Cursor / Rider, .NET SDK, and Unity Hub.

## Prerequisites

### macOS First-Class Path

This course targets .NET 8 with `net8.0`. Install the .NET 8 SDK:

```bash
brew install dotnet@8
echo 'export DOTNET_ROOT="/opt/homebrew/opt/dotnet@8/libexec"' >> ~/.zshrc
echo 'export PATH="/opt/homebrew/opt/dotnet@8/bin:$PATH"' >> ~/.zshrc
source ~/.zshrc
dotnet --info
```

If you already have a newer .NET installed, make sure the Homebrew .NET 8 path appears first:

```bash
which dotnet
dotnet --list-sdks
dotnet --list-runtimes
```

Expected output includes an `8.0.x` SDK and `Microsoft.NETCore.App 8.0.x`. On Apple Silicon Homebrew installs `dotnet@8` as a keg-only formula, so the `DOTNET_ROOT` and `PATH` lines above are important.

If you do not use Homebrew, install the SDK from Microsoft:

- https://dotnet.microsoft.com/download/dotnet/8.0

Install Unity:

1. Install Unity Hub: https://unity.com/download
2. Sign in and activate a Personal or Pro license.
3. Install Unity LTS.
4. On Apple Silicon Macs, prefer the Apple Silicon editor. On Intel Macs, choose the Intel editor.
5. Create or open a 2D Core project for the Unity mini-project.

Common macOS Unity issues:

- First launch may show security prompts in System Settings -> Privacy & Security.
- Unity Hub requires login and license activation.
- Apple Silicon editor/module choice matters for native plugins and build targets.
- Avoid putting Unity projects in iCloud or Dropbox synced folders.
- If shell scripts fail, run `chmod +x scripts/test.sh`.

### Windows Path

1. Install .NET SDK 8 from https://dotnet.microsoft.com/download/dotnet/8.0
2. Verify with:

```powershell
dotnet --info
dotnet --list-sdks
dotnet --list-runtimes
```

3. Install Unity Hub.
4. Install Unity LTS.
5. Use VS Code, Cursor, Rider, or Visual Studio.

## Two-Day Schedule

### Day 1: C# and .NET

Read:

- `docs/day1-csharp/00-overview.md`
- `docs/day1-csharp/01-syntax-for-java-go-python-devs.md`
- `docs/day1-csharp/02-types-nullability-properties.md`
- `docs/day1-csharp/03-collections-linq.md`
- `docs/day1-csharp/04-oop-interface-generics.md`
- `docs/day1-csharp/05-async-await-events.md`
- `docs/day1-csharp/06-exercises.md`

Run:

```bash
dotnet run --project src/Day1.ConsolePlayground
dotnet test src/IdleGame.Tests
```

### Day 2: Unity-Oriented C#

Read:

- `docs/day2-unity/00-overview.md`
- `docs/day2-unity/01-unity-mental-model.md`
- `docs/day2-unity/02-monobehaviour-lifecycle.md`
- `docs/day2-unity/03-gameobject-component-prefab-scene.md`
- `docs/day2-unity/04-serialized-fields-scriptableobject.md`
- `docs/day2-unity/05-input-update-physics-coroutines.md`
- `docs/day2-unity/06-ui-events-save-load.md`
- `docs/day2-unity/07-mini-project.md`

Open the Unity mini-project script folder:

```text
unity/MiniIdleClicker/Assets/Scripts
```

Follow:

```text
unity/MiniIdleClicker/README.md
```

## Repository Map

```text
docs/
  day1-csharp/
  day2-unity/
src/
  Day1.ConsolePlayground/
  IdleGame.Domain/
  IdleGame.Tests/
unity/
  MiniIdleClicker/
exercises/
  day1/
  day2/
cheatsheets/
scripts/
```

## Commands

Cross-platform shell:

```bash
./scripts/test.sh
```

Windows PowerShell:

```powershell
scripts/test.ps1
```

Direct commands:

```bash
dotnet restore src/IdleGame.Tests/IdleGame.Tests.csproj
dotnet build src/Day1.ConsolePlayground/Day1.ConsolePlayground.csproj --configuration Release --no-restore
dotnet test src/IdleGame.Tests/IdleGame.Tests.csproj --configuration Release --no-restore
dotnet run --project src/Day1.ConsolePlayground
```

## Unity Mini Project

The Unity folder is intentionally lightweight. It contains scripts and setup instructions, not a full Unity project with `Library/` and generated files.

Mini Idle Clicker includes:

- `PlayerController.cs`
- `Health.cs`
- `Enemy.cs`
- `DropTable.cs`
- `Inventory.cs`
- `GameManager.cs`
- `SaveSystem.cs`
- `ItemDefinition.cs`

CI does not require Unity Editor. Validate Unity behavior manually in Unity LTS.

## Suggested Next Steps

After finishing:

- Build a Pong clone.
- Build a slightly larger idle game prototype.
- Learn ScriptableObject architecture.
- Learn Unity Addressables later, after the basics are comfortable.
- Learn basic profiling: CPU, GC allocation, Canvas rebuilds, and memory.
