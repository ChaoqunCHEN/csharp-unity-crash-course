using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiniIdleClicker
{
    public sealed class Inventory : MonoBehaviour
    {
        private readonly Dictionary<string, int> items = new Dictionary<string, int>(StringComparer.Ordinal);

        public event Action Changed;

        public void Add(string itemId, int amount = 1)
        {
            if (string.IsNullOrWhiteSpace(itemId) || amount <= 0)
            {
                Debug.LogWarning($"Invalid inventory add: {itemId}, {amount}");
                return;
            }

            items[itemId] = CountOf(itemId) + amount;
            Changed?.Invoke();
        }

        public bool Remove(string itemId, int amount = 1)
        {
            if (string.IsNullOrWhiteSpace(itemId) || amount <= 0)
            {
                return false;
            }

            var current = CountOf(itemId);
            if (current < amount)
            {
                return false;
            }

            var remaining = current - amount;
            if (remaining == 0)
            {
                items.Remove(itemId);
            }
            else
            {
                items[itemId] = remaining;
            }

            Changed?.Invoke();
            return true;
        }

        public int CountOf(string itemId)
        {
            return items.TryGetValue(itemId, out var count) ? count : 0;
        }

        public List<InventoryStack> ToSaveData()
        {
            return items
                .OrderBy(pair => pair.Key)
                .Select(pair => new InventoryStack { itemId = pair.Key, amount = pair.Value })
                .ToList();
        }

        public void LoadFrom(IEnumerable<InventoryStack> stacks)
        {
            items.Clear();
            foreach (var stack in stacks)
            {
                if (!string.IsNullOrWhiteSpace(stack.itemId) && stack.amount > 0)
                {
                    items[stack.itemId] = stack.amount;
                }
            }

            Changed?.Invoke();
        }

        public string FormatForUi()
        {
            if (items.Count == 0)
            {
                return "Items: none";
            }

            return "Items: " + string.Join(", ", items.Select(pair => $"{pair.Key} x{pair.Value}"));
        }
    }

    [Serializable]
    public sealed class InventoryStack
    {
        public string itemId = "";
        public int amount;
    }
}
