using UnityEngine;

namespace MiniIdleClicker
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField, Min(1)] private int clickDamage = 1;
        [SerializeField] private Enemy targetEnemy;

        public int ClickDamage => clickDamage;

        public void AttackCurrentEnemy()
        {
            if (targetEnemy == null)
            {
                Debug.LogWarning("No enemy assigned to PlayerController.");
                return;
            }

            var health = targetEnemy.GetComponent<Health>();
            health.TakeDamage(clickDamage);
        }
    }
}
