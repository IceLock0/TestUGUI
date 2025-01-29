using System;
using _Project.Scripts.Inventory;

namespace _Project.Scripts.Services.ItemUseService
{
    public class ItemUseService : IItemUseService
    {
        public void Use(ItemData itemData)
        {
            itemData?.Use();
            Used?.Invoke();
        }

        public event Action Used;
    }
}