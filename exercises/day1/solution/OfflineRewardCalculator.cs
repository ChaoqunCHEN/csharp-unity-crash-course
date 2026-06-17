namespace Exercises.Day1.Solution;

public static class OfflineRewardCalculator
{
    public static double Calculate(
        DateTimeOffset lastSeen,
        DateTimeOffset now,
        double coinsPerSecond,
        TimeSpan? maxOffline = null)
    {
        if (coinsPerSecond < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(coinsPerSecond));
        }

        var elapsed = now - lastSeen;
        if (elapsed <= TimeSpan.Zero)
        {
            return 0;
        }

        var capped = maxOffline is { } limit && elapsed > limit ? limit : elapsed;
        return capped.TotalSeconds * coinsPerSecond;
    }
}
