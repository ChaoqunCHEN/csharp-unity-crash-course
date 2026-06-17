namespace Exercises.Day1.Solution;

public sealed class FakePlayerApi
{
    public async Task<PlayerProfile> LoadProfileAsync(string playerId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(playerId))
        {
            throw new ArgumentException("Player id cannot be empty.", nameof(playerId));
        }

        await Task.Delay(150, cancellationToken);
        return new PlayerProfile(playerId, "Ada", Gold: 120);
    }
}

public sealed record PlayerProfile(string Id, string DisplayName, int Gold);
