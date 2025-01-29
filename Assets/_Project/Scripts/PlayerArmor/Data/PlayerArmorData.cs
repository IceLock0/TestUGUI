using System;
using _Project.Scripts.Enums;

namespace _Project.Scripts.Inventory.Item.Data
{
    [Serializable]
    public class PlayerArmorData
    {
        public ArmorItemData HeadArmorItemData;
        public ArmorItemData BodyArmorItemData;

        public event Action<ArmorType> Changed;

        public ArmorItemData SetNewArmorAndGetPrev(ArmorItemData armorItemData)
        {
            ArmorItemData prev;

            if (armorItemData.ArmorType == ArmorType.Head)
            {
                prev = HeadArmorItemData == null ? null : new ArmorItemData(HeadArmorItemData);
                HeadArmorItemData = armorItemData;
            }
            else
            {
                prev = BodyArmorItemData == null ? null : new ArmorItemData(BodyArmorItemData);
                BodyArmorItemData = armorItemData;
            }
            
            Changed?.Invoke(armorItemData.ArmorType);
            
            return prev;
        }
    }
}