namespace IdleGame.Domain;

public sealed class Enemy
{
    public Enemy(string id, int maxHealth, int goldReward)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Enemy id cannot be empty.", nameof(id));
        }

        if (goldReward < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(goldReward), "Reward cannot be negative.");
        }

        Id = id;
        GoldReward = goldReward;
        Health = new Health(maxHealth);
    }

    public string Id { get; }
    public int GoldReward { get; }
    public Health Health { get; }
}
