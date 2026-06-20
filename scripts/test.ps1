Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$hasDotNet8Runtime = dotnet --list-runtimes | Select-String -Pattern '^Microsoft\.NETCore\.App 8\.'
if (-not $hasDotNet8Runtime) {
    Write-Error @"
This course targets .NET 8, but the .NET 8 runtime was not found.

Install .NET SDK 8 from:
  https://dotnet.microsoft.com/download/dotnet/8.0

Then rerun:
  dotnet --info
"@
}

dotnet restore src/Day1.ConsolePlayground/Day1.ConsolePlayground.csproj
dotnet restore src/IdleGame.Tests/IdleGame.Tests.csproj
dotnet build src/Day1.ConsolePlayground/Day1.ConsolePlayground.csproj --configuration Release --no-restore
dotnet test src/IdleGame.Tests/IdleGame.Tests.csproj --configuration Release --no-restore --verbosity normal
