using IdleGame.Domain;
using Xunit;

namespace IdleGame.Tests;

public class HealthTests
{
    [Fact]
    public void TakeDamage_RaisesChangedAndDiedEvents()
    {
        var health = new Health(max: 10);
        var changed = new List<int>();
        var diedCount = 0;
        health.Changed += (_, hp) => changed.Add(hp);
        health.Died += (_, _) => diedCount++;

        health.TakeDamage(4);
        health.TakeDamage(10);
        health.TakeDamage(1);

        Assert.Equal(new[] { 6, 0 }, changed);
        Assert.Equal(1, diedCount);
        Assert.True(health.IsDead);
    }

    [Fact]
    public void Heal_DoesNotExceedMax()
    {
        var health = new Health(max: 10);
        health.TakeDamage(8);

        health.Heal(99);

        Assert.Equal(10, health.Current);
    }
}
