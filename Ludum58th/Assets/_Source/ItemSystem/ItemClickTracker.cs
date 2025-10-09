using UnityEngine;

public class ItemClickTracker : MonoBehaviour
{
    public void OnRayCastHit()
    {
        Transform itemTransform = transform.parent.parent;
        if (itemTransform.TryGetComponent(out Item item))
        {
            item.OnClick();
            if (itemTransform.parent.TryGetComponent(out Slot slot))
            {
                slot.ShowLeftItemsUI();
            }
        }
    }
}
