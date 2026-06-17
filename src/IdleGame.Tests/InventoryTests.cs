using IdleGame.Domain;

namespace IdleGame.Tests;

public class InventoryTests
{
    [Fact]
    public void Add_IncreasesExistingStack()
    {
        var inventory = new Inventory();

        inventory.Add("chest", 1);
        inventory.Add("chest", 2);

        Assert.Equal(3, inventory.CountOf("chest"));
    }

    [Fact]
    public void Remove_ReturnsFalseWhenNotEnoughItems()
    {
        var inventory = new Inventory();
        inventory.Add("potion", 1);

        var removed = inventory.Remove("potion", 2);

        Assert.False(removed);
        Assert.Equal(1, inventory.CountOf("potion"));
    }

    [Fact]
    public void Remove_DeletesEmptyStack()
    {
        var inventory = new Inventory();
        inventory.Add("key", 1);

        var removed = inventory.Remove("key", 1);

        Assert.True(removed);
        Assert.Equal(0, inventory.CountOf("key"));
        Assert.DoesNotContain("key", inventory.Snapshot().Keys);
    }
}
