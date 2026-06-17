# C# + Unity Crash Course Design

## Requirements

Create a polished self-guided GitHub tutorial repo named `csharp-unity-crash-course` for experienced Go, Python, and Java engineers. The tutorial language is English. Code and comments are English.

The tutorial must be completable on macOS, with Windows instructions as a secondary path. It must not require Unity Editor in CI. It must include runnable .NET examples, unit tests for non-Unity domain logic, Unity scripts that compile conceptually in a normal Unity LTS project, exercises, cheatsheets, and GitHub Actions.

## Architecture

The repo is documentation-first, backed by a small .NET domain model for an idle-clicker style game. Day 1 teaches C# through the domain model and console playground. Day 2 maps those same concepts onto Unity's component model and a `MiniIdleClicker` script set.

CI validates the .NET pieces only:

- `src/IdleGame.Domain`
- `src/Day1.ConsolePlayground`
- `src/IdleGame.Tests`

Unity assets are plain scripts and markdown instructions under `unity/MiniIdleClicker`.

## Content Design

Each lesson uses a compact pattern:

1. Concept
2. Why it matters
3. Comparison to Go / Java / Python when useful
4. Small code example
5. Checkpoint or exercise

Day 1 progresses from syntax to idioms, then domain behavior. Day 2 starts with Unity's mental model, then lifecycle, data, input/update loops, UI/events/save-load, and a mini-project assembly guide.

## Testing Design

Domain tests cover:

- weighted drop table
- inventory add/remove
- offline reward calculation
- health event behavior

Tests avoid Unity dependencies and can run on Ubuntu in GitHub Actions with .NET 8.

## Risks and Mitigations

- Local environment lacks .NET SDK: include CI and explicit install instructions; report local verification limitation.
- Unity scripts cannot be validated in CI: keep scripts simple, use standard Unity APIs, and document manual editor setup.
- Tutorial could become too verbose: keep lessons concise and example-driven.
