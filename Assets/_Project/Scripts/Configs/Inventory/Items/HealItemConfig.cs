using UnityEngine;

namespace _Project.Scripts.Configs.Inventory
{
    [CreateAssetMenu(fileName = "HealItemConfig", menuName = "Configs/Inventory/Heal", order = 0)]
    public class HealItemConfig : ItemConfig
    {
        [SerializeField] private int _healValue;

        public int HealValue => _healValue;
    }
}