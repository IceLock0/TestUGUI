using System.Collections.Generic;
using _Project.Scripts.Configs.Inventory;
using _Project.Scripts.Inventory;
using _Project.Scripts.Services.LoadSave;
using _Project.Scripts.Services.LoadSave.Data.Item;
using _Project.Scripts.Utils.Factory;
using _Project.Scripts.Utils.Factory.ItemFactory;
using _Project.Scripts.Utils.Path;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Bootstrap
{
    public class Bootstrapper : IInitializable
    {
        private readonly IGridFactory _gridFactory;
        private List<CellView> _cells = new();

        private readonly IItemFactory _itemFactory;
        private readonly GridConfig _gridConfig;

        private readonly ISaveLoadService _saveLoadService;

        public Bootstrapper(IGridFactory gridFactory, IItemFactory itemFactory, ISaveLoadService saveLoadService,
            GridConfig gridConfig)
        {
            _gridFactory = gridFactory;

            _itemFactory = itemFactory;
            _gridConfig = gridConfig;

            _saveLoadService = saveLoadService;
        }

        public void Initialize()
        {
            CreateGridWithCells();

            CreateItems();
        }

        private void CreateGridWithCells()
        {
            _cells = _gridFactory.CreateGridWithCells();
        }

        private void CreateItems()
        {
            if (!_gridConfig.UseStartItems)
                CreateLoadedItems();

            else CreateStartItems();
        }

        private void CreateLoadedItems()
        {
            var data = _saveLoadService.Load<ItemsStorage>(SaveKeys.ITEMS);

            if (data == null)
            {
                Debug.Log("No saved items found");
                CreateStartItems();
                return;
            }
            
            foreach (var item in data.Items)
            {
                _itemFactory.CreateFirstFreeWithItemData(item, _cells);
            }
        }

        private void CreateStartItems()
        {
            var items = GetStartItems();

            foreach (var kvp in items)
            {
                _itemFactory.CreateByIndex(kvp.Key, kvp.Value, _cells);
            }
        }

        private Dictionary<int, ItemConfig> GetStartItems()
        {
            Dictionary<int, ItemConfig> items = new();

            foreach (var item in _gridConfig.StartItems)
            {
                var index = (item.Position.y - 1) * _gridConfig.Size.x + (item.Position.x - 1);
                var config = item.ItemConfig;

                items[index] = config;
            }

            return items;
        }
    }
}