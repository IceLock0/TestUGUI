using System.Collections.Generic;
using _Project.Scripts.Inventory;

namespace _Project.Scripts.Providers.Inventory
{
    public interface IReadOnlyInventoryItemsProvider
    {
        public List<ItemData> GetItems();
        public void Save();
    }
}