using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniIdleClicker.Exercises
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private Button attackButton;
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private TMP_Text enemyHealthText;
        [SerializeField] private Health enemyHealth;

        private int gold;

        private void OnEnable()
        {
            attackButton.onClick.AddListener(Attack);
            enemyHealth.Changed += HandleHealthChanged;
            enemyHealth.Died += HandleEnemyDied;
        }

        private void Start()
        {
            RefreshUi();
        }

        private void OnDisable()
        {
            attackButton.onClick.RemoveListener(Attack);
            enemyHealth.Changed -= HandleHealthChanged;
            enemyHealth.Died -= HandleEnemyDied;
        }

        private void Attack()
        {
            enemyHealth.TakeDamage(1);
        }

        private void HandleHealthChanged(int current, int max)
        {
            enemyHealthText.text = $"Enemy HP: {current}/{max}";
        }

        private void HandleEnemyDied()
        {
            gold += 5;
            enemyHealth.ResetHealth();
            RefreshUi();
        }

        private void RefreshUi()
        {
            goldText.text = $"Gold: {gold}";
            enemyHealthText.text = $"Enemy HP: {enemyHealth.Current}/{enemyHealth.Max}";
        }
    }
}
