using System.Collections.Generic;
using _Project.Scripts.Inventory;

namespace _Project.Scripts.Providers.Inventory
{
    public class ReadOnlyInventoryItemsProvider : IReadOnlyInventoryItemsProvider
    {
        private readonly Scripts.Inventory.Inventory _inventory;

        public ReadOnlyInventoryItemsProvider(Scripts.Inventory.Inventory inventory)
        {
            _inventory = inventory;
        }

        public void Save()
        {
            _inventory.Save();
        }
        
        public List<ItemData> GetItems()
        {
            return _inventory.GetItems();
        }
    }
}