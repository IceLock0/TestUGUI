using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.View;

namespace _Project.Scripts.Utils.Factory
{
    public interface IPopupFactory
    {
        public PopupView CreatePopup(ItemData itemData);
    }
}