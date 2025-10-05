using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour/*, IDropHandler*/
{
    //public void OnDrop(PointerEventData eventData)
    //{
    //    if (eventData.pointerDrag != null)
    //    {
    //        //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
    //        //    GetComponent<RectTransform>().anchoredPosition;
    //        GameObject dropped = eventData.pointerDrag;
    //        DragAndDrop drag = dropped.GetComponent<DragAndDrop>();
    //        drag.ParentAfterDrag = transform;
    //    }
    //}

    private bool _isDragging;

    public void Construct(DraggableContainer container)
    {
        _isDragging = container.DraggableItem != null;
    }

    private void OnMouseEnter()
    {
        if (_isDragging)
        {

        }
    }
}
