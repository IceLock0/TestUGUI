using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Services.ItemDestroyerService;
using _Project.Scripts.Services.ItemUseService;
using _Project.Scripts.Services.LoadSave;
using _Project.Scripts.Services.LoadSave.Data.Item;
using _Project.Scripts.Utils.ItemInfo;
using _Project.Scripts.Utils.Path;
using _Project.Scripts.Weapon.View;

namespace _Project.Scripts.Inventory
{
    public class Inventory : IDisposable
    {
        private readonly List<ItemData> _items = new();
        
        private readonly ISaveLoadService _saveLoadService;
        private readonly IItemDestroyerService _itemDestroyerService;
        private readonly IItemUseService _itemUseService;

        public Inventory(ISaveLoadService saveLoadService, IItemDestroyerService itemDestroyerService, IItemUseService itemUseService)
        {
            _saveLoadService = saveLoadService;
            _itemDestroyerService = itemDestroyerService;
            _itemUseService = itemUseService;

            _itemDestroyerService.Destroyed += RemoveItem;
            _itemUseService.Used += Save;
        }
        
        public void AddItem(ItemData item)
        {
            if (_items.Contains(item))
                return;
            
            _items.Add(item);
            
            Save();
        }
        
        public void RemoveItem(ItemData item)
        {
            if (!_items.Contains(item))
                return;

            _items.Remove(item);
            
            Save();
        }

        public List<ItemData> GetItems()
        {
            return _items;
        }

        public void Dispose()
        {
            _itemDestroyerService.Destroyed -= RemoveItem;
            _itemUseService.Used -= Save;
        }

        public void Save()
        {
            _saveLoadService.Save(SaveKeys.ITEMS, new ItemsStorage { Items = _items });
        }
    }
}