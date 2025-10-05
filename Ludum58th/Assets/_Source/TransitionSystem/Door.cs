using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform teleportToTransform;

    private void OnMouseDown()
    {
        Invoker.InvokeTeleportTo(teleportToTransform);
    }

}
