using _Project.Scripts.Configs.Inventory;
using UnityEngine;

namespace _Project.Scripts.Configs.Weapon
{
    public abstract class WeaponConfig : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _ammoPerShoot;
        
        [SerializeField] private ItemConfig _ammoTypeConfig;
        
        public int Damage => _damage;
        public int AmmoPerShoot => _ammoPerShoot;
        
        public ItemConfig AmmoTypeConfig => _ammoTypeConfig;
    }
}