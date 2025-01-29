using System;
using _Project.Scripts.Inventory.Item.Data;

namespace _Project.Scripts.Inventory
{
    [Serializable]
    public class HealItemData : ItemData
    {
        [NonSerialized]
        public HealthData PlayerHealthData;

        public int HealValue;
        
        public override void Use()
        {
            PlayerHealthData.CurrentHealth += HealValue;
            DecreaseCount(1);
        }
    }
}