# C# + Unity Crash Course Implementation Plan

> **For agentic workers:** REQUIRED: Use superpowers:subagent-driven-development (if subagents available) or superpowers:executing-plans to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build and publish a complete 2-day Chinese C# + Unity crash-course repository for experienced Go/Python/Java engineers.

**Architecture:** A documentation-first repo with runnable .NET 8 examples and tests, plus Unity script assets that do not participate in CI. Day 1 teaches C# through a small idle-game domain model; Day 2 maps the same domain into Unity component scripts.

**Tech Stack:** Markdown, .NET 8, C# 12-compatible syntax, xUnit, GitHub Actions, Unity LTS script APIs.

---

## Chunk 1: Scaffold

- [ ] Create target directory layout.
- [ ] Add `PLAN.md`, design doc, implementation plan, `.gitignore`, placeholder README, scripts, and CI skeleton.
- [ ] Commit as `chore: initial scaffold`.

## Chunk 2: Day 1 and .NET Code

- [ ] Create `IdleGame.Domain` with inventory, weighted drop table, offline reward calculator, health events, and fake API client.
- [ ] Create `Day1.ConsolePlayground` with runnable examples.
- [ ] Create `IdleGame.Tests` covering the required domain logic.
- [ ] Write Day 1 lesson docs and cheatsheet.
- [ ] Commit as `docs: add day1 csharp tutorial`.

## Chunk 3: Day 2 and Unity

- [ ] Add Unity `MiniIdleClicker` scripts.
- [ ] Add Unity setup README.
- [ ] Write Day 2 lesson docs and Unity cheatsheet.
- [ ] Commit as `docs: add day2 unity tutorial`.

## Chunk 4: Exercises, Review, Publish

- [ ] Add starter and solution exercises for Day 1 and Day 2.
- [ ] Complete top-level README.
- [ ] Run available verification; if local SDK is missing, document that and rely on CI.
- [ ] Review requirements checklist.
- [ ] Commit as `feat: add exercises and final review`.
- [ ] Create/push GitHub repo `csharp-unity-crash-course`.
