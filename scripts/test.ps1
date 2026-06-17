Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

dotnet restore src/Day1.ConsolePlayground/Day1.ConsolePlayground.csproj
dotnet restore src/IdleGame.Tests/IdleGame.Tests.csproj
dotnet build src/Day1.ConsolePlayground/Day1.ConsolePlayground.csproj --configuration Release --no-restore
dotnet test src/IdleGame.Tests/IdleGame.Tests.csproj --configuration Release --no-restore --verbosity normal
