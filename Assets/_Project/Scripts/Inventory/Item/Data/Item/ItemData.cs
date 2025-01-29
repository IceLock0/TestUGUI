using System;
using UnityEngine.UI;

namespace _Project.Scripts.Inventory
{
    [Serializable]
    public class ItemData
    {
        [NonSerialized] public Image Image;
        public string Name;
        public float Weight;
        public int MaxStack;
        public int Count;

        public event Action<int> CountChanged;
        
        public void DecreaseCount(int value)
        {
            Count -= value;
            CountChanged?.Invoke(Count);
        }

        public void IncreaseCount(int value)
        {
            Count += value;
            CountChanged?.Invoke(Count);
        }
        
        public virtual void Use()
        {
            IncreaseCount(MaxStack - Count);
        }
    }
}