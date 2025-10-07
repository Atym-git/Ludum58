using UnityEngine;

public class ItemClickTracker : MonoBehaviour
{
    public void OnRayCastHit()
    {
        transform.parent.parent.TryGetComponent(out Item item);
        item.OnClick();
    }
}
