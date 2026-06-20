#!/usr/bin/env bash
set -euo pipefail

if ! dotnet --list-runtimes | grep -q '^Microsoft\.NETCore\.App 8\.'; then
  cat >&2 <<'EOF'
This course targets .NET 8, but the .NET 8 runtime was not found.

macOS/Homebrew:
  brew install dotnet@8
  export DOTNET_ROOT="/opt/homebrew/opt/dotnet@8/libexec"
  export PATH="/opt/homebrew/opt/dotnet@8/bin:$PATH"

Then rerun:
  dotnet --info
EOF
  exit 1
fi

dotnet restore src/Day1.ConsolePlayground/Day1.ConsolePlayground.csproj
dotnet restore src/IdleGame.Tests/IdleGame.Tests.csproj
dotnet build src/Day1.ConsolePlayground/Day1.ConsolePlayground.csproj --configuration Release --no-restore
dotnet test src/IdleGame.Tests/IdleGame.Tests.csproj --configuration Release --no-restore --verbosity normal
