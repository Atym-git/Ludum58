using UnityEngine;

public class CursorTrack
{
    public void TrackOnClick(Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        //Debug.Log($"Click at {camera.ScreenPointToRay(Input.mousePosition)}");
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent<Item>(out Item item))
            {
                Debug.Log("Hit an item");
            }
        }
    }
}
