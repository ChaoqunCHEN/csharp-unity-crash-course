using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniIdleClicker
{
    [CreateAssetMenu(menuName = "Idle Clicker/Drop Table")]
    public sealed class DropTable : ScriptableObject
    {
        [SerializeField] private List<DropEntry> entries = new List<DropEntry>();

        public ItemDefinition Roll()
        {
            var totalWeight = 0f;
            foreach (var entry in entries)
            {
                if (entry.weight > 0f)
                {
                    totalWeight += entry.weight;
                }
            }

            if (totalWeight <= 0f)
            {
                return null;
            }

            var target = UnityEngine.Random.value * totalWeight;
            var cursor = 0f;
            foreach (var entry in entries)
            {
                if (entry.weight <= 0f)
                {
                    continue;
                }

                cursor += entry.weight;
                if (target < cursor)
                {
                    return entry.item;
                }
            }

            return null;
        }
    }

    [Serializable]
    public sealed class DropEntry
    {
        // Leave item empty to represent "no drop" with a weight.
        public ItemDefinition item;
        [Min(0f)] public float weight = 1f;
    }
}
