using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniIdleClicker
{
    public sealed class GameManager : MonoBehaviour
    {
        [Header("Scene References")]
        [SerializeField] private PlayerController player;
        [SerializeField] private Enemy enemy;
        [SerializeField] private Inventory inventory;

        [Header("UI")]
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private TMP_Text itemsText;
        [SerializeField] private TMP_Text enemyHealthText;
        [SerializeField] private Button attackButton;
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;

        private int gold;
        private Health enemyHealth;

        private void Awake()
        {
            if (enemy != null)
            {
                enemyHealth = enemy.GetComponent<Health>();
            }
        }

        private void OnEnable()
        {
            if (attackButton != null)
            {
                attackButton.onClick.AddListener(Attack);
            }

            if (saveButton != null)
            {
                saveButton.onClick.AddListener(Save);
            }

            if (loadButton != null)
            {
                loadButton.onClick.AddListener(Load);
            }

            if (enemyHealth != null)
            {
                enemyHealth.Changed += HandleEnemyHealthChanged;
                enemyHealth.Died += HandleEnemyDied;
            }

            if (inventory != null)
            {
                inventory.Changed += RefreshUi;
            }
        }

        private void Start()
        {
            RefreshUi();
        }

        private void OnDisable()
        {
            if (attackButton != null)
            {
                attackButton.onClick.RemoveListener(Attack);
            }

            if (saveButton != null)
            {
                saveButton.onClick.RemoveListener(Save);
            }

            if (loadButton != null)
            {
                loadButton.onClick.RemoveListener(Load);
            }

            if (enemyHealth != null)
            {
                enemyHealth.Changed -= HandleEnemyHealthChanged;
                enemyHealth.Died -= HandleEnemyDied;
            }

            if (inventory != null)
            {
                inventory.Changed -= RefreshUi;
            }
        }

        public void Attack()
        {
            if (player != null)
            {
                player.AttackCurrentEnemy();
            }
        }

        public void Save()
        {
            SaveSystem.Save(new GameSaveData
            {
                gold = gold,
                inventory = inventory != null ? inventory.ToSaveData() : new List<InventoryStack>(),
                savedAtUtc = DateTimeOffset.UtcNow.ToString("O")
            });
        }

        public void Load()
        {
            var data = SaveSystem.Load();
            if (data == null)
            {
                Debug.Log("No save file found.");
                return;
            }

            gold = data.gold;
            if (inventory != null)
            {
                inventory.LoadFrom(data.inventory);
            }

            RefreshUi();
        }

        private void HandleEnemyHealthChanged(int current, int max)
        {
            if (enemyHealthText != null)
            {
                enemyHealthText.text = $"Enemy HP: {current}/{max}";
            }
        }

        private void HandleEnemyDied()
        {
            if (enemy == null)
            {
                return;
            }

            gold += enemy.GoldReward;

            var drop = enemy.RollDrop();
            if (drop != null && inventory != null)
            {
                inventory.Add(drop.Id);
            }

            enemy.Respawn();
            RefreshUi();
        }

        private void RefreshUi()
        {
            if (goldText != null)
            {
                goldText.text = $"Gold: {gold}";
            }

            if (itemsText != null)
            {
                itemsText.text = inventory != null ? inventory.FormatForUi() : "Items: none";
            }

            if (enemyHealth != null && enemyHealthText != null)
            {
                enemyHealthText.text = $"Enemy HP: {enemyHealth.Current}/{enemyHealth.Max}";
            }
        }
    }
}
