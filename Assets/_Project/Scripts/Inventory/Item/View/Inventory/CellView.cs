using _Project.Scripts.Inventory.Item.View;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Inventory
{
    public class CellView : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (GetComponentInChildren<ItemView>() != null)
                return;
            
            var itemTransform = eventData.pointerDrag.transform;
            itemTransform.SetParent(transform);
            itemTransform.localPosition = Vector3.zero;
        }
    }
}