# C# + Unity Crash Course Plan

## Goal

Create a two-day fast-track tutorial for experienced Go, Python, and Java engineers who want enough C# and Unity fluency to read code, write small features, and vibe-code C# / Unity prototypes with confidence.

## Audience Assumptions

- The reader already understands variables, functions, classes, interfaces, generics, exceptions, async concepts, and basic testing.
- The tutorial should not explain programming from scratch; it should translate existing engineering knowledge into C# and Unity idioms.
- macOS is first-class: VS Code / Cursor / Rider, .NET SDK, Unity Hub, and Unity LTS. Windows instructions are included as a secondary path.

## Scope

Day 1 focuses on C# and .NET:

- `dotnet` project structure, `.csproj`, namespaces, classes, and methods.
- Types, `var`, strings, nullable reference types, properties, constructors, records, and enums.
- Collections, LINQ, interfaces, generics, extension methods, and exceptions.
- `async` / `await`, `Task`, delegates, `Action`, `Func`, and events.
- Runnable console examples and testable idle-game domain logic.

Day 2 focuses on Unity-oriented C#:

- GameObject + Component, Scene, Prefab, and Inspector.
- MonoBehaviour lifecycle, `[SerializeField]`, `transform`, and `Time.deltaTime`.
- Coroutines, UnityEvent / C# events, ScriptableObject, UI binding, and JSON save/load.
- Mini Idle Clicker scripts and step-by-step Unity Editor setup.

## Code and Verification Strategy

- Target .NET 8 with `net8.0`.
- Keep Unity examples as scripts and a mini-project folder structure. CI does not install or launch Unity Editor.
- GitHub Actions validates the .NET projects on Ubuntu and performs a basic Markdown local-link check.
- With a local .NET SDK installed, run:

```bash
./scripts/test.sh
dotnet run --project src/Day1.ConsolePlayground
```

## Repository Deliverables

- `README.md`: setup, schedule, run commands, Unity usage, and next steps.
- `docs/day1-csharp/`: Day 1 C# lessons.
- `docs/day2-unity/`: Day 2 Unity lessons.
- `src/`: runnable console playground, domain library, and tests.
- `unity/MiniIdleClicker/`: Unity scripts and import instructions.
- `exercises/`: Day 1 and Day 2 starters and solutions.
- `cheatsheets/`: C# and Unity C# quick references.
- `.github/workflows/ci.yml`: CI.

## Planned Commit History

1. `chore: initial scaffold`
2. `docs: add day1 csharp tutorial`
3. `docs: switch tutorial to english`
4. `docs: add day2 unity tutorial`
5. `feat: add exercises and final review`

## Current Environment Note

This machine currently has a .NET runtime but no .NET SDK, so local `dotnet restore/build/test` cannot run here. The repository still includes complete .NET 8 project files and GitHub Actions CI; after push, remote CI is the authoritative build/test validation.
