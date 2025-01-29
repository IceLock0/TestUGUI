using System;
using _Project.Scripts.Enums;
using _Project.Scripts.Inventory.Item.Data;

namespace _Project.Scripts.Inventory
{
    [Serializable]
    public class ArmorItemData : ItemData
    {
        [NonSerialized]
        public PlayerArmorData PlayerArmorData;

        public ArmorType ArmorType;
        public int ArmorValue;

        public ArmorItemData(){}
        
        public ArmorItemData(ArmorItemData armorItemData)
        {
            if (armorItemData == null)
                return;

            SetData(armorItemData);
        }

        public override void Use()
        {
            var prev = PlayerArmorData.SetNewArmorAndGetPrev(new ArmorItemData(this));

            if (prev == null)
                DecreaseCount(Count);
            else
            {
                SetData(prev);
                DecreaseCount(0);
            }
        }

        private void SetData(ArmorItemData armorItemData)
        {
            Image = armorItemData.Image;
            Name = armorItemData.Name;
            Weight = armorItemData.Weight;
            MaxStack = armorItemData.MaxStack;
            Count = armorItemData.Count;
            ArmorType = armorItemData.ArmorType;
            ArmorValue = armorItemData.ArmorValue;
        }
    }
}