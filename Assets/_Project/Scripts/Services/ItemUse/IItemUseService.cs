using System;
using _Project.Scripts.Inventory;

namespace _Project.Scripts.Services.ItemUseService
{
    public interface IItemUseService
    {
        public void Use(ItemData itemData);
        public event Action Used;
    }
}