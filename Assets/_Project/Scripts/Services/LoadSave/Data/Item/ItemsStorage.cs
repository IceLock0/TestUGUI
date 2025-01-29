using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory;

namespace _Project.Scripts.Services.LoadSave.Data.Item
{
    [Serializable]
    public class ItemsStorage
    {
        public List<ItemData> Items;
    }
}