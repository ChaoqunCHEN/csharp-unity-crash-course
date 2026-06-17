using UnityEngine;

namespace MiniIdleClicker
{
    [CreateAssetMenu(menuName = "Idle Clicker/Item Definition")]
    public sealed class ItemDefinition : ScriptableObject
    {
        [SerializeField] private string id = "small_chest";
        [SerializeField] private string displayName = "Small Chest";
        [SerializeField] private Sprite icon;
        [SerializeField, Min(0)] private int goldValue = 10;

        public string Id => id;
        public string DisplayName => displayName;
        public Sprite Icon => icon;
        public int GoldValue => goldValue;
    }
}
