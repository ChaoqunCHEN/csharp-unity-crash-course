namespace Exercises.Day1.Solution;

public sealed class Health
{
    public Health(int max)
    {
        if (max <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(max));
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
            throw new ArgumentOutOfRangeException(nameof(amount));
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
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        if (IsDead)
        {
            return;
        }

        Current = Math.Min(Max, Current + amount);
        Changed?.Invoke(this, Current);
    }
}
