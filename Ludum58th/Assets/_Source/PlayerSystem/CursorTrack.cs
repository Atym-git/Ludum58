using UnityEngine;

public class CursorTrack
{
    public void TrackOnClick(Camera camera/*, LayerMask itemLayerMask*/)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out Door door))
            {
                door.OnClick();
            }

            if (hitInfo.collider.TryGetComponent(out ItemClickTracker itemClickTracker))
            {
                itemClickTracker.OnRayCastHit();
            }
                
        }
    }
}
