using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Inventory.Item.View
{
    public class HealPopupView : PopupView
    {
        [SerializeField] private TextMeshProUGUI _healValueText;
        
        public void SetInfo(Image sourceImage, string title, float weight, int healValue)
        {
            base.SetInfo(sourceImage, title, weight);
            _healValueText.text = healValue.ToString();
        }
    }
}