namespace Exercises.Day1.Starter;

public sealed class Health
{
    public Health(int max)
    {
        throw new NotImplementedException();
    }

    public event EventHandler<int>? Changed;
    public event EventHandler? Died;

    public int Max { get; }
    public int Current { get; private set; }
    public bool IsDead => Current == 0;

    public void TakeDamage(int amount)
    {
        throw new NotImplementedException();
    }

    public void Heal(int amount)
    {
        throw new NotImplementedException();
    }
}
