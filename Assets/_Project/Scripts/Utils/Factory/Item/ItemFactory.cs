using System.Collections.Generic;
using _Project.Scripts.Configs.Inventory;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.Data;
using _Project.Scripts.Inventory.Item.View;
using _Project.Scripts.Services.ItemDestroyerService;
using _Project.Scripts.Services.ItemUseService;
using _Project.Scripts.Services.LoadSave;
using _Project.Scripts.Utils.ItemInfo;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Utils.Factory.ItemFactory
{
    public class ItemFactory : IItemFactory
    {
        private readonly DiContainer _container;
        private readonly ItemView _itemPrefab;

        private readonly IPopupFactory _popupFactory;

        private readonly HealthView _playerHealthView;
        private readonly PlayerArmorView _playerArmorView;

        private readonly Inventory.Inventory _inventory;
        private readonly IImagePrefabProvider _imagePrefabProvider;
        private readonly IItemDestroyerService _itemDestroyerService;
        private readonly IItemUseService _itemUseService;

        public ItemFactory(DiContainer container, ItemView itemPrefab, IPopupFactory popupFactory,
            HealthView playerHealthView, PlayerArmorView playerArmorView, Inventory.Inventory inventory,
            IImagePrefabProvider imagePrefabProvider, IItemDestroyerService itemDestroyerService, IItemUseService itemUseService)
        {
            _container = container;
            _itemPrefab = itemPrefab;

            _popupFactory = popupFactory;

            _playerHealthView = playerHealthView;
            _playerArmorView = playerArmorView;

            _inventory = inventory;
            _imagePrefabProvider = imagePrefabProvider;
            _itemDestroyerService = itemDestroyerService;
            _itemUseService = itemUseService;
        }
        
        public ItemView CreateByIndex(int index, ItemConfig itemConfig, List<CellView> cells)
        {
            ItemView item = null;

            for (var i = 0; i < cells.Count; i++)
            {
                if (i == index)
                {
                    item = Create(cells[i].transform, itemConfig);
                    break;
                }
            }

            return item;
        }
        
        public ItemView CreateFirstFreeWithItemData(ItemData itemData, List<CellView> cells)
        {
            return TryGetFirstFree(cells, out var firstFree) ? Create(firstFree, itemData) : null;
        }
        
        public ItemView CreateFirstFreeWithItemConfig(ItemConfig itemConfig, List<CellView> cells)
        {
            return TryGetFirstFree(cells, out var firstFree) ? Create(firstFree, itemConfig) : null;
        }

        private bool TryGetFirstFree(List<CellView> cells, out Transform firstFree)
        {
            for (var i = 0; i < cells.Count; i++)
            {
                if (cells[i].GetComponentInChildren<ItemView>() == null)
                {
                    firstFree = cells[i].transform;
                    return true;
                }
            }

            Debug.Log("No empty");
            firstFree = null;
            return false;
        }
        
        private ItemView Create(Transform cell, ItemData itemData)
        {
            var created = _container.InstantiatePrefabForComponent<ItemView>(_itemPrefab, cell);

            SetAdditionalData(itemData);
            
            created.Initialize(itemData, _popupFactory, _itemDestroyerService, _itemUseService);

            _inventory.AddItem(itemData);

            return created;
        }

        private void SetAdditionalData(ItemData itemData)
        {
            switch (itemData)
            {
                case ArmorItemData armor: armor.PlayerArmorData = _playerArmorView.PlayerArmorData; break;
                case HealItemData heal: heal.PlayerHealthData = _playerHealthView.HealthData; break;
            }
            
            itemData.Image = _imagePrefabProvider.GetImage(itemData.Name);
        }
        
        private ItemView Create(Transform cell, ItemConfig config)
        {
            var created = _container.InstantiatePrefabForComponent<ItemView>(_itemPrefab, cell);

            if (!TryGetItemData(config, out var itemData))
            {
                Debug.Log("Cannot Find ItemData");
                return created;
            }

            created.Initialize(itemData, _popupFactory, _itemDestroyerService, _itemUseService);

            _inventory.AddItem(itemData);

            return created;
        }
        
        private bool TryGetItemData(ItemConfig config, out ItemData itemData)
        {
            itemData = config switch
            {
                ArmorItemConfig cfg => GetArmorItemData(cfg),
                HealItemConfig cfg => GetHealItemData(cfg),
                _ => GetItemData(config)
            };

            return itemData != null;
        }
        
        private ItemData GetItemData(ItemConfig itemConfig)
        {
            return new ItemData()
            {
                Image = itemConfig.Image,
                Name = itemConfig.Name,
                Weight = itemConfig.Weight,
                MaxStack = itemConfig.MaxStack,
                Count = itemConfig.Count,
            };
        }

        private ArmorItemData GetArmorItemData(ArmorItemConfig armorItemConfig)
        {
            return new ArmorItemData()
            {
                PlayerArmorData = _playerArmorView.PlayerArmorData,
                Image = armorItemConfig.Image,
                Name = armorItemConfig.Name,
                Weight = armorItemConfig.Weight,
                MaxStack = armorItemConfig.MaxStack,
                Count = armorItemConfig.Count,
                ArmorValue = armorItemConfig.ArmorValue,
                ArmorType = armorItemConfig.ArmorType,
            };
        }

        private HealItemData GetHealItemData(HealItemConfig healItemConfig)
        {
            return new HealItemData()
            {
                PlayerHealthData = _playerHealthView.HealthData,
                Image = healItemConfig.Image,
                Name = healItemConfig.Name,
                Weight = healItemConfig.Weight,
                MaxStack = healItemConfig.MaxStack,
                Count = healItemConfig.Count,
                HealValue = healItemConfig.HealValue
            };
        }
    }
}