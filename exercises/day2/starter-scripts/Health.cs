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

        private void Awake()
        {
            // TODO: Initialize Current.
        }

        public void TakeDamage(int amount)
        {
            // TODO: Clamp to zero, raise Changed, raise Died once.
        }
    }
}
