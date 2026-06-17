using System;
using UnityEngine;

namespace MiniIdleClicker.Exercises
{
    public sealed class Health : MonoBehaviour
    {
        [SerializeField, Min(1)] private int maxHealth = 10;

        public event Action<int, int> Changed;
        public event Action Died;

        public int Max => maxHealth;
        public int Current { get; private set; }
        public bool IsDead => Current == 0;

        private void Awake()
        {
            Current = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0 || IsDead)
            {
                return;
            }

            Current = Mathf.Max(0, Current - amount);
            Changed?.Invoke(Current, Max);

            if (IsDead)
            {
                Died?.Invoke();
            }
        }

        public void ResetHealth()
        {
            Current = maxHealth;
            Changed?.Invoke(Current, Max);
        }
    }
}
