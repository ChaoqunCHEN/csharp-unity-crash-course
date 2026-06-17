using IdleGame.Domain;
using Xunit;

namespace IdleGame.Tests;

public class WeightedDropTableTests
{
    [Fact]
    public void Roll_ReturnsOnlyConfiguredItems()
    {
        var table = new WeightedDropTable<string>()
            .Add("gold", 95)
            .Add("chest", 5);

        var seen = Enumerable.Range(0, 100)
            .Select(seed => table.Roll(new Random(seed)))
            .ToHashSet();

        var configured = new HashSet<string> { "gold", "chest" };
        Assert.All(seen, item => Assert.Contains(item, configured));
    }

    [Fact]
    public void Roll_UsesWeightsDeterministicallyWithProvidedRandom()
    {
        var table = new WeightedDropTable<string>()
            .Add("common", 90)
            .Add("rare", 10);

        var common = table.Roll(new FixedRandom(0.10));
        var rare = table.Roll(new FixedRandom(0.95));

        Assert.Equal("common", common);
        Assert.Equal("rare", rare);
    }

    [Fact]
    public void Add_RejectsNonPositiveWeight()
    {
        var table = new WeightedDropTable<string>();

        Assert.Throws<ArgumentOutOfRangeException>(() => table.Add("broken", 0));
    }

    private sealed class FixedRandom(double value) : Random
    {
        public override double NextDouble() => value;
    }
}
