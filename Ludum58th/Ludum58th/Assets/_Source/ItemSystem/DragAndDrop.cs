using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private const string ITEMS_PARENT_PANEL_TAG = "ItemsParentPanel";

    private const string PLAYER_CANVAS_TAG = "PlayerCanvas";

    private RectTransform _rectTransform;
    private Image _image;

    private Transform _parentAfterDrag;

    private RectTransform parentPanelRT;

    private Canvas canvas;

    private void Start()
    {
        parentPanelRT = GameObject.FindGameObjectWithTag(ITEMS_PARENT_PANEL_TAG)
            .GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag(PLAYER_CANVAS_TAG)
            .GetComponent<Canvas>();

        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _parentAfterDrag = transform.parent;
        transform.SetParent(parentPanelRT);
        _image.raycastTarget = false;
        DraggableContainer.DraggableItem = gameObject;
        DraggableContainer.IsDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_parentAfterDrag);
        _image.raycastTarget = true;
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out Slot slot))
            {
                slot.OnItemDrop();
            }
        }
        DraggableContainer.DraggableItem = null;
        DraggableContainer.IsDragging = false;
    }

}
