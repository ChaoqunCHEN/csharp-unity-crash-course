using IdleGame.Domain;

namespace IdleGame.Tests;

public class OfflineRewardTests
{
    [Fact]
    public void Calculate_ReturnsCoinsForElapsedSeconds()
    {
        var from = new DateTimeOffset(2026, 6, 17, 10, 0, 0, TimeSpan.Zero);
        var to = from.AddMinutes(5);

        var reward = OfflineRewardCalculator.Calculate(from, to, coinsPerSecond: 2.5);

        Assert.Equal(750, reward);
    }

    [Fact]
    public void Calculate_CapsLongOfflineSessions()
    {
        var from = new DateTimeOffset(2026, 6, 17, 10, 0, 0, TimeSpan.Zero);
        var to = from.AddDays(2);

        var reward = OfflineRewardCalculator.Calculate(from, to, coinsPerSecond: 1, maxOffline: TimeSpan.FromHours(8));

        Assert.Equal(28_800, reward);
    }

    [Fact]
    public void Calculate_ReturnsZeroForClockSkew()
    {
        var from = new DateTimeOffset(2026, 6, 17, 10, 0, 0, TimeSpan.Zero);

        var reward = OfflineRewardCalculator.Calculate(from, from.AddMinutes(-1), coinsPerSecond: 100);

        Assert.Equal(0, reward);
    }
}
