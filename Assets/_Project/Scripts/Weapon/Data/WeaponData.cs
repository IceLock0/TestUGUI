using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.Data;
using _Project.Scripts.Providers.Inventory;

namespace _Project.Scripts.Weapon.Data
{
    [Serializable]
    public class WeaponData
    {
        private readonly HealthData _enemyHealth;
        private readonly IReadOnlyInventoryItemsProvider _readonlyInventoryItemsProvider;
        
        public string AmmoId;
        public int Damage;
        public int AmmoPerShoot;
        
        public WeaponData(HealthData enemyHealth, IReadOnlyInventoryItemsProvider readOnlyInventoryItemsProvider)
        {
            _enemyHealth = enemyHealth;
            _readonlyInventoryItemsProvider = readOnlyInventoryItemsProvider;
        }

        public bool TryToShoot()
        {
            var isEnoughAmmo = TryFindAmmo();

            if (!isEnoughAmmo)
                return false;

            _enemyHealth.CurrentHealth -= Damage;
            
            _readonlyInventoryItemsProvider.Save();
            
            return true;
        }

        private bool TryFindAmmo()
        {
            var items = _readonlyInventoryItemsProvider.GetItems()
                .Where(item => string.Equals(item.Name, AmmoId))
                .OrderBy(item => item.Count)
                .ToList();

            int totalAvailableAmmo = items.Sum(item => item.Count);

            if (totalAvailableAmmo < AmmoPerShoot)
                return false;

            int remainingAmmoToUse = AmmoPerShoot;

            foreach (var item in items)
            {
                if (remainingAmmoToUse <= 0)
                    break;

                int ammoToConsume = Math.Min(item.Count, remainingAmmoToUse);
                remainingAmmoToUse -= ammoToConsume;
                item.DecreaseCount(ammoToConsume);
            }

            return true;
        }
    }
}