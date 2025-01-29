using System.Collections.Generic;
using _Project.Scripts.Configs.Inventory;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.View;

namespace _Project.Scripts.Utils.Factory.ItemFactory
{
    public interface IItemFactory
    {
        public ItemView CreateByIndex(int index, ItemConfig itemConfig, List<CellView> cells);
        public ItemView CreateFirstFreeWithItemConfig(ItemConfig itemConfig, List<CellView> cells);
        public ItemView CreateFirstFreeWithItemData(ItemData itemData, List<CellView> cells);
    }
}