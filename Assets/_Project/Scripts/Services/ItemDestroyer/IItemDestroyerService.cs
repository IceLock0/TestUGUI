using System;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.View;

namespace _Project.Scripts.Services.ItemDestroyerService
{
    public interface IItemDestroyerService
    {
        public void DestroyItem(ItemData itemData, ItemView itemView);
        public event Action<ItemData> Destroyed;
    }
}