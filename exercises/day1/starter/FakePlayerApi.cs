namespace Exercises.Day1.Starter;

public sealed class FakePlayerApi
{
    public async Task<PlayerProfile> LoadProfileAsync(string playerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

public sealed record PlayerProfile(string Id, string DisplayName, int Gold);
