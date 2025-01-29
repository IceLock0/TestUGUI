using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Configs.Inventory
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/Inventory/BaseItem", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private Image _image;
        [SerializeField] private string _name;
        [SerializeField] private float _weight;
        [SerializeField] private int _maxStack;
        [SerializeField] private int _count;
        
        public Image Image => _image;
        public string Name => _name;
        public float Weight => _weight;
        public int MaxStack => _maxStack;
        public int Count => _count;

        private void OnValidate()
        {
            _count = Mathf.Clamp(_count, 0, _maxStack);
        }
    }
}