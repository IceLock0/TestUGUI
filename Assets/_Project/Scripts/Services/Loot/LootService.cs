using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Configs.Inventory;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.View;
using _Project.Scripts.Providers.Death;
using _Project.Scripts.Utils.Factory.ItemFactory;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Services.Loot
{
    public class LootService : ILootService, IDisposable, IInitializable
    {
        private readonly List<ItemConfig> _itemConfigs = new();
        private readonly Canvas _canvas;
        private readonly IItemFactory _itemFactory;
        private readonly IDeathProvider _deathProvider;

        public LootService(List<ItemConfig> itemConfigs, Canvas canvas, IItemFactory itemFactory, IDeathProvider deathProvider)
        {
            _itemConfigs = itemConfigs;
            _canvas = canvas;
            _itemFactory = itemFactory;
            _deathProvider = deathProvider;
        }
        
        public void Initialize()
        {
            _deathProvider.OnEnemyDeath += CreateLoot;
        }
        
        public void CreateLoot()
        {
            var rndIndex = Random.Range(0, _itemConfigs.Count);

            var cells = _canvas.GetComponentsInChildren<CellView>().ToList();

            _itemFactory.CreateFirstFreeWithItemConfig(_itemConfigs[rndIndex], cells);
        }

        public void Dispose()
        {
            _deathProvider.OnEnemyDeath -= CreateLoot;
        }
    }
}