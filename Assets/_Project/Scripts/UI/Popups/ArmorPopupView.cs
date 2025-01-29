using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Inventory.Item.View
{
    public class ArmorPopupView : PopupView
    {
        [SerializeField] private TextMeshProUGUI _armorValueText;

        public void SetInfo(Image sourceImage, string title, float weight, int armorValue)
        {
            base.SetInfo(sourceImage, title, weight);
            _armorValueText.text = armorValue.ToString();
        }
    }
}