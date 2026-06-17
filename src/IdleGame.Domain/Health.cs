namespace IdleGame.Domain;

public sealed class Health
{
    public Health(int max)
    {
        if (max <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(max), "Max health must be positive.");
        }

        Max = max;
        Current = max;
    }

    public event EventHandler<int>? Changed;
    public event EventHandler? Died;

    public int Max { get; }
    public int Current { get; private set; }
    public bool IsDead => Current == 0;

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Damage must be positive.");
        }

        if (IsDead)
        {
            return;
        }

        Current = Math.Max(0, Current - amount);
        Changed?.Invoke(this, Current);

        if (IsDead)
        {
            Died?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Heal amount must be positive.");
        }

        if (IsDead)
        {
            return;
        }

        var next = Math.Min(Max, Current + amount);
        if (next == Current)
        {
            return;
        }

        Current = next;
        Changed?.Invoke(this, Current);
    }
}
