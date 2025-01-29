using System;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.View;
using UnityEngine;

namespace _Project.Scripts.Services.ItemDestroyerService
{
    public class ItemDestroyerService : MonoBehaviour, IItemDestroyerService
    {
        public void DestroyItem(ItemData itemData, ItemView itemView)
        {
            Destroy(itemView.gameObject);
            Destroyed?.Invoke(itemData);
        }

        public event Action<ItemData> Destroyed;
    }
}