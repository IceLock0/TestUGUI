using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Configs.Inventory
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "Configs/Inventory/Grid", order = 0)]
    public class GridConfig : ScriptableObject
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private List<StartItemData> _startItems;

        [SerializeField] private bool _useStartItems;
        
        public Vector2Int Size => _size;
        public List<StartItemData> StartItems => _startItems;
        
        public bool UseStartItems => _useStartItems;
    }

    [Serializable]
    public class StartItemData
    {
        [SerializeField] private Vector2Int _position;
        [SerializeField] private ItemConfig _itemConfig;
        
        public Vector2Int Position => _position;
        public ItemConfig ItemConfig => _itemConfig;
    }
}