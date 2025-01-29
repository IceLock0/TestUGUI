using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace _Project.Scripts.Inventory.Item.View
{
    public class DragAndDropComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        
        [Inject]
        public void Initialize(Canvas canvas)
        {
            _canvas = canvas;
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;

            var parentTransform = _rectTransform.parent;
            parentTransform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _rectTransform.localPosition = Vector3.zero;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}