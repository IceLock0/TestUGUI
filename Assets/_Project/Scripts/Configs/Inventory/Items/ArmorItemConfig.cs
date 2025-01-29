using _Project.Scripts.Enums;
using UnityEngine;

namespace _Project.Scripts.Configs.Inventory
{
    [CreateAssetMenu(fileName = "ArmorItemConfig", menuName = "Configs/Inventory/Armor", order = 0)]
    public class ArmorItemConfig : ItemConfig
    {
        [SerializeField] private ArmorType _armorType;
        [SerializeField] private int _armorValue;
        
        public int ArmorValue => _armorValue;
        public ArmorType ArmorType => _armorType;
    }
}