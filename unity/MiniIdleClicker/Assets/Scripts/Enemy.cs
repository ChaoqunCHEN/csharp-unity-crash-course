using UnityEngine;

namespace MiniIdleClicker
{
    [RequireComponent(typeof(Health))]
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField, Min(0)] private int goldReward = 5;
        [SerializeField] private DropTable drops;

        private Health health;

        public int GoldReward => goldReward;

        private void Awake()
        {
            health = GetComponent<Health>();
        }

        public ItemDefinition RollDrop()
        {
            return drops != null ? drops.Roll() : null;
        }

        public void Respawn()
        {
            health.ResetHealth();
        }
    }
}
