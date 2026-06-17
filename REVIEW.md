# Final Review Checklist

## Requirements

- [x] English tutorial content.
- [x] Audience: experienced Go, Python, and Java engineers.
- [x] Day 1 C# crash course with runnable examples.
- [x] Day 2 Unity-oriented C# tutorial.
- [x] macOS setup is first-class.
- [x] Windows setup is included in README.
- [x] Unity Editor is not required in CI.
- [x] `.gitignore` covers .NET and Unity outputs.
- [x] GitHub Actions restores, builds, and tests .NET projects.
- [x] Scripts include `./scripts/test.sh` and `scripts/test.ps1`.
- [x] Unit tests cover weighted drop table, inventory add/remove, offline reward, and health events.
- [x] Unity scripts include Mini Idle Clicker pieces.

## Local Verification Notes

- `git diff --check` passes.
- `rg -n "[\p{Han}]" . --glob '!/.git/**'` finds no Chinese text.
- The host had no global .NET SDK, so a temporary .NET 8 SDK was installed to `/tmp/codex-dotnet` for verification.
- `PATH=/tmp/codex-dotnet:$PATH ./scripts/test.sh` passes: build succeeded with 0 warnings / 0 errors, and 11/11 tests passed.
- `PATH=/tmp/codex-dotnet:$PATH dotnet run --project src/Day1.ConsolePlayground` runs successfully.

Remote GitHub Actions should repeat the .NET validation after push.
