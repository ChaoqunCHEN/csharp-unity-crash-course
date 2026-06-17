using IdleGame.Domain;

Console.WriteLine("Day 1 C# Console Playground");
Console.WriteLine("===========================");

var inventory = new Inventory();
inventory.Add("gold", 10);
inventory.Add("chest");

Console.WriteLine($"gold={inventory.CountOf("gold")}, chest={inventory.CountOf("chest")}");

var drops = new WeightedDropTable<string>()
    .Add("gold", 95)
    .Add("chest", 5);

var drop = drops.Roll(new Random());
Console.WriteLine($"enemy drop={drop}");

var health = new Health(max: 12);
health.Changed += (_, current) => Console.WriteLine($"enemy hp={current}");
health.Died += (_, _) => Console.WriteLine("enemy died, grant gold");
health.TakeDamage(5);
health.TakeDamage(10);

var lastSeen = DateTimeOffset.UtcNow.AddMinutes(-15);
var offlineGold = OfflineRewardCalculator.Calculate(lastSeen, DateTimeOffset.UtcNow, coinsPerSecond: 1.5);
Console.WriteLine($"offline reward={offlineGold:0} gold");

var api = new FakePlayerApi();
var profile = await api.LoadProfileAsync("player-001");
Console.WriteLine($"loaded profile: {profile.DisplayName}, gold={profile.Gold}");
