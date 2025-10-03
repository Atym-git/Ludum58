using UnityEngine;

public class CursorTrack
{
    public void TrackOnClick(Camera camera, LayerMask itemLayer)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (LayerMaskUtil.ContainsLayer(itemLayer, hitInfo.transform.gameObject))
            {
                Debug.Log("Hit an item");
            }
        }
    }
}
