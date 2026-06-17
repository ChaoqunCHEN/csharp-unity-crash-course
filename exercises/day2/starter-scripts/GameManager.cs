using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniIdleClicker.Exercises
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private Button attackButton;
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private Health enemyHealth;

        private int gold;

        private void OnEnable()
        {
            // TODO: Subscribe button and health events.
        }

        private void OnDisable()
        {
            // TODO: Unsubscribe.
        }

        private void Attack()
        {
            // TODO: Damage enemy.
        }

        private void HandleEnemyDied()
        {
            // TODO: Add gold and refresh UI.
        }
    }
}
