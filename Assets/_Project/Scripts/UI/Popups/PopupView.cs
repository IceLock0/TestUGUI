using System;
using _Project.Scripts.Utils.Extension;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Inventory.Item.View
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] private Button _removeButton;
        [SerializeField] private Button _useButton;
        
        [SerializeField] private Image _sourceImage;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _weightText;

        public event Action RemoveButtonClicked;
        public event Action UseButtonClicked;
        
        public void SetInfo(Image sourceImage, string title, float weight)
        {
            _sourceImage.sprite = sourceImage.sprite;
            _titleText.text = title;
            _weightText.text = weight.ToString();
        }

        private void OnEnable()
        {
            _removeButton.AddListener(() => RemoveButtonClicked?.Invoke());
            _useButton.AddListener(() => UseButtonClicked?.Invoke());
        }

        private void OnDisable()
        {
            _removeButton.RemoveListener(() => RemoveButtonClicked?.Invoke());
            _useButton.RemoveListener(() => UseButtonClicked?.Invoke());
        }
    }
}